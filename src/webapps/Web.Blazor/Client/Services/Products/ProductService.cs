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

    public async Task GetProductsAsync()
    {
        var response = await _http.GetFromJsonAsync<List<Product>>("/products");


        if (response is not null)
        {
            Products = response.ToList();
        }
    }

    public async Task<ServiceResponse<Product>> GetProductAsync(Guid id)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"/products/{id}");
        return result;
    }
}
