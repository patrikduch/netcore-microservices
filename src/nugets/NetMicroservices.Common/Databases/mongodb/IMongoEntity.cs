using System;

namespace NetMicroservices.Common.Databases.Mongodb
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
