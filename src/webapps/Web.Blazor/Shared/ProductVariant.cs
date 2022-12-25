namespace Web.Blazor.Shared;

public class ProductVariant
{
    public Guid Id { get; set; }
    
    public decimal Price { get; set; }

    public decimal OriginalPrice { get; set; }
}