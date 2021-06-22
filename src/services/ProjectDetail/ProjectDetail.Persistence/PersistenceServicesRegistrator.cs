using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMicroservices.SqlWrapper.Nuget;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using ProjectDetail.Application.Contracts.Persistence;
using ProjectDetail.Domain;
using ProjectDetail.Persistence.Contexts;
using ProjectDetail.Persistence.Repositories;

namespace ProjectDetail.Persistence
{
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
            services.AddScoped<DbContext, ProjectContext>();

            var res = configuration.GetValue<string>("DatabaseSettings:ConnectionString");

            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer((configuration.GetValue<string>("DatabaseSettings:ConnectionString"))));

            services.AddScoped(typeof(IAsyncRepository<Project>), typeof(RepositoryBase<Project, ProjectContext>));
            services.AddScoped<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
