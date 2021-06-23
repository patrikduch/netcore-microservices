using Catalog.Application.Contracts;
using Catalog.Domain.Entities;
using NetMicroservices.MongoDbWrapper;

namespace Catalog.Persistence.Repositories
{
    /// <summary>
    /// Data repository implementation for products data access.
    /// </summary>
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="mongoCtx"></param>
        public ProductRepository(IMongoContext<Product> mongoCtx) : base(mongoCtx)
        {
        }
    }
}
