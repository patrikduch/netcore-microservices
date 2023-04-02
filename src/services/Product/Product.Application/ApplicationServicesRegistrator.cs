﻿//--------------------------------------------------------------------------------
// <copyright file="ApplicationServicesRegistrator.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//--------------------------------------------------------------------------------

using Product.Application.Categories.Interfaces;
using Product.Application.Categories.Readers;

namespace Product.Application;

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());


        services.AddScoped<ICategoryReader, CategoryReader>();

        return services;
    }
}