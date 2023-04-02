//---------------------------------------------------------------------------
// <copyright file="CategoryReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.Readers;

using Application.Categories.Dtos;
using AutoMapper;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Readers;
using System.Collections.Generic;

/// <summary>
/// CategoryReader implementation class, that provides querying product's categories.
/// </summary>
public class CategoryReaderEf : ICategoryReaderEf
{
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="CategoryReaderEf"/>.
    /// </summary>
    /// <param name="mapper">Mapper dependency object.</param>
    /// <param name="productCtx"><seealso cref="DbContext"/> dependency object.</param>
    public CategoryReaderEf(IMapper mapper, ProductContext productCtx)
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
        if (_productContext.Categories is null)
        {
            return new List<CategoryDto>();
        }

        var categoriesQuery = _productContext.Categories
            .AsNoTracking();

        return await _mapper.ProjectTo<CategoryDto>(categoriesQuery).ToListAsync();
    }
}
