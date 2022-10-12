namespace Product.Domain.Entities;

/// <summary>
/// Entity that represents set of products.
/// </summary>
public class ProductEntity
{
    /// <summary>
    /// Gets or sets product identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product imageUrl.
    /// </summary>
    public string ImgUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product price.
    /// </summary>
    public decimal Price { get; set; }
}
