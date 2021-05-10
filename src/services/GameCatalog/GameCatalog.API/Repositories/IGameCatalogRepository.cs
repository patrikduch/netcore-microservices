using GameCatalog.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalog.API.Repositories
{
    /// <summary>
    /// Contract for data repository <seealso cref="GameCatalogRepository"/>.
    /// </summary>
    public interface IGameCatalogRepository
    {
        Task CreateItemAsync(GameItem entity);
        Task RemoveItemAsync(Guid id);
        Task<GameItem> GetItemAsync(Guid id);
        Task<IReadOnlyCollection<GameItem>> GetAllItemsAsync();
        Task UpdateItemAsync(GameItem entity);
    }
}
