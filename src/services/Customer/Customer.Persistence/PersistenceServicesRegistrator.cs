using Customer.Application.Contracts;
using Customer.Domain;
using Customer.Persistence.Contexts;
using Customer.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMicroservices.SqlWrapper.Nuget;
using NetMicroservices.SqlWrapper.Nuget.Repositories;

namespace Customer.Persistence
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
        /// <returns></returns>
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, PersonContext>();

            var res = configuration.GetValue<string>("DatabaseSettings:ConnectionString");

            services.AddDbContext<PersonContext>(options =>
                options.UseSqlServer((configuration.GetValue<string>("DatabaseSettings:ConnectionString"))));

            services.AddScoped(typeof(IAsyncRepository<Person>), typeof(RepositoryBase<Person, PersonContext>));
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }

    }
}
