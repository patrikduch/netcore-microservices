using Catalog.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetMicroservices.MongoDbWrapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMongoRepository<Product> _productRepository;
        private readonly ILogger<CatalogController> _logger;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="CatalogController"/> class.
        /// </summary>
        /// <param name="productRepository">Dependency for <seealso cref="ProductRepository"/> class.</param>
        /// <param name="logger">Dependency for <seealso cref="ILogger"/> class.</param>
        public CatalogController(IMongoRepository<Product> productRepository, ILogger<CatalogController> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                _logger.LogError($"Product with id {id}, not found");
            }

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreeateProduct([FromBody] Product product)
        {
            await _productRepository.CreateAsync(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            await _productRepository.UpdateAsync(product);
            return Ok(product);
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveProductById(Guid id)
        {
            await _productRepository.RemoveAsync(id);
            return Ok();
           
        }
    }
}
