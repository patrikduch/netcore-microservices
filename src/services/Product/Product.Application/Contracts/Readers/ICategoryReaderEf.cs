//---------------------------------------------------------------------------
// <copyright file="ICategoryReaderEF.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Contracts.Readers;

using Product.Application.Categories.Dtos;

/// <summary>
/// Contract for CategoryReader implementation class, that provides querying product's category data.
/// </summary>
public interface ICategoryReaderEf
{
    Task<List<CategoryDto>> FetchCategoryList();
}
