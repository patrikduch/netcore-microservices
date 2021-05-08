using System;
using NetMicroservices.Common;

namespace GameCatalog.API.Entities
{
    /// <summary>
    /// Entity for representation gamecatalog item.
    /// </summary>
    public class Item : IMongoEntity
    {
        /// <summary>
        /// Gets or sets item entity identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets item's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets item's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets item's price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets item's created date-
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
    }
}
