using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace NetMicroservices.MongoDbWrapper
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
