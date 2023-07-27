// <copyright file="ProductService.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.ApiServices;

using Constants;
using Models;
using NetMicroservices.ServiceConfig.Nuget;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductAsync(Guid id)
    {
        var apiGwClient = _clientFactory.CreateClient(HttpClientConstants.ApiGwHttpClientName);
        var request = new HttpRequestMessage(HttpMethod.Get, "/products");

        var response = await apiGwClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

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
