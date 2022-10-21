//---------------------------------------------------------------------------
// <copyright file="ICategoryService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

using Web.Blazor.Shared;

namespace Web.Blazor.Client.Services.Category;

public interface ICategoryService
{
    List<CategoryDto> Categories { get; set;}
    Task GetCategoriesAsync();
}
