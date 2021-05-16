using System;

namespace MongoDbWrapper.Nuget
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
