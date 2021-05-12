using Inventory.API.Dtos;
using Inventory.API.Entities;
using Inventory.API.Extensions;
using Inventory.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public ItemsController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAllAsync()
        {
            var items = (await _inventoryRepository.GetAllIAsync())
               .Select(item => item.AsDto());

            return Ok(items);
        }

        [HttpGet]
        [Route("/api/[controller]/{userId}")]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAsync(Guid userId)
        {

            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            var items = (await _inventoryRepository.GetAllIAsync(item => item.UserId == userId))
               .Select(item => item.AsDto());

            return Ok(items);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(GrantItemsDto grantItemsDto)
        {
            // find the inventory items if is there...
            var inventoryItems = await _inventoryRepository.GetItemAsync(
                item => item.UserId == grantItemsDto.UserId && item.CatalogItemId == grantItemsDto.CatalogItemId);

            // first time we assigned item to the user...
            if (inventoryItems  == null)
            {
                inventoryItems = new InventoryItem { 
                
                    CatalogItemId = grantItemsDto.CatalogItemId,
                    UserId = grantItemsDto.UserId,
                    Quantity = grantItemsDto.Quantity,
                    AcquiredDate = DateTimeOffset.UtcNow
                };

                // create a brand new inventory item...
                await _inventoryRepository.CreateAsync(inventoryItems);

            } else // we did find inventory => update quantity
            {
                inventoryItems.Quantity += grantItemsDto.Quantity;
                await _inventoryRepository.UpdateAsync(inventoryItems);
            }

            return Ok();
        }


        [HttpDelete("/api/[controller]/{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {

            var existingItem = await _inventoryRepository.GetItemAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            await _inventoryRepository.RemoveAsync(existingItem.Id);

            return NoContent();
        }
    }
}
