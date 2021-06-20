using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetMicroservices.SqlWrapper.Nuget.Extensions;
using Ordering.Persistence.Contexts;

namespace Ordering.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                 .MigrateDatabase<OrderContext>((context, services) =>
                 {
                     var logger = services.GetService(typeof(ILogger<OrderContextSeed>)) as ILogger<OrderContextSeed>;

                     OrderContextSeed
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
