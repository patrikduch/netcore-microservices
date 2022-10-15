namespace Product.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Persistence.Configurations;
using Product.Persistence.Contexts;

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


        var res = configuration.GetSection("DatabaseSettings:ConnectionString").Value;


        services.AddScoped<DbContext, ProductContext>();


        services.AddDbContext<ProductContext>(options =>
            options.UseNpgsql((res)));

        return services;
    }
}
