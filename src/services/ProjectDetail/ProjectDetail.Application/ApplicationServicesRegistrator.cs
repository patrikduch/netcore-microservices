using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetMicroservices.MediatorWrapper.Nuget.Behaviors;
using System.Reflection;

namespace ProjectDetail.Application
{
    /// <summary>
    /// Registration of application services.
    /// </summary>
    public static class ApplicationServicesRegistrator
    {
        /// <summary>
        /// Definition of service sets that are being used by Application project.
        /// </summary>
        /// <param name="services">Service collection fo Dependency Injection Container.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
