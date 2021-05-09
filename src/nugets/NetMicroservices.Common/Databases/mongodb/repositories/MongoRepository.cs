using NetMicroservices.Common.Databases.Mongodb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetMicroservices.Common.Databases.mongodb
{
    public class MongoRepository<T> : IMongoRepository<T> where T : IMongoEntity
    {
        private readonly IMongoContext<T> _mongoCtx;

        public MongoRepository(IMongoContext<T> mongoContext)
        {
            _mongoCtx = mongoContext;
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
