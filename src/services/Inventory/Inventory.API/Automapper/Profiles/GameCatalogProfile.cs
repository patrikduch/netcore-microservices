using AutoMapper;
using Inventory.API.Dtos;

namespace Inventory.API.Automapper.Profiles
{
    /// <summary>
    /// Mapping scanner configuration for Inventory objects.
    /// </summary>
    public class InventoryItem : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="InventoryItem"/> class 
        /// and setup mapping configuration for  <seealso cref="Entities.InventoryItem"/>.
        /// </summary>
        public InventoryItem()
        {
            CreateMap<Entities.InventoryItem, InventoryItemDto>();
        }
    }
}
