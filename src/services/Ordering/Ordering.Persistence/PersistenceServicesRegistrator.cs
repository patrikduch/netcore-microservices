using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetMicroservices.SqlWrapper.Nuget;
using Ordering.Application.Contracts.Persistence;
using Ordering.Persistence.Contexts;
using Ordering.Persistence.Repositories;
using NetMicroservices.SqlWrapper.Nuget.Repositories;
using Ordering.Domain.Entities;

namespace Ordering.Persistence
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
            services.AddScoped<DbContext, OrderContext>();

            var res = configuration.GetValue<string>("DatabaseSettings:ConnectionString");

            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer((configuration.GetValue<string>("DatabaseSettings:ConnectionString"))));

            services.AddScoped(typeof(IAsyncRepository<Order>), typeof(RepositoryBase<Order, OrderContext>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            // services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}
