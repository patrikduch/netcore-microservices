using Inventory.API.Dtos;
using Inventory.API.Extensions;
using Inventory.API.Repositories;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<InventoryItemDto>> Get()
        {
            var items = (await _inventoryRepository.GetAllIAsync())
               .Select(item => item.AsDto());

            return Ok(items);
        }
    }
}
