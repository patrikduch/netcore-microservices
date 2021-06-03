using AutoMapper;
using Inventory.API.Clients;
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
        /// <summary>
        /// Instance of a <seealso cref="InventoryRepository"/> for inventory data access via Repository pattern. 
        /// </summary>
        private readonly IInventoryRepository _inventoryRepository;

        /// <summary>
        /// Instance of a <seealso cref="IMapper"/> that enables automapping functionality between objects. 
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ItemsController"/> class.
        /// </summary>
        /// <param name="inventoryRepository">Dependency data repository for accessing list of inventory items.</param>
        /// <param name="mapper">Dependency for accessing functionality of Automapper library.</param>
        public ItemsController(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAllAsync()
        {
            var items = await _inventoryRepository.GetAllIAsync();
            return Ok(_mapper.Map<IReadOnlyCollection<InventoryItem>, List<InventoryItemDto>>(items));
        }

        [HttpGet]
        [Route("/api/[controller]/{userId}")]
        public async Task<ActionResult<IEnumerable<GameCatalogItemDto>>> GetAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }

            /*

            // Synchronous call to the microservice "GameCatalog".
            var catalogItems = await _gameCatalogClient.GetCatalogItemsAsync();

            // Filter the inventory items based on user id
            var inventoryItems = (await _inventoryRepository.GetAllIAsync(
                item => item.UserId == userId));

            // Compose gamecatalog and inventory data into single object.
            var inventoryItemsDtos = inventoryItems.Select(inventoryItem =>
            {
                var catalogItem = catalogItems.Single(c => c.Id == inventoryItem.CatalogItemId);
                return inventoryItem.AsDto(catalogItem.Name, catalogItem.Description); 
            });

            */

            //return Ok(inventoryItemsDtos);

            return Ok();
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

            } else // we did find inventory => so we update quantity count.
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
