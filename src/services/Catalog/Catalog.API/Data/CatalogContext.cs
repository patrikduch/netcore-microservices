using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    /// <summary>
    /// Implementation of a database context for catalog data manipulations.
    /// </summary>
    public class CatalogContext : ICatalogContext
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="CatalogContext"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object that is derived from appsettings.json file.</param>
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
