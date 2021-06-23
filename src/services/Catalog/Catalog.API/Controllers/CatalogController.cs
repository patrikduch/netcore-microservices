using Catalog.Application.Features.Queries.Products.GetProducts;
using Catalog.Application.Features.Queries.Products.GetSingleProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetMicroservices.ServiceConfig.Nuget;
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
        private readonly IMediator _mediatR;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="CatalogController"/> class.
        /// </summary>
        public CatalogController(IMediator mediatR)
        {
            _mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<List<ProductsVm>>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Result<ProductsVm>>> GetProducts()
        {
            var query = new GetProductsQuery();
            var result = await _mediatR.Send(query);

            return Ok(result);
        }

       [HttpGet("{id}")]
       [ProducesResponseType((int)HttpStatusCode.NotFound)]
       [ProducesResponseType(typeof(Result<ProductVm>), (int)HttpStatusCode.OK)]
       public async Task<ActionResult<Result<ProductVm>>> GetProductById(Guid id)
       {
           var query = new GetProductQuery(id);
           var product = await _mediatR.Send(query);

           return Ok(product);
       }
       
        /*
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
        */

        /*

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreeateProduct([FromBody] Product product)
        {
            await _productRepository.CreateAsync(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        */

        /*
        [HttpPut]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            await _productRepository.UpdateAsync(product);
            return Ok(product);
        }

        */


        /*

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveProductById(Guid id)
        {
            await _productRepository.RemoveAsync(id);
            return Ok();
           
        }

        */
    }
}
