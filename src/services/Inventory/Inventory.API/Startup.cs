using Inventory.API.Clients;
using Inventory.API.Data;
using Inventory.API.Repositories;
using Inventory.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Polly;
using Polly.Timeout;
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

            var jitter = new Random();

            #region HTTP client
            services.AddHttpClient<IGameCatalogClient, GameCatalogClient>(client =>
            {
                client.BaseAddress = new Uri(serviceSettings.GameCatalogUrl);
            })

            #region Polly

                // Exponential backoff
                .AddTransientHttpErrorPolicy(builder => builder.Or<TimeoutRejectedException>().WaitAndRetryAsync(
                    3,
                    retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)) + TimeSpan.FromMilliseconds(jitter.Next(0, 1000)),
                    onRetry: (response, delay, retryCount, context) =>
                    {
                        Console.WriteLine("Exponential backoff");

                        var serviceProvider = services.BuildServiceProvider();
                        serviceProvider.GetService<ILogger<GameCatalogClient>>()?
                        .LogWarning($"Delaying for {delay.TotalSeconds} seconds, then making retry {retryCount}");
                    }
                 ))
                // Circuit breaker
                .AddTransientHttpErrorPolicy(builder => builder.Or<TimeoutRejectedException>().CircuitBreakerAsync(
                    3, // How many failed requests are requred to open Circuit Breaker
                    TimeSpan.FromSeconds(15), // How long will be "Circuit Breaker" in the open state
                    onBreak: (result, delay) =>
                    {
                        var serviceProvider = services.BuildServiceProvider();
                        serviceProvider.GetService<ILogger<GameCatalogClient>>()?
                        .LogWarning($"Opening the circuit for {delay.TotalSeconds} seconds");

                    },
                    onReset: () =>
                    {
                        var serviceProvider = services.BuildServiceProvider();
                        serviceProvider.GetService<ILogger<GameCatalogClient>>()?
                        .LogWarning($"Closing the circuit");
                    }
                 ))
                // Timeout 
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
