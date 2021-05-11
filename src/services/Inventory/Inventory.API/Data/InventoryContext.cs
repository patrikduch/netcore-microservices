using Inventory.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Inventory.API.Data
{
    /// <summary>
    /// Implementation of a database context for inventory data manipulations.
    /// </summary>
    public class InventoryContext : IInventoryContext
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="GameCatalogContext"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object that is derived from appsettings.json file.</param>
        public InventoryContext(IConfiguration configuration, IMongoDatabase mongoDb)
        {
            InventoryItems = mongoDb.GetCollection<InventoryItem>(configuration.GetValue<string>("MongoDbSettings:CollectionName"));
            // GameCatalogSeed.SeedData(GameItems);
        }

        public IMongoCollection<InventoryItem> InventoryItems { get; }
    }
}
