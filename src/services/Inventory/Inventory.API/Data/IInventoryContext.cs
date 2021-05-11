using Inventory.API.Entities;
using MongoDB.Driver;

namespace Inventory.API.Data
{
    /// <summary>
    /// Contract for data accessor context <seealso cref="InventoryContext"/>.
    /// </summary>
    public interface IInventoryContext
    {
        IMongoCollection<InventoryItem> InventoryItems { get; }
    }
}
