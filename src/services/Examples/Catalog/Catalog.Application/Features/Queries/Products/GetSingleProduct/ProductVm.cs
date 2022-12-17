using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Catalog.Application.Features.Queries.Products.GetSingleProduct
{
    public class ProductVm
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
