namespace Web.Blazor.Client.Services.Products;

using NetMicroservices.ServiceConfig.Nuget;
using Web.Blazor.Shared;

public interface IProductService
{
    public List<Product> Products { get; set; }

    Task GetProductsAsync();

    Task<ServiceResponse<Product>> GetProductAsync(Guid id);
}
