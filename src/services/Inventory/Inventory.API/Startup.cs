using Inventory.API.Clients;
using Inventory.API.Data;
using Inventory.API.Repositories;
using Inventory.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace Inventory.API
{
    public class Startup
    {
        private ServiceSettings _serviceSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory.API", Version = "v1" });
            });

            #region Polly policy setup

            var retry = HttpPolicyExtensions.HandleTransientHttpError()
                  .WaitAndRetryAsync(3, retryCount => 
                        TimeSpan.FromSeconds(
                            Math.Pow(
                                2,
                                retryCount
                            )
                        ),
                  onRetry: (response, delay, retryCount, context) =>
                  {
                      var serviceProvider = services.BuildServiceProvider();
      
                  }
            );
            #endregion

            #region HTTP client
            services.AddHttpClient<IGameCatalogClient, GameCatalogClient>(client =>
            {
                client.BaseAddress = new Uri(serviceSettings.GameCatalogUrl);
            })
            #region Polly

                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(
                    3,
                    retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)),
                    onRetry: (response, delay, retryCount, context) =>
                    {
                        Console.WriteLine("Exponential backoff");
                    }
                 ))
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(1));  // wait one second before giving up

                #endregion

            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(Startup));
            #endregion

            #region Mongodb serializers
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
            #endregion

            // Deserealization config file into memory object.
            _serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            // Register type or object and make sure that only one instance is available
            services.AddSingleton(serviceProvider =>
            {

                var mongoDbSettings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

                return mongoClient.GetDatabase(_serviceSettings.ServiceName);
            });

            #region Data contexts
            services.AddScoped<IInventoryContext, InventoryContext>();
            #endregion

            #region Data repositories
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
