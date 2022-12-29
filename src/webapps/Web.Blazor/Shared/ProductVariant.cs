namespace Web.Blazor.Shared;

public class ProductVariant
{
    public Guid Id { get; set; }

    public Guid ProductTypeId { get; set; }

    public decimal Price { get; set; }

    public decimal OriginalPrice { get; set; }

    public ProductType ProductType { get; set; } = new();
}