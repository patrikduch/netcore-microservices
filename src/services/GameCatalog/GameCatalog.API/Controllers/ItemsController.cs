using GameCatalog.API.Entities;
using GameCatalog.API.Extensions;
using Microsoft.AspNetCore.Mvc;
// using NetMicroservices.Common.Databases.Mongodb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        // private readonly IMongoRepository<Item> _mongoRepository;

        /*
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ItemsController"/> class.
        /// </summary>
        /// <param name="mongoContext">Dependency for <seealso cref="IMongoRepository{T}"/> class.</param>
        public ItemsController(IMongoRepository<Item> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        // GET /items/
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = (await _mongoRepository.GetAllAsync())
                .Select(item => item.AsDto());

            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await _mongoRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items/{id}
        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto dto)
        {
            var item = new Item
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _mongoRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existingItem = await _mongoRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            await _mongoRepository.RemoveAsync(existingItem.Id);

            return NoContent();
        }

        */
    }
}
