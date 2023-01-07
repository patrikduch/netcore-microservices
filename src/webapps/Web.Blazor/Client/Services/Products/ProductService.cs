//---------------------------------------------------------------------------
// <copyright file="ProductService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Web.Blazor.Client.Services.Products;

using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Web.Blazor.Shared;

public class ProductService : IProductService
{
    private readonly HttpClient _http;
    
    public List<Product> Products { get; set; } = new();
    
    // For displaying no product has been found etc.
    public string Message { get; set; } = "Loading products...";

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProductsAsync(string? categoryUrl=null)
    {
        ServiceResponse<List<Product>>? response;

        if (categoryUrl is null) return;
        
        if (categoryUrl.Equals(null))
        {
            response = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("/products");    
        }
        else
        {
            response = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"/category-products/{categoryUrl}");
        }
        
        if (response is not null)
        {
            Products = response.Data.ToList();
        }
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(Guid id)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"/products/{id}");
        return result;
    }

    public async Task SearchProducts(string searchText)
    {
        var result = await _http
            .GetFromJsonAsync<ServiceResponse<List<Product>>>($"/product-search/{searchText}");
        
        if (result?.Data != null)
        {
            Products = result.Data;
        }

        if (Products.Count == 0)
        {
            Message = "No products found.";
        }
    }

    public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
    {
        var result = await _http
            .GetFromJsonAsync<ServiceResponse<List<string>>>($"/product-suggestions/{searchText}");

        return result;

    }
}
