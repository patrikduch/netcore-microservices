using GameCatalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.API.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private const string _collectionName = "items";

        private readonly IMongoCollection<Item> _dbCollection;

        private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;

        public ItemsRepository(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = mongoClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            _dbCollection = database.GetCollection<Item>(_collectionName);
        }

        /// <summary>
        /// Get all items of Gamecatalog.
        /// </summary>
        /// <returns>Async task with all items from Gamecatalog.</returns>
        public async Task<IReadOnlyCollection<Item>> GetAllItemsAsync()
        {
            return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
        }

        /// <summary>
        /// Get item of Gamecatalog.
        /// </summary>
        /// <param name="id">Guid identifier of particular gamecatalog item.</param>
        /// <returns>Async task with particular item from Gamecatalog.</returns>
        public async Task<Item> GetItemAsync(Guid id)
        {
            FilterDefinition<Item> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            return await _dbCollection.Find(filterDefinition).FirstOrDefaultAsync();
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

            await _dbCollection.InsertOneAsync(entity);
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
            await _dbCollection.ReplaceOneAsync(filter, entity);
        }

        /// <summary>
        /// Remove particular gamecatalog item.
        /// </summary>
        /// <param name="id">Guid identifier of particular gamecatalog item.</param>
        /// <returns>Asynch task.</returns>
        public async Task RemoveItemAsync(Guid id)
        {
            FilterDefinition<Item> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            await _dbCollection.DeleteOneAsync(filterDefinition);
        }
    }
}
