using GameCatalog.API.Entities;
using MongoDB.Driver;

namespace GameCatalog.API.Data
{
    /// <summary>
    /// Contract for data accessor context <seealso cref="ItemsContext"/>.
    /// </summary>
    public interface IItemsContext
    {
        IMongoCollection<Item> Items { get; }
    }
}
