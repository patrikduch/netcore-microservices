using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMicroservices.MongoDbWrapper
{
    /// <summary>
    /// Interface for all mongodb repositories.
    /// </summary>
    /// <typeparam name="T">Type of mongodb entity.</typeparam>
    public interface IMongoRepository<T> where T : IMongoEntity
    {
        Task CreateAsync(T entity);
        Task RemoveAsync(Guid id);
        Task<T> GetAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task UpdateAsync(T entity);
    }
}
