using Livestream.Application;
using Livestream.Infrastructure;
using Livestream.Persistence.Mongo;
using Livestream.Persistence.Mongo.Interfaces;
using Livestream.Persistence.Mongo.Repositories;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry()
            .WithMetrics(x =>
            {
                x.AddPrometheusExporter(); 
                x.AddMeter("Microsoft.AspNetCore.Hosting",
                           "Microsoft.AspNetCore.Server.Kestrel");
                x.AddView("request-duration",
                    new ExplicitBucketHistogramConfiguration{
                        Boundaries = [0, 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.75, 1, 1.25, 1.5, 1.75, 2]
                    }
                );
            });

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<ILivestreamRepository, LivestreamRepository>();
builder.Services.Configure<MongoDbSettings>(options =>
{
    options.ConnectionString = Environment.GetEnvironmentVariable("MongoDB-ConnectionString") ?? throw new ArgumentNullException("MongoDB-ConnectionString environment variable is not set.");
    options.DatabaseName = Environment.GetEnvironmentVariable("Database-Name") ?? throw new ArgumentNullException("Database-Name environment variable is not set.");
    options.CollectionName = Environment.GetEnvironmentVariable("Collection-Name") ?? throw new ArgumentNullException("Collection-Name environment variable is not set.");
});


var app = builder.Build();

app.MapPrometheusScrapingEndpoint();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
