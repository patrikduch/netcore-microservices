using System;

namespace Inventory.API.Dtos
{
    public record GrantItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);

    public record InventoryItemDto(Guid id, Guid CatalogItemId, Guid UserId, int Quantity, DateTimeOffset AcquiredDate);
}
