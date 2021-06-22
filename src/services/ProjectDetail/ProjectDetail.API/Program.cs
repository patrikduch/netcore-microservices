using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectDetail.API.Extensions;
using ProjectDetail.Persistence.Contexts;

namespace ProjectDetail.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()

                .MigrateDatabase<ProjectContext>((context, services) =>
                {
                    var logger = services.GetService(typeof(ILogger<ProjectContextSeed>)) as ILogger<ProjectContextSeed>;

                    ProjectContextSeed
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
