using Inventory.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        Task<InventoryItem> GetItemAsync(Expression<Func<InventoryItem, bool>> filter);
        Task<IReadOnlyCollection<InventoryItem>> GetAllIAsync();
        Task<IReadOnlyCollection<InventoryItem>> GetAllIAsync(Expression<Func<InventoryItem, bool>> filter);
        Task UpdateAsync(InventoryItem entity);
    }
}
