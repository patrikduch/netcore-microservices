namespace Web.Blazor.Client.Services.Products;

using Web.Blazor.Shared;

public interface IProductService
{
    public List<Product> Products { get; set; }

    Task GetProductsAsync();
}
