using MongoDB.Driver;

namespace NetMicroservices.Common.Databases.mongodb
{
    public interface IMongoContext<T>
    {
        IMongoCollection<T> Collection { get; }
    }
}
