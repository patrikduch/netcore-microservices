namespace Inventory.API.Settings
{
    /// <summary>
    /// Typed configuration class for accessing Service settings.
    /// </summary>
    public class ServiceSettings
    {
        /// <summary>
        /// Gets name of the microservice.
        /// </summary>
        public string ServiceName { get; init; }

        /// <summary>
        /// Gets url of "GameCatalog" microservice.
        /// </summary>
        public string GameCatalogUrl { get; init; }
    }
}
