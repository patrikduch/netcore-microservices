using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    /// <summary>
    /// Entity that represents set of products.
    /// </summary>
    public class Product
    {

        /// <summary>
        /// Gets or sets product's identifier.
        /// </summary>
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Category { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
}
