using Inventory.API.Entities;
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
using NetMicroservices.MongoDbWrapper;
using NetMicroservices.MongoDbWrapper.Settings;
using NetMicroservices.RabbitMqWrapper.Nuget;
using System.Collections.Generic;

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
            _serviceSettings = Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

            #region MVC
            services.AddControllers();
            #endregion

            #region RabbitMQ (MassTransit)
            services.AddMassTransitWithRabbitMq(_serviceSettings.ServiceName);
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory.API", Version = "v1" });
            });


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
            services.AddScoped<IMongoContext<InventoryItem>>(x => new MongoContext<InventoryItem>(_serviceSettings.ServiceName, x.GetService<IMongoDatabase>(), new List<InventoryItem>
            {
            }));
            #endregion

            #region Data repositories
            services.AddScoped<IMongoRepository<InventoryItem>, MongoRepository<InventoryItem>>();
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
