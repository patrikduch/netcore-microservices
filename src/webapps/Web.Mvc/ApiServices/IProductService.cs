namespace Web.Mvc.ApiServices;

public interface IProductService
{
    Task GetProductsAsync(string? categoryUrl = null);
}
