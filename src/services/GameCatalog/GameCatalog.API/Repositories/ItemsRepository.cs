using GameCatalog.API.Data;
using GameCatalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalog.API.Repositories
{
    /// <summary>
    /// Abstraction of game-catalog item's data access. 
    /// </summary>
    public class ItemsRepository : IItemsRepository
    {
        private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
        private readonly IItemsContext _itemsContext;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ItemsRepository"/> class.
        /// </summary>
        /// <param name="itemsContext">Dependency for <seealso cref="IItemsContext"/> class.</param>
        public ItemsRepository(IItemsContext itemsContext)
        {
            _itemsContext = itemsContext;
        }

        /// <summary>
        /// Get all items of Gamecatalog.
        /// </summary>
        /// <returns>Async task with all items from Gamecatalog.</returns>
        public async Task<IReadOnlyCollection<Item>> GetAllItemsAsync()
        {
            return await _itemsContext.Items.Find(_filterBuilder.Empty).ToListAsync();
        }

        /// <summary>
        /// Get item of Gamecatalog.
        /// </summary>
        /// <param name="id">Guid identifier of particular gamecatalog item.</param>
        /// <returns>Async task with particular item from Gamecatalog.</returns>
        public async Task<Item> GetItemAsync(Guid id)
        {
            FilterDefinition<Item> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            return await _itemsContext.Items.Find(filterDefinition).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Create an brand new item of GameCatalog.
        /// </summary>
        /// <param name="entity">Newly created data entry.</param>
        /// <returns>Asynchronous task.</returns>
        public async Task CreateItemAsync(Item entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _itemsContext.Items.InsertOneAsync(entity);
        }

        /// <summary>
        /// Update game catalog item.
        /// </summary>
        /// <param name="entity">Data that will be projected into persistent storage.</param>
        /// <returns>Async task.</returns>
        public async Task UpdateItemAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Item> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await _itemsContext.Items.ReplaceOneAsync(filter, entity);
        }

        /// <summary>
        /// Remove particular gamecatalog item.
        /// </summary>
        /// <param name="id">Guid identifier of particular gamecatalog item.</param>
        /// <returns>Asynch task.</returns>
        public async Task RemoveItemAsync(Guid id)
        {
            FilterDefinition<Item> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            await _itemsContext.Items.DeleteOneAsync(filterDefinition);
        }
    }
}
