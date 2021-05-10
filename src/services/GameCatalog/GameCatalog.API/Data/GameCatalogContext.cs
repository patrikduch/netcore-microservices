using GameCatalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace GameCatalog.API.Data
{
    /// <summary>
    /// Implementation of a database context for game-catalog data manipulations.
    /// </summary>
    public class GameCatalogContext : IGameCatalogContext
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="GameCatalogContext"/> class.
        /// </summary>
        /// <param name="configuration">Configuration object that is derived from appsettings.json file.</param>
        public GameCatalogContext(IConfiguration configuration, IMongoDatabase mongoDb)
        {
            GameItems = mongoDb.GetCollection<GameItem>(configuration.GetValue<string>("MongoDbSettings:CollectionName"));
            GameCatalogSeed.SeedData(GameItems);
        }

        public IMongoCollection<GameItem> GameItems { get; }
    }
}
