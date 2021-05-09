using MongoDB.Driver;
using System.Collections.Generic;

namespace NetMicroservices.Common.Databases.mongodb.contexts
{
    public class MongoContextSeed<T> : IMongoContextSeed<T>
    {
        /// <summary>
        /// Seed data of static entity items.
        /// </summary>
        /// <param name="collection">MongoDb collection</param>
        public static void SeedData(IMongoCollection<T> collection, List<T> dataset)
        {
            bool entityExists = collection.Find(p => true).Any();

            if (!entityExists)
            {
                collection.InsertManyAsync(GetPreConfiguredEntities(dataset));
            }
        }

        /// <summary>
        /// Static list of preconfigured entity items.
        /// </summary>
        /// <returns>List of preconfigurated items.</returns>
        private static List<T> GetPreConfiguredEntities(List<T> list)
        {
            return list;
        }
    }
}
