//---------------------------------------------------------------------------
// <copyright file="ICategoryReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
using Product.Application.Dtos;

namespace Product.Application.Contracts.Readers;

/// <summary>
/// Contract for CategoryReader implementation class, that provides quering product's category data.
/// </summary>
public interface ICategoryReader
{
    Task<List<CategoryDto>> FetchCategoryList();
}
