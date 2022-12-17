using System;

namespace Inventory.API.Dtos
{
    public record GrantItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);

    public record InventoryItemDto(Guid id, Guid CatalogItemId, Guid UserId, int Quantity, DateTimeOffset AcquiredDate);

    /// <summary>
    /// Dto structure for listing a gamecatalog objects.
    /// </summary>
    public record GameCatalogItemDto(Guid Id, string Name, string Description);

}
