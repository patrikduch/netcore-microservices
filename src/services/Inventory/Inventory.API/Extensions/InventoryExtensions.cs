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
        /// Convert entity InventoryItem to datatransfer object GameCatalogItemDto.
        /// </summary>
        /// <param name="item">Entity data that will be converted into data-transfer-object.</param>
        /// <returns></returns>
        public static GameCatalogItemDto AsDto(this InventoryItem item, string name, string description)
        {
            return new GameCatalogItemDto(item.Id, name, description);
        }
    }
}
