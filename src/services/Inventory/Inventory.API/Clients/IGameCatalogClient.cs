using Inventory.API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.API.Clients
{
    /// <summary>
    /// Contract for synchronous via HTTP client with GameCatalog microservice.
    /// </summary>
    public interface IGameCatalogClient
    {
        Task<IReadOnlyCollection<GameCatalogItemDto>> GetCatalogItemsAsync();
    }
}
