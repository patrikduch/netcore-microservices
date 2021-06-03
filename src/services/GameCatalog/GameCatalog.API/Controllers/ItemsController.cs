using GameCatalog.API.Entities;
using GameCatalog.API.Extensions;
using GameCatalog.API.Repositories;
using GameCatalog.RabbitMq;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IGameCatalogRepository _itemsRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ItemsController"/> class.
        /// </summary>
        /// <param name="itemsRepository">Dependency of Mongodb context for accessing all gamecatalog objects.</param>
        /// <param name="publishEndpoint">Dependency that enables publish functionality for RabbitMQ service bus.</param>
        public ItemsController(IGameCatalogRepository itemsRepository, IPublishEndpoint publishEndpoint)
        {
            _itemsRepository = itemsRepository;
            _publishEndpoint = publishEndpoint;
        }

        // GET /items/
        [HttpGet]
        public async Task<IEnumerable<GameItemDto>> GetAllAsync()
        {
            var items = (await _itemsRepository.GetAllItemsAsync())
                .Select(item => item.AsDto());

            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GameItemDto>> GetByIdAsync(Guid id)
        {
            var item = await _itemsRepository.GetItemAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items/{id}
        [HttpPost("{id}")]
        public async Task<ActionResult<GameItemDto>> PostAsync(CreateGameItemDto dto)
        {
            var item = new GameItem
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _itemsRepository.CreateItemAsync(item);

            // Publish message to the RabbitMQ    
            await _publishEndpoint.Publish(new GameCatalogItemUCreated(item.Id, item.Name, item.Description));


            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateGameItemDto updatedItemDto)
        {
            var existingItem = await _itemsRepository.GetItemAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updatedItemDto.Name;
            existingItem.Description = updatedItemDto.Description;
            existingItem.Price = updatedItemDto.Price;

            await _itemsRepository.UpdateItemAsync(existingItem);


            // Publish message to the RabbitMQ    
            await _publishEndpoint.Publish(new GameCatalogItemUpdated(existingItem.Id, existingItem.Name, existingItem.Description));

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existingItem = await _itemsRepository.GetItemAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            await _itemsRepository.RemoveItemAsync(existingItem.Id);

            // Publish message to the RabbitMQ    
            await _publishEndpoint.Publish(new GameCatalogItemDeleted(existingItem.Id));

            return NoContent();
        }
    }
}
