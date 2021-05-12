using Inventory.API.Data;
using Inventory.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inventory.API.Repositories
{
    /// <summary>
    /// Abstraction of inventorie's data access management. 
    /// </summary>
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IInventoryContext _inventoryCtx;
        private readonly FilterDefinitionBuilder<InventoryItem> _filterBuilder = Builders<InventoryItem>.Filter;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="InventoryRepository"/> class.
        /// </summary>
        /// <param name="inventoryCtx">Dependency of Mongodb context for accessing all inventory objects.</param>
        public InventoryRepository(IInventoryContext inventoryCtx)
        {
            _inventoryCtx = inventoryCtx;
        }

        /// <summary>
        /// Create an brand new iventory item..
        /// </summary>
        /// <param name="entity">Newly created data iventory entry.</param>
        /// <returns>Asynchronous task.</returns>
        public async Task CreateAsync(InventoryItem entity)
        {
            if (entity == null)

            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _inventoryCtx.InventoryItems.InsertOneAsync(entity);
        }

        /// <summary>
        /// Get all items of inventory items.
        /// </summary>
        /// <returns>Async task with all inventory items.</returns>
        public async Task<IReadOnlyCollection<InventoryItem>> GetAllIAsync()
        {
            return await _inventoryCtx.InventoryItems.Find(_filterBuilder.Empty).ToListAsync();
        }

        /// <summary>
        /// Get all items of inventory items with additional InventoryItem based mongodb filter.
        /// </summary>
        /// <param name="filter">InventoryItem LINQ expression for listing restriction.</param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<InventoryItem>> GetAllIAsync(Expression<Func<InventoryItem, bool>> filter)
        {
            return await _inventoryCtx.InventoryItems.Find(filter).ToListAsync();
        }

        /// <summary>
        /// Get particular item from inventory list via InventoryItem provided expression, that limits entry selection.
        /// </summary>
        /// <param name="filter">InventoryItem LINQ expression for listing restriction.</param>
        /// <returns></returns>
        public async Task<InventoryItem> GetItemAsync(Expression<Func<InventoryItem, bool>> filter)
        {
            return await _inventoryCtx.InventoryItems.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get item of ïnventory data access mongodb collection.
        /// </summary>
        /// <param name="id">Guid identifier of particular inventory item.</param>
        /// <returns>Async task with particular item from inventory collection.</returns>
        public async Task<InventoryItem> GetItemAsync(Guid id)
        {
            FilterDefinition<InventoryItem> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            return await _inventoryCtx.InventoryItems.Find(filterDefinition).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Remove particular inventory item.
        /// </summary>
        /// <param name="id">Guid identifier of particular iventory item.</param>
        /// <returns>Asynch task.</returns>
        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<InventoryItem> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            await _inventoryCtx.InventoryItems.DeleteOneAsync(filterDefinition);
        }

        /// <summary>
        /// Update of an inventory item.
        /// </summary>
        /// <param name="entity">New inventory data that will be projected into persistent storage.</param>
        /// <returns>Async task.</returns>
        public async Task UpdateAsync(InventoryItem entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<InventoryItem> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await _inventoryCtx.InventoryItems.ReplaceOneAsync(filter, entity);
        }
    }
}
