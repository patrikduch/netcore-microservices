namespace Web.Mvc.ApiServices;

using Models;
using NetMicroservices.ServiceConfig.Nuget;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("MyClient");
    }


    public async Task<ServiceResponse<List<Product>>> GetProductAsync(Guid id)
    {
        var response = await _httpClient.GetAsync("products");

        if (response.IsSuccessStatusCode)
        {
            var productData = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Product>>>();

            return productData;
        }
        else
        {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}
