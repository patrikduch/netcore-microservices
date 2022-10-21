//---------------------------------------------------------------------------
// <copyright file="CategoryService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

using System.Net.Http.Json;
using Web.Blazor.Shared;

namespace Web.Blazor.Client.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public List<CategoryDto> Categories { get; set; } = new();
    
    public CategoryService(HttpClient http)
    {
        _httpClient = http;
    }

    public async Task GetCategoriesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("/categories");

        if (response is not null)
        {
            Categories = response;
        }
    }
}
