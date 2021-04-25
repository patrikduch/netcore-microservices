using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    /// <summary>
    /// Contract for data accessor context <seealso cref="CatalogContext"/>.
    /// </summary>
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
