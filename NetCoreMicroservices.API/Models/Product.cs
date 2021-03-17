using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreMicroservices.API.Models
{
    /// <summary>
    /// MongoDb product model.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets product identifier.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets product category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets product's thumbnail.
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// Gets or sets product total price.
        /// </summary>
        public decimal Price { get; set; }
    }
}
