//---------------------------------------------------------------------------
// <copyright file="ProductController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

namespace User.Application;

/// <summary>
/// Registration of application services.
/// </summary>
public static class ApplicationServicesRegistrator
{
    /// <summary>
    /// Definition of service sets that are being used by Application project.
    /// </summary>
    /// <param name="services">Service collection fo Dependency Injection Container.</param>
    /// <returns>Collection of DI services.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }
}
