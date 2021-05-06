using GameCatalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalog.API.Repositories
{
    /// <summary>
    /// Contract for data repository <seealso cref="ItemsRepository"/>.
    /// </summary>
    public interface IItemsRepository
    {
        Task CreateItemAsync(Item entity);
        Task RemoveItemAsync(Guid id);
        Task<Item> GetItemAsync(Guid id);
        Task<IReadOnlyCollection<Item>> GetAllItemsAsync();
        Task UpdateItemAsync(Item entity);
    }
}
