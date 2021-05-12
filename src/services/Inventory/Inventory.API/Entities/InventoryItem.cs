using System;

namespace Inventory.API.Entities
{
    /// <summary>
    /// Entity for representation inventory items.
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// Gets or sets inventory item identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets unique identifier of assigned user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets unique identifier of assigned catalog item.
        /// </summary>
        public Guid CatalogItemId { get; set; }

        /// <summary>
        /// Gets or sets iventory quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets acquired date of particular inventory item.
        /// </summary>
        public DateTimeOffset AcquiredDate { get; set; }
    }
}
