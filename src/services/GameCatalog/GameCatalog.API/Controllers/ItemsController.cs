using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> _items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of  HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amout of damage", 20, DateTimeOffset.UtcNow),
        };


        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return _items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item = _items.Where(i => i.Id == id).SingleOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST /items/{id}
        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto dto)
        {
            var item = new ItemDto(Guid.NewGuid(), dto.Name, dto.Description, dto.Price, DateTimeOffset.UtcNow);
            _items.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateItemDto dto)
        {
            var existingItem = _items.Where(item => item.Id == id).SingleOrDefault();

            if (existingItem == null)
            {
                return NotFound();
            }

            var updatedItem = existingItem with
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };

            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            _items[index] = updatedItem;

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);

            if (index < 0)
            {
                return NotFound();
            }

            _items.RemoveAt(index);
            
            return NoContent();
        }

    }
}
