using System;
using System.ComponentModel.DataAnnotations;

namespace GameCatalog.API
{
    /// <summary>
    /// Dto structure for listing a gamecatalog objects.
    /// </summary>
    public record GameItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    /// <summary>
    /// Dto structure for creating a brand new  gamecatalog objects.
    /// </summary>
    public record CreateGameItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal Price);
    /// <summary>
    /// Dto structure for updating an existing  gamecatalog objects.
    /// </summary>
    public record UpdateGameItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal Price);
}
