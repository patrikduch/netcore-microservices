using Catalog.API.Entities;
using Catalog.API.Settings;
using Catalog.API.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using NetMicroservices.MongoDbWrapper;
using System;
using System.Collections.Generic;

namespace Catalog.API
{
    public class Startup
    {
        private ILogger<Startup> _logger;
        private ServiceSettings _serviceSettings;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

          
            services.AddSignalR(hubOptions => {

                hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(45);

            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
            });

            services.AddSingleton(serviceProvider =>
            {
                try {

                    var mongoDbSettings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

                    _logger.LogInformation("Connection setup...");
                    _logger.LogError(mongoDbSettings.CollectionName);
                    _logger.LogError(mongoDbSettings.DatabaseName);
                    _logger.LogError(mongoDbSettings.Username);
                    _logger.LogError(mongoDbSettings.Password);

                    _logger.LogError(mongoDbSettings.ConnectionString);

                    var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

                    _logger.LogInformation("Connection string...");
                    _logger.LogInformation(mongoDbSettings.ConnectionString);

                    return mongoClient.GetDatabase(_serviceSettings.ServiceName);

                } catch (Exception ex)
                {
                    _logger.LogError("Mongodb setup failed...");
                    _logger.LogError(ex.ToString());

                    return null;
                }
            });

            #region Data contexts
            services.AddScoped<IMongoContext<Product>>(x => new MongoContext<Product>("products", x.GetService<IMongoDatabase>(), new List<Product>
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
            services.AddScoped<IMongoRepository<Product>, MongoRepository<Product>>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
            }

  
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthorization();

  
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<TestHub>("/hubs/test");
                endpoints.MapControllers();
            });
        }
    }
}
