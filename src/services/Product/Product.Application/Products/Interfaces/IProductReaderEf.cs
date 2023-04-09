//-----------------------------------------------------------------------------------
// <copyright file="IProductReaderEf.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------
namespace Product.Application.Products.Interfaces;

using Dtos;

/// <summary>
/// Contract interface for implementation ProductReader with EF.
/// </summary>
public interface IProductReaderEf
{
    Task<ProductDetailDto?> FetchProductDetail(Guid productId);
    Task<List<ProductDto>> FetchProducts();
    Task<List<ProductDto>> FetchProducts(string categoryUrl);
    Task<List<ProductDto>> SearchProducts(string searchText);
    Task<List<string>> FetchProductSearchSuggestions(string searchText);
}
