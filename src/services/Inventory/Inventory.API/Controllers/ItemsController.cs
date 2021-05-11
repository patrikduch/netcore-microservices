using Inventory.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IInventoryContext _inventoryContext;

        public ItemsController(IInventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();

        }
    }
}
