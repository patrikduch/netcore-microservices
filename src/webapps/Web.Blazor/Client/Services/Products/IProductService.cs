namespace Web.Blazor.Client.Services.Products;

using NetMicroservices.ServiceConfig.Nuget;
using Web.Blazor.Shared;

public interface IProductService
{
    public List<Product> Products { get; set; }
    
    public string Message { get; set; }
    
    Task GetProductsAsync(string? categoryUrl=null);

    Task<ServiceResponse<Product>> GetProductAsync(Guid id);

    Task SearchProducts(string searchText);

    Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
}
