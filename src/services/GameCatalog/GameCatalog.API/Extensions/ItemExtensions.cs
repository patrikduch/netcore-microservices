using GameCatalog.API.Entities;

namespace GameCatalog.API.Extensions
{
    /// <summary>
    /// Extension methods for Item entity transformations.
    /// </summary>
    public static class ItemExtensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}
