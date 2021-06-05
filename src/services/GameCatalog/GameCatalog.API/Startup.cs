using GameCatalog.API.Entities;
using GameCatalog.API.Settings;
using MassTransit;
using MassTransit.Definition;
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
using RabbitMqWrapper.Nuget.Settings;
using System;
using System.Collections.Generic;

namespace GameCatalog.API
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

   
            services.AddControllers(options => {
                options.SuppressAsyncSuffixInActionNames = false;
            });


            var rabbitMqSettings = Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();

            



            #region Data contexts
            services.AddScoped<IMongoContext<GameItem>>(x => new MongoContext<GameItem>(_serviceSettings.ServiceName, x.GetService<IMongoDatabase>(), new List<GameItem>
            {
                new GameItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Potion",
                    Description = "Restores a small amount of  HP",
                    Price = 5,
                    CreatedDate = DateTimeOffset.UtcNow
                },
                new GameItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Antidote",
                    Description = "Cures poison",
                    Price = 7,
                    CreatedDate = DateTimeOffset.UtcNow
                },
                new GameItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Bronze sword",
                    Description = "Deals a small amout of damage",
                    Price = 20,
                    CreatedDate = DateTimeOffset.UtcNow
                },

            }));
            #endregion

            #region Data repositories
            services.AddScoped<IMongoRepository<GameItem>, MongoRepository<GameItem>>();
            #endregion


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameCatalog.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameCatalog.API v1"));
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