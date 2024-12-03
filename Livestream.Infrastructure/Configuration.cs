using Livestream.Infrastructure.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Livestream.Infrastructure
{
    /// <summary>
    /// Startup extensions
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Add infrastructure layer
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IEventPublisher, EventPublisher>();
            services.AddSingleton<ChannelManager>();

            return services;
        }
    }
}