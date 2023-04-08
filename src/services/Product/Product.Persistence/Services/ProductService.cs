//-----------------------------------------------------------------------------------
// <copyright file="ProductService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// ----------------------------------------------------------------------------------
namespace Product.Persistence.Services;

using Application.Dtos;
using Application.Products.Dtos;
using Application.Products.Interfaces;
using Product.Application.Contracts.Services;
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
    public ProductService(IProductReader productReader)
    {
        _productReader = productReader;
    }

    /// <summary>
    /// Get product detail.
    /// </summary>
    /// <param name="productId">Unique product identifier.</param>
    /// <returns><seealso cref="ProductDetailDto"/> object.</returns>
    public Task<ProductDetailDto?> GetProductDetail(Guid productId)
    {
        return _productReader.GetProductDetail(productId);
    }

    /// <summary>
    /// Get list of all products without restrictions.
    /// </summary>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public  Task<List<ProductDto>> GetProducts()
    { 
        return _productReader.GetProducts();
    }

    /// <summary>
    /// Get list of products filtered by category url.
    /// </summary>
    /// <param name="categoryUrl">Url of selected product category.</param>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public Task<List<ProductDto>> GetProductsByCategory(string categoryUrl)
    {
        return _productReader.GetProducts(categoryUrl);
    }

    /// <summary>
    /// Get list of search suggestions.
    /// </summary>
    /// <param name="searchText">Searched keyword.</param>
    /// <returns>List of potential search occurences.</returns>
    public Task<List<string>> GetProductSearchSuggestions(string searchText)
    {
        return _productReader.GetProductSearchSuggestions(searchText);
    }

    /// <summary>
    /// Find the products by title and description.
    /// </summary>
    /// <param name="searchText">Search term that will be processed.</param>
    /// <returns>Collection of <seealso cref="ProductDto"/> objects.</returns>
    public Task<List<ProductDto>> SearchProducts(string searchText)
    {
        return _productReader.SearchProducts(searchText);
    }
}