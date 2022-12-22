//-----------------------------------------------------------------------------------
// <copyright file="ProductService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// ----------------------------------------------------------------------------------
namespace Product.Persistence.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Services;
using Product.Application.Dtos;
using Product.Persistence.Contexts;
using System;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly ProductContext _productContext;
    

    public ProductService(IMapper mapper, ProductContext productContext)
    {
        _mapper = mapper;
        _productContext = productContext;
    }

    public  async Task<ProductDetailDto> GetProductDetail(Guid productId)
    {
        var products = await _productContext.Products
            .Where(p => p.Id == productId)
            .Include(p => p.ProductVariants)
                .ThenInclude(p => p.ProductType).FirstOrDefaultAsync();

        return _mapper.Map<ProductDetailDto>(products);
    }
}
