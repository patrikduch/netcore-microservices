//---------------------------------------------------------------------------
// <copyright file="ICategoryReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Categories.Interfaces;

using Dtos;

/// <summary>
/// Contract for product categories management.
/// </summary>
public interface ICategoryReader
{
    Task<List<CategoryDto>> GetCategoryList();
}
