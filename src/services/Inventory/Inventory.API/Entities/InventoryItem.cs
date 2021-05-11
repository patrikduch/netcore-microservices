using System;

namespace Inventory.API.Entities
{
    public class InventoryItem
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CatalogItemId { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset AcquiredDate { get; set; }
    }
}
