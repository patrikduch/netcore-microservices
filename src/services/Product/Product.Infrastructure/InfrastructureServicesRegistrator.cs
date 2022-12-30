//--------------------------------------------------------------------------------
// <copyright file="InfrastructureServicesRegistrator.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//--------------------------------------------------------------------------------
namespace Product.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Registration of infrastructure services.
/// </summary>
public static class InfrastructureServicesRegistrator
{
    /// <summary>
    /// Definition of service sets that are being used by Infrastructure project.
    /// </summary>
    /// <param name="services">Service collection fo Dependency Injection Container.</param>
    /// <returns>Collection of DI services.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
}
