using Inventory.API.Dtos;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Inventory.API.Clients
{
    /// <summary>
    /// Client synchronous communication with GameCatalog microservice.
    /// </summary>
    public class GameCatalogClient : IGameCatalogClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GameCatalogClient> _logger;

        public GameCatalogClient(HttpClient httpClient, ILogger<GameCatalogClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
         
        /// <summary>
        /// Get synchronously gamecatalog items for particular inventory object.
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<GameCatalogItemDto>> GetCatalogItemsAsync()
        {
            IReadOnlyCollection<GameCatalogItemDto> items = null;

            try
            {
                items = await _httpClient.GetFromJsonAsync<IReadOnlyCollection<GameCatalogItemDto>>("/api/items");

            } catch(HttpRequestException ex)
            {
                _logger.LogError("Synchronous call to GameCatalog microservices has failed.", ex.ToString());
            }
             
            return items;
        }
    }
}
