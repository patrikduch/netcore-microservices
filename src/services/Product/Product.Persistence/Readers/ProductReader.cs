﻿//---------------------------------------------------------------------------
// <copyright file="ProductReader.cs" website="Patrikduch.com">
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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

///  ProductReader implementation class, that provides quering product data.
public class ProductReader : IProductReader
{
    private readonly IMapper _mapper;
    private readonly ProductContext _productCtx;

    public ProductReader(IMapper mapper, ProductContext productCtx)
    {
        _mapper= mapper;
        _productCtx= productCtx;
    }

    public async Task<ProductDetailDto> FetchProductDetail(Guid productId)
    {
        var products = await _productCtx.Products
            .Where(p => p.Id == productId)
            .AsNoTracking()
            .Include(p => p.ProductVariants)
                .ThenInclude(p => p.ProductType).FirstOrDefaultAsync();

        return _mapper.Map<ProductDetailDto>(products);
    }

    public async Task<List<ProductDto>> FetchProducts()
    {
        var products = await _productCtx.Products
           .AsNoTracking()
           .Include(p => p.ProductVariants).ToListAsync();

        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<List<ProductDto>> FetchProducts(string categoryUrl)
    {
        var productsByCategoryUrl = await _productCtx.Products
            .AsNoTracking()
                .Where(p => p.Category.Url.Equals(categoryUrl.ToLower()))
                .Include(p => p.ProductVariants).ToListAsync();

        return _mapper.Map<List<ProductDto>>(productsByCategoryUrl);
    }
}