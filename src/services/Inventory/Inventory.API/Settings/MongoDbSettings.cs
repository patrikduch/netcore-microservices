namespace Inventory.API.Settings
{
    /// <summary>
    /// Typed configuration class for accessing MongoDb settings.
    /// </summary>
    public class MongoDbSettings
    {
        /// <summary>
        /// Gets name of MongoDb.
        /// </summary>
        public string DatabaseName { get; init; }

        /// <summary>
        /// Gets collection name for specified entity.
        /// </summary>
        public string CollectionName { get; init; }

        /// <summary>
        /// Gets hostname of particular MongoDb.
        /// </summary>
        public string Host { get; init; }

        /// <summary>
        /// Gets username for connection to the Mongodb.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets password for connection to the Mongodb. 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets port of particular Mongodb.
        /// </summary>
        public string Port { get; init; }

        /// <summary>
        /// Get connection string that is determinated from properties "Host" and "Port".
        /// </summary>
        public string ConnectionString
        {
            get
            {
                if (Username == null || Password == null)
                {
                    return $"mongodb://{Host}:{Port}";
                }

                return $"mongodb://{Username}:{Password}@{Host}:{Port}";
            }
        }
    }
}
