//---------------------------------------------------------------------------
// <copyright file="CategoryReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.Readers;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Readers;
using Product.Application.Dtos;
using Product.Persistence.Contexts;
using System.Collections.Generic;

/// <summary>
/// CategoryReader implementation class, that provides quering product's categories.
/// </summary>
public class CategoryReader : ICategoryReader
{
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="CategoryReader"/>.
    /// </summary>
    /// <param name="mapper">Mapper depedency object.</param>
    /// <param name="productCtx"><seealso cref="DbContext"/> dependency object.</param>
    public CategoryReader(IMapper mapper, ProductContext productCtx)
    {
        _mapper = mapper;
        _productContext= productCtx;
    }

    /// <summary>
    /// Fetch list of all product categories.
    /// </summary>
    /// <returns>Collection of <seealso cref="CategoryDto"/> objects.</returns>
    public async Task<List<CategoryDto>>FetchCategoryList()
    {
        if (_productContext.Categories is not null)
        {
            var categories = await _productContext.Categories.ToListAsync();

            return _mapper.Map<List<CategoryDto>>(categories);
        }

        return Enumerable.Empty<CategoryDto>().ToList();
    }
}
