using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Ordering.Infrastructure
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
            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
