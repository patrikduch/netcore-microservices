using MongoDB.Driver;
using NetMicroservices.Common.Databases.Mongodb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMicroservices.Common.Databases.mongodb
{
    /// <summary>
    /// Generic repository for common mongodb entities.
    /// </summary>
    public class MongoRepository<T> : IMongoRepository<T> where T : IMongoEntity
    {
        private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;
        private readonly IMongoContext<T> _mongoCtx;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="MongoRepository{T}"/> class.
        /// </summary>
        /// <param name="mongoContext">Dependency for <seealso cref="IMongoContext{T}"/> class.</param>
        public MongoRepository(IMongoContext<T> mongoContext)
        {
            _mongoCtx = mongoContext;
        }

        /// <summary>
        /// Create a brand new item of particular mongodb entity.
        /// </summary>
        /// <param name="entity">Newly created data entry.</param>
        /// <returns>Asynchronous task.</returns>
        public async Task CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _mongoCtx.Collection.InsertOneAsync(entity);
        }

        /// <summary>
        /// Get all items of particular mongodb entity.
        /// </summary>
        /// <returns>Async task with all items from Mongodb.</returns>
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _mongoCtx.Collection.Find(_filterBuilder.Empty).ToListAsync();
        }

        /// <summary>
        /// Get signle item of mongodb entity.
        /// </summary>
        /// <param name="id">Guid identifier of particular mongodb entity.</param>
        /// <returns>Async task with particular item from mongodb entity.</returns>
        public async Task<T> GetAsync(Guid id)
        {
            FilterDefinition<T> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            return await _mongoCtx.Collection.Find(filterDefinition).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Remove particular entity item from Mongodb.
        /// </summary>
        /// <param name="id">Guid identifier of particular mongo entity item.</param>
        /// <returns>Asynch task.</returns>
        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<T> filterDefinition = _filterBuilder.Eq(entity => entity.Id, id);
            await _mongoCtx.Collection.DeleteOneAsync(filterDefinition);
        }

        /// <summary>
        /// Update mongo entity item.
        /// </summary>
        /// <param name="entity">Data that will be projected into persistent storage.</param>
        /// <returns>Async task.</returns>
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<T> filter = _filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await _mongoCtx.Collection.ReplaceOneAsync(filter, entity);
        }
    }
}
