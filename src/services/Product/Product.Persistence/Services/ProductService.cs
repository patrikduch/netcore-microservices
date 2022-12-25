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
/// ProductService provides all CRUD product's functionality.
/// </summary>
public class ProductService : IProductService
{
    private readonly IProductReader _productReader;
    

    public ProductService(IProductReader productReader)
    {
        _productReader = productReader;
    }

    public  async Task<ProductDetailDto> GetProductDetail(Guid productId)
    {
        return await _productReader.FetchProductDetail(productId);
    }

    public async Task<List<ProductDto>> GetProducts()
    {
        return await _productReader.FetchProducts();
    }

    public async Task<List<ProductDto>> GetProductsByCategory(string categoryUrl)
    {
        return await _productReader.FetchProducts(categoryUrl);
    }
}