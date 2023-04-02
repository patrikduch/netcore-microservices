//---------------------------------------------------------------------------
// <copyright file="ICategoryService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Contracts.Services;

using Product.Application.Categories.Dtos;

/// <summary>
/// Contract for CategoryService, that provides all functionality for reading and mutating product's category data.
/// </summary>
public interface ICategoryService
{
    public Task<List<CategoryDto>> GetCategoryList();
}
