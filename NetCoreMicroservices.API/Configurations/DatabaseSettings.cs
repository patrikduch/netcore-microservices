namespace NetCoreMicroservices.API.Configurations
{
    /// <summary>
    /// Arbitrary class that supports accessing to the database setting from appsettings.json file.
    /// </summary>
    public class DatabaseSettings
    {
        /// <summary>
        /// Gets or sets db connectionstring.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets MongoDb name.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets collection name for MongoDb database.
        /// </summary>
        public string CollectionName { get; set; }
    }
}
