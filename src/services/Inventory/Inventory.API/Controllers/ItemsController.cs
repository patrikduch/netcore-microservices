using AutoMapper;
using Inventory.API.Dtos;
using Inventory.API.Entities;
using Microsoft.AspNetCore.Mvc;
using NetMicroservices.MongoDbWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        /// <summary>
        /// Instance of a <seealso cref="InventoryRepository"/> for inventory data access via Repository pattern. 
        /// </summary>
        private readonly IMongoRepository<InventoryItem> _inventoryRepository;

        /// <summary>
        /// Instance of a <seealso cref="IMapper"/> that enables automapping functionality between objects. 
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <seealso cref="ItemsController"/> class.
        /// </summary>
        /// <param name="inventoryRepository">Dependency data repository for accessing list of inventory items.</param>
        /// <param name="mapper">Dependency for accessing functionality of Automapper library.</param>
        public ItemsController(IMongoRepository<InventoryItem> inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAllAsync()
        {
            var items = await _inventoryRepository.GetAllAsync();
            return Ok(_mapper.Map<IReadOnlyCollection<InventoryItem>, List<InventoryItemDto>>(items));
        }

        [HttpDelete("/api/[controller]/{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var existingItem = await _inventoryRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            await _inventoryRepository.RemoveAsync(existingItem.Id);

            return NoContent();
        }
    }
}
