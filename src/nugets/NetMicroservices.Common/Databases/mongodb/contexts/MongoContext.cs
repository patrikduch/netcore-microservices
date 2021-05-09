using MongoDB.Driver;
using NetMicroservices.Common.Databases.mongodb.contexts;
using System.Collections.Generic;

namespace NetMicroservices.Common.Databases.mongodb
{
    public class MongoContext<T> : IMongoContext<T>
    {
        public MongoContext(string collectionName, IMongoDatabase mongoDb, List<T> dataset)
        {
            Collection = mongoDb.GetCollection<T>(collectionName);
            MongoContextSeed<T>.SeedData(Collection, dataset);
        }

        public IMongoCollection<T> Collection { get; set; }
    }
}
