//-----------------------------------------------------------------------------------
// <copyright file="ProductService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// ----------------------------------------------------------------------------------
namespace Product.Persistence.Services;

using Product.Application.Contracts.Readers;
using Product.Application.Contracts.Services;
using Product.Application.Dtos;
using System;
using System.Collections.Generic;

/// <summary>
/// ProductService provides CRUD functionality for product management.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductReader _productReader;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProductService"/>.
    /// </summary>
    /// <param name="productReader">ProductReader dependency object.</param>
    public ProductService(IProductReader productReader)
    {
        _productReader = productReader;
    }

    /// <summary>
    /// Get product detail.
    /// </summary>
    /// <param name="productId">Unique product identifier.</param>
    /// <returns><seealso cref="ProductDetailDto"/> object.</returns>
    public async Task<ProductDetailDto?> GetProductDetail(Guid productId)
    {
        return await _productReader.FetchProductDetail(productId);
    }

    /// <summary>
    /// Get list of all products without restrictions.
    /// </summary>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public async Task<List<ProductDto>> GetProducts()
    {
        return await _productReader.FetchProducts();
    }

    /// <summary>
    /// Get list of products filtered by category url.
    /// </summary>
    /// <param name="categoryUrl">Url of selected product category.</param>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public async Task<List<ProductDto>> GetProductsByCategory(string categoryUrl)
    {
        return await _productReader.FetchProducts(categoryUrl);
    }

    /// <summary>
    /// Find the products by title and description.
    /// </summary>
    /// <param name="searchText">Search term that will be processed.</param>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public async Task<List<ProductDto>> SearchProducts(string searchText)
    {
        return await _productReader.SearchProducts(searchText);
    }
}