//---------------------------------------------------------------------------
// <copyright file="CategoryReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Categories.Readers;

using Dtos;
using Interfaces;

/// <summary>
/// Data reader for product's categories.
/// </summary>
public class CategoryReader : ICategoryReader
{
    private readonly ICategoryReaderEf _categoryReaderEf;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="CategoryReader"/>.
    /// </summary>
    /// <param name="categoryReaderEf"><seealso cref="ICategoryReaderEf"/> object dependency.</param>
    public CategoryReader(ICategoryReaderEf categoryReaderEf)
    {
        _categoryReaderEf = categoryReaderEf;
    }

    /// <summary>
    /// Get category list without restrictions.
    /// </summary>
    /// <returns>Collection of <seealso cref="CategoryDto"/> objects.</returns>
    public Task<List<CategoryDto>> GetCategoryList()
    {
        return _categoryReaderEf.FetchCategoryList();
    }
}
