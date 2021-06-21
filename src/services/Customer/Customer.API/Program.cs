using Customer.Persistence.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetMicroservices.SqlWrapper.Nuget.Extensions;

namespace Customer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()

                 .MigrateDatabase<PersonContext>((context, services) =>
                 {
                     var logger = services.GetService(typeof(ILogger<PersonContextSeed>)) as ILogger<PersonContextSeed>;

                     PersonContextSeed
                            .SeedAsync(context, logger)
                            .Wait();
                 })

                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
