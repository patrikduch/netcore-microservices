using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NetMicroservices.RabbitMqWrapper.Nuget
{
    public static class Extensions
    {
        /// <summary>
        /// Registration of RabbitMQ wrapper communication layer with MassTransit framework.
        /// </summary>
        /// <param name="services">List of current services.</param>
        /// <param name="serviceName">Microservice name that is invoking this registration setup.</param>
        /// <returns></returns>
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services, string serviceName)
        {

            services.AddMassTransit(config =>
            {
                // Registration of RabbitMQ consumers
                // All RabbitMQ consumer that are in particular assembly will be registered by this method
                config.AddConsumers(Assembly.GetExecutingAssembly());

                // Definition of transport type
                config.UsingRabbitMq((ctx, cfg) =>
                {

                    var configuration = ctx.GetService<IConfiguration>();

                    //config.AddConsumer<OrderConsumer>();
                    var rabbitMqSettings = configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();

                    // Localization of RabbitMQ server host
                    cfg.Host(rabbitMqSettings.Host);
                    bool propageQueueFullName = false;
                    cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter(serviceName, propageQueueFullName));
                });
            });

            services.AddMassTransitHostedService();

            return services; // returns services instance
        }
    }
}
