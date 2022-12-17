using Catalog.Domain.Entities;
using NetMicroservices.MongoDbWrapper;

namespace Catalog.Application.Contracts
{
    /// <summary>
    /// Contract for product's data repository.
    /// </summary>
    public interface IProductRepository : IMongoRepository<Product>
    {

    }
}
