using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Livestream.Application
{
    /// <summary>
    /// Startup extensions
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Add application layer
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}