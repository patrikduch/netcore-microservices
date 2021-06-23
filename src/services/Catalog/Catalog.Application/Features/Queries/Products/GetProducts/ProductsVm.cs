using MongoDB.Bson.Serialization.Attributes;
using System;
using Catalog.Domain.Entities;

namespace Catalog.Application.Features.Queries.Products.GetProducts
{
    /// <summary>
    /// View model class for <seealso cref="Product"/> mediator design pattern.
    /// </summary>
    public class ProductsVm
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets product's name.
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets product's category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets product's summary information.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets product's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets product's image file.
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// Gets or sets product's price.
        /// </summary>
        public decimal Price { get; set; }
    }
}
