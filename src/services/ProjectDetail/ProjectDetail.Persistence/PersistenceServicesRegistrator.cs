//------------------------------------------------------------------------------------
// <copyright file="PersistenceServicesRegistrator.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
namespace ProjectDetail.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMicroservices.SqlWrapper.Nuget;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using ProjectDetail.Application.Contracts.Persistence;
using Domain;
using Contexts;
using Repositories;

/// <summary>
/// Registration of persistence services.
/// </summary>
public static class PersistenceServicesRegistrator
{
    /// <summary>
    /// Definition of service sets that are being used by Persistence project.
    /// </summary>
    /// <param name="services">Service collection fo Dependency Injection Container.</param>
    /// <returns>Dependency Injection services collection.</returns>
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, ProjectDetailContext>();
        services.AddDbContext<ProjectDetailContext>(options =>
            options.UseSqlServer((configuration.GetValue<string>("DatabaseSettings:ConnectionString"))));

        services.AddScoped(typeof(IAsyncRepository<ProjectDetailEntity>), typeof(RepositoryBase<ProjectDetailEntity, ProjectDetailContext>));
        services.AddScoped<IProjectRepository, ProjectDetailRepository>();

        return services;
    }
}
