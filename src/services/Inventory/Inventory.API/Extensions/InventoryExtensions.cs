using Inventory.API.Dtos;
using Inventory.API.Entities;

namespace Inventory.API.Extensions
{
    /// <summary>
    /// Inventory arbitrary extensions.
    /// </summary>
    public static class InventoryExtensions
    {
        /// <summary>
        /// Convert entity IventoryItem to datatransfer object InventoryItemDto.
        /// </summary>
        /// <param name="item">Entity data that will be converted into data-transfer-object.</param>
        /// <returns></returns>
        public static InventoryItemDto AsDto(this InventoryItem item)
        {
            return new InventoryItemDto(item.Id, item.CatalogItemId, item.UserId, item.Quantity, item.AcquiredDate);
        }
    }
}
