namespace Product.Persistence.Readers;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Readers;
using Product.Application.Dtos;
using Product.Persistence.Contexts;
using System.Collections.Generic;

public class CategoryReader : ICategoryReader
{
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    public CategoryReader(IMapper mapper, ProductContext productCtx)
    {
        _mapper = mapper;
        _productContext= productCtx;
    }

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
