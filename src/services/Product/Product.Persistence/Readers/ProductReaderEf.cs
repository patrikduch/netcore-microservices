//---------------------------------------------------------------------------
// <copyright file="ProductReaderEf.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Persistence.Readers;

using Application.Products.Interfaces;
using Application.Dtos;
using Application.Products.Dtos;
using AutoMapper;
using Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// ProductReaderEf implementation class, that provides querying product data.
/// </summary>
public class ProductReaderEf : IProductReaderEf
{
    private readonly IMapper _mapper;
    private readonly ProductContext _productCtx;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductReaderEf"/>.
    /// </summary>
    /// <param name="mapper">Mapper depedency object.</param>
    /// <param name="productCtx"><seealso cref="DbContext"/> dependency object.</param>
    public ProductReaderEf(IMapper mapper, ProductContext productCtx)
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

    /// <summary>
    /// Fetch product search suggestion from product description and product title.
    /// </summary>
    /// <param name="searchText">Search term tthat will be processed.</param>
    /// <returns>Collection of product suggestions.</returns>
    public async Task<List<string>> FetchProductSearchSuggestions(string searchText)
    {
        // TODO - do some optimalization: time complexitiy is polynomial n^3

        var products = await FindProductsBySearchText(searchText);

        List<string> searchSuggestions = new List<string>();

        foreach (var product in products)
        {
            if (product.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            {
                searchSuggestions.Add(product.Name);
            }

            if (product.Description is not null)
            {
                var punctuation = product.Description.
                        Where(char.IsPunctuation)
                            .Distinct()
                                .ToArray();

                var words = product.Description.Split().Select(p => p.Trim(punctuation));

                foreach (var word in words)
                {
                    if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !searchSuggestions.Contains(word))
                    {
                        searchSuggestions.Add(word);
                    }
                }
            }
        }

        return searchSuggestions;
    }

    /// <summary>
    /// Find the products by product title and by product description.
    /// </summary>
    /// <param name="searchText">Search term tthat will be processed.</param>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public Task<List<ProductDto>> SearchProducts(string searchText)
    {
        return FindProductsBySearchText(searchText);
    }


    /// <summary>
    /// FindProduct by search text inside product description and product title.
    /// </summary>
    /// <param name="searchText">Search term tthat will be processed.</param>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    private async Task<List<ProductDto>> FindProductsBySearchText(string searchText)
    {
        if (_productCtx.Products is not null)
        {
            var products = await _productCtx.Products.
                Where(p => p.Name.ToLower()
                    .Contains(searchText.ToLower())
                        || p.Description.ToLower()
                                .Contains(searchText.ToLower())
                ).Include(p => p.ProductVariants)

                .ToListAsync();


            return _mapper.Map<List<ProductDto>>(products);
        }

        return Enumerable.Empty<ProductDto>().ToList();
    }
}