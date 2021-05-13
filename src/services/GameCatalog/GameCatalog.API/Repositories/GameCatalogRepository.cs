using GameCatalog.API.Data;
using GameCatalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalog.API.Repositories
{
    /// <summary>
    /// Abstraction of game-catalog's data access. 
    /// </summary>
    public class GameCatalogRepository : IGameCatalogRepository
    {
        private readonly IGameCatalogContext _gameCatalogCtx;
        private readonly FilterDefinitionBuilder<GameItem> _filterBuilder = Builders<GameItem>.Filter;
        
        /// <summary>
        /// Initializes a new instance of the <seealso cref="GameCatalogRepository"/> class.
        /// </summary>
        /// <param name="gameCatalogCtx">Dependency of Mongodb context for accessing all gamecatalog objects.</param>
        public GameCatalogRepository(IGameCatalogContext gameCatalogCtx)
        {
            _gameCatalogCtx = gameCatalogCtx;
        }

        /// <summary>
        /// Get all items of Gamecatalog.
        /// </summary>
        /// <returns>Async task with all items from Gamecatalog.</returns>
        public async Task<IReadOnlyCollection<GameItem>> GetAllItemsAsync()
        {
            return await _gameCatalogCtx.GameItems.Find(_filterBuilder.Empty).ToListAsync();
        }

        /// <summary>
        /// Get item of Gamecatalog.
        /// </summary>
        /// <param name="id">Guid identifier of particular gamecatalog item.</param>
        /// <returns>Async task with particular item from Gamecatalog.</returns>
        public async Task<GameItem> GetItemAsync(Guid id)
        {
            FilterDefinition<GameItem> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            return await _gameCatalogCtx.GameItems.Find(filterDefinition).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Create an brand new item of GameCatalog.
        /// </summary>
        /// <param name="entity">Newly created data entry.</param>
        /// <returns>Asynchronous task.</returns>
        public async Task CreateItemAsync(GameItem entity)
        {

            if (entity == null)
            
                {throw new ArgumentNullException(nameof(entity));
            }

            await _gameCatalogCtx.GameItems.InsertOneAsync(entity);
        }

        /// <summary>
        /// Update game catalog item.
        /// </summary>
        /// <param name="entity">Data that will be projected into persistent storage.</param>
        /// <returns>Async task.</returns>
        public async Task UpdateItemAsync(GameItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<GameItem> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await _gameCatalogCtx.GameItems.ReplaceOneAsync(filter, entity);
        }

        /// <summary>
        /// Remove particular gamecatalog item.
        /// </summary>
        /// <param name="id">Guid identifier of particular gamecatalog item.</param>
        /// <returns>Asynch task.</returns>
        public async Task RemoveItemAsync(Guid id)
        {
            FilterDefinition<GameItem> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            await _gameCatalogCtx.GameItems.DeleteOneAsync(filterDefinition);
        }
    }
}
