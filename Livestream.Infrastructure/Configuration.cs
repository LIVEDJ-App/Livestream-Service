using Livestream.Infrastructure.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Livestream.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IEventPublisher, EventPublisher>();
            services.AddSingleton<ChannelManager>();

            return services;
        }
    }
}