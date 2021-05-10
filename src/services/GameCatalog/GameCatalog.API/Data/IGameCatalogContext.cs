using GameCatalog.API.Entities;
using MongoDB.Driver;

namespace GameCatalog.API.Data
{
    /// <summary>
    /// Contract for data accessor context <seealso cref="GameCatalogContext"/>.
    /// </summary>
    public interface IGameCatalogContext
    {
        IMongoCollection<GameItem> GameItems { get; }
    }
}
