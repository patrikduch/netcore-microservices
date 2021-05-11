using Inventory.API.Dtos;
using Inventory.API.Entities;

namespace Inventory.API.Extensions
{
    public static class InventoryExtensions
    {
        public static InventoryItemDto AsDto(this InventoryItem item)
        {
            return new InventoryItemDto(item.CatalogItemId, item.Quantity, item.AcquiredDate);
        }
    }
}
