using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection;
using RabbitMqWrapper.Nuget.Settings;

namespace RabbitMqWrapper.Nuget
{
    public static class Extensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services, RabbitMqSettings rabbitMqSettings, string serviceName)
        {

            services.AddMassTransit(config =>
            {

                // Definition of transport type
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    // Localization of RabbitMQ server host
                    cfg.Host(rabbitMqSettings.Host);

                    bool propageQueueFullName = false;
                    cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter(serviceName, propageQueueFullName));

                });
            });


            services.AddMassTransitHostedService();

            return services;
        }
    }
}
