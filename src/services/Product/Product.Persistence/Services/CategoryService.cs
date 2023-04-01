//-----------------------------------------------------------------------------------
// <copyright file="CategoryService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// ----------------------------------------------------------------------------------
namespace Product.Persistence.Services;

using Application.Dtos;
using Product.Application.Contracts.Readers;
using Product.Application.Contracts.Services;
using System.Collections.Generic;

/// <summary>
/// CategoryService provides CRUD functionality for product's category management.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly ICategoryReader _categoryReader;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="CategoryService"/>.
    /// </summary>
    /// <param name="categoryReader">CategoryReader dependency object.</param>
    public CategoryService(ICategoryReader categoryReader)
    {
        _categoryReader= categoryReader;
    }

    /// <summary>
    /// Get list of all available categories without any restrictions.
    /// </summary>
    /// <returns>List of <seealso cref="CategoryDto"/> objects.</returns>
    public async Task<List<CategoryDto>> GetCategoryList()
    {
        return await _categoryReader.FetchCategoryList();
    }
}
