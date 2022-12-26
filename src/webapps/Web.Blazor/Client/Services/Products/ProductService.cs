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

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProductsAsync(string? categoryUrl=null)
    {
        ServiceResponse<List<Product>>? response = null;

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
}
