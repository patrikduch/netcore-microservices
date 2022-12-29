//---------------------------------------------------------------------------
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

/// <summary>
/// ProductReader implementation class, that provides quering product data.
/// </summary>
public class ProductReader : IProductReader
{
    private readonly IMapper _mapper;
    private readonly ProductContext _productCtx;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductReader"/>.
    /// </summary>
    /// <param name="mapper">Mapper depedency object.</param>
    /// <param name="productCtx"><seealso cref="DbContext"/> dependency object.</param>
    public ProductReader(IMapper mapper, ProductContext productCtx)
    {
        _mapper= mapper;
        _productCtx= productCtx;
    }

    /// <summary>
    /// Fetch product details with variants.
    /// </summary>
    /// <param name="productId">Unique product identifier.</param>
    /// <returns><seealso cref="ProductDetailDto"/> object. </returns>
    public async Task<ProductDetailDto?> FetchProductDetail(Guid productId)
    {
        if (_productCtx.Products is not null)
        {
            var products = await _productCtx.Products
            .Where(p => p.Id == productId)
            .AsNoTracking()
            .Include(p => p.ProductVariants)
                .ThenInclude(p => p.ProductType).FirstOrDefaultAsync();

            return _mapper.Map<ProductDetailDto?>(products);
        }

        return await Task.FromResult<ProductDetailDto?>(null);
    }

    /// <summary>
    /// Fetch all products without restrictions.
    /// </summary>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public async Task<List<ProductDto>> FetchProducts()
    {
        if (_productCtx.Products is not null)
        {
            var products = await _productCtx.Products
            .AsNoTracking()
                .Include(p => p.ProductVariants).ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }

        return Enumerable.Empty<ProductDto>().ToList();
    }

    /// <summary>
    /// Fetch products by category url.
    /// </summary>
    /// <param name="categoryUrl">Category url used for filtering list of products.</param>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public async Task<List<ProductDto>> FetchProducts(string categoryUrl)
    {
        if (_productCtx.Products is not null)
        {
            var productsByCategoryUrl = await _productCtx.Products
            .AsNoTracking()
                .Where(p => p.Category != null && p.Category.Url.Equals(categoryUrl.ToLower()))
                    .Include(p => p.ProductVariants).ToListAsync();

            return _mapper.Map<List<ProductDto>>(productsByCategoryUrl);
        }

        return Enumerable.Empty<ProductDto>().ToList();
    }
}