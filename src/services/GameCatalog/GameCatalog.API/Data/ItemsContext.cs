using GameCatalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace GameCatalog.API.Data
{
    /// <summary>
    /// Implementation of a database context for game-catalog data manipulations.
    /// </summary>
    public class ItemsContext : IItemsContext
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ItemsContext"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object that is derived from appsettings.json file.</param>
        public ItemsContext(IConfiguration configuration, IMongoDatabase mongoDb)
        {
            Items = mongoDb.GetCollection<Item>(configuration.GetValue<string>("MongoDbSettings:CollectionName"));
            ItemsContextSeed.SeedData(Items);
        }

        public IMongoCollection<Item> Items { get; }
    }
}
