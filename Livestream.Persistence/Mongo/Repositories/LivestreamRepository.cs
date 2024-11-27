using Livestream.Domain.Entities;
using Livestream.Persistence.Mongo.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Livestream.Persistence.Mongo.Repositories
{
    public class LivestreamRepository : ILivestreamRepository
    {
        private readonly IMongoCollection<LivestreamModel> _livestreams;

        public LivestreamRepository(IOptions<MongoDbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _livestreams = mongoDatabase.GetCollection<LivestreamModel>(databaseSettings.Value.CollectionName);
        }

        public async Task AddAsync(LivestreamModel livestream)
        {
            await _livestreams.InsertOneAsync(livestream);
        }
    }
}
