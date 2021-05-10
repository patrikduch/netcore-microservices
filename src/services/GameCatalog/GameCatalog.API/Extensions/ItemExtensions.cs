using GameCatalog.API.Entities;

namespace GameCatalog.API.Extensions
{
    /// <summary>
    /// Extension methods for Item entity transformations.
    /// </summary>
    public static class ItemExtensions
    {
        /// <summary>
        /// Convertion of  <seealso cref="GameItem"/> entity into  <seealso cref="GameItemDto"/>.
        /// </summary>
        /// <param name="item"><seealso cref="GameItem"/> that will be transfomed into  <seealso cref="GameItemDto"/>.</param>
        /// <returns>Data-transfer object  <seealso cref="GameItemDto"/>.</returns>
        public static GameItemDto AsDto(this GameItem item)
        {
            return new GameItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}
