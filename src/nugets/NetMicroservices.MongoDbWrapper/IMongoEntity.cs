using System;

namespace NetMicroservices.MongoDbWrapper
{
    /// <summary>
    /// Contract for all Mongodb entities.
    /// </summary>
    public interface IMongoEntity
    {
        /// <summary>
        /// Get or set mongo entity identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}
