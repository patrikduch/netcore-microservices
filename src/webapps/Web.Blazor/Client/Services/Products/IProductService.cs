namespace Web.Blazor.Client.Services.Products;

using NetMicroservices.ServiceConfig.Nuget;
using Web.Blazor.Shared;

public interface IProductService
{
    event Action? ProductsChanged;
    
    public List<Product> Products { get; set; }

    Task GetProductsAsync(string? categoryUrl=null);

    Task<ServiceResponse<Product>> GetProductAsync(Guid id);
}
