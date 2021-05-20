using MongoDB.Driver;

namespace NetMicroservices.MongoDbWrapper
{
    public interface IMongoContext<T>
    {
        IMongoCollection<T> Collection { get; }
    }
}
