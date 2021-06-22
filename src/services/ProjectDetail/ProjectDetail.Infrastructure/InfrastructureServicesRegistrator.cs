using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectDetail.Infrastructure
{
    /// <summary>
    /// Registration of infrastructure services.
    /// </summary>
    public static class InfrastructureServicesRegistrator
    {
        /// <summary>
        /// Definition of service sets that are being used by Infrastructure project.
        /// </summary>
        /// <param name="services">Service collection fo Dependency Injection Container.</param>
        /// <returns>Collection of Dependency Injection services.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
