using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositiories
{
    
    /// <summary>
    /// Abstraction of product's data access. 
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogCtx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="catalogCtx">Dependency instance of Catalog context.</param>
        public ProductRepository(ICatalogContext catalogCtx)
        {
            _catalogCtx = catalogCtx ?? throw new ArgumentNullException(nameof(catalogCtx));
        }


        /// <summary>
        /// Insert a new product into database.
        /// </summary>
        /// <param name="product">New product data.</param>
        public async Task CreateProduct(Product product)
        {
            await _catalogCtx.Products.InsertOneAsync(product);
        }

        /// <summary>
        /// Remove a single product from database.
        /// </summary>
        /// <param name="id">Product entity identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _catalogCtx.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        /// <summary>
        /// Get product by it's id.
        /// </summary>
        /// <param name="id">String Mongodb object_id entity identifier.</param>
        /// <returns>Single product entity.</returns>
        public async Task<Product> GetProduct(string id)
        {

            return await _catalogCtx
                .Products.Find(p => true)
                .SingleOrDefaultAsync();
        }
        
        /// <summary>
        /// Get products by it's category.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns>List of products.</returns>
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, categoryName);

            return await _catalogCtx
                .Products.Find(filter)
                .ToListAsync();
        }

        /// <summary>
        /// Get products by it's name.
        /// </summary>
        /// <param name="name">Product name filter param.</param>
        /// <returns>List of products.</returns>
        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {

            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await _catalogCtx
                .Products.Find(filter)
                .ToListAsync();
        }

        /// <summary>
        /// Get list of all products.
        /// </summary>
        /// <returns>List of products.</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _catalogCtx
                .Products.Find(p => true)
                .ToListAsync();
        }
        /// <summary>
        /// Update selected product item.
        /// </summary>
        /// <param name="product">New product data.</param>
        /// <returns></returns>
        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _catalogCtx.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
