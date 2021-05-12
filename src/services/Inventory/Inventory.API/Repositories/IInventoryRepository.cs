using Inventory.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.API.Repositories
{
    /// <summary>
    /// Contract for <seealso cref="InventoryRepository"/> class.
    /// </summary>
    public interface IInventoryRepository
    {
        Task CreateAsync(InventoryItem entity);
        Task RemoveAsync(Guid id);
        Task<InventoryItem> GetItemAsync(Guid id);
        Task<IReadOnlyCollection<InventoryItem>> GetAllIAsync();
        Task UpdateAsync(InventoryItem entity);
    }
}
