using System;

namespace NetMicroservices.Common.Databases.Mongodb
{
    /// <summary>
    /// Contract for all Mongodb entities.
    /// </summary>
    public interface IMongoEntity
    {
        public Guid Id { get; set; }
    }
}
