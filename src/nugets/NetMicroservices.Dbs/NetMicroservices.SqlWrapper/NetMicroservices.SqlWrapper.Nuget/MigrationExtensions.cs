namespace NetMicroservices.SqlWrapper.Nuget;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Data.SqlClient;

public static class MigrationUtil
{
    /// <summary>
    /// EFCore migration functionality.
    /// </summary>
    /// <typeparam name="TContext"><seealso cref="DbContext"/> of particular domain entity on which we want to apply existing migrations.</typeparam>
    /// <param name="host">Reference to the Host provider dependency.</param>
    /// <param name="seeder">Seeder object dependency.</param>
    /// <returns></returns>
    public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(
                            retryCount: 5,
                            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // 2,4,8,16,32 sc
                            onRetry: (exception, retryCount, context) =>
                            {
                                logger.LogError($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                            });

                //if the sql server container is not created on run docker compose this
                //migration can't fail for network related exception. The retry options for DbContext only 
                //apply to transient exceptions                    
                retry.Execute(() => InvokeSeeder(seeder, context, services));

                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
            }
        }

        return host;
    }

    /// <summary>
    /// Invokation of seeder functionality.
    /// </summary>
    /// <typeparam name="TContext">DBontext of particular domain entity object.</typeparam>
    /// <param name="seeder">Seeder object dependency.</param>
    /// <param name="context">DbContext entity domain object dependency.</param>
    /// <param name="services">Collection of Dependency Injection services.</param>
    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
        where TContext : DbContext
    {
        var logger = services.GetRequiredService<ILogger<TContext>>();

        try
        {
            context.Database.Migrate();
            logger.LogInformation("Database was successfully migrated.");

        } catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
        
        seeder(context, services);
    }
}
