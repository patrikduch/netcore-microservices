using Catalog.Application.Contracts;
using Catalog.Domain.Entities;
using Catalog.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NetMicroservices.Configuration.Nuget;
using NetMicroservices.MongoDbWrapper;
using NetMicroservices.MongoDbWrapper.Settings;
using System.Collections.Generic;

namespace Catalog.Persistence
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
            var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            services.AddSingleton(serviceProvider =>
            {
                var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
                return mongoClient.GetDatabase(serviceSettings.ServiceName);
            });

            #region Data contexts

            services.AddScoped<IMongoContext<Product>>(x => new MongoContext<Product>(serviceSettings.ServiceName, x.GetService<IMongoDatabase>(), new List<Product>
            {
                new Product()
                {
                    Name = "IPhone",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },

                 new Product()
                {
                    Name = "Iphone 6S",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 80.00M,
                    Category = "Smart Phone by Patrik Duch"
                }
            }));

            #endregion

            #region Data repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            #endregion

    
            return services;
        }
    }
}
