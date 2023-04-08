//-----------------------------------------------------------------------------------
// <copyright file="IProductReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------
namespace Product.Application.Products.Interfaces;

using Dtos;
using Product.Application.Dtos;

public interface IProductReader
{
    Task<ProductDetailDto?> GetProductDetail(Guid productId);
    Task<List<ProductDto>> GetProducts();
    Task<List<ProductDto>> GetProducts(string categoryUrl);
    Task<List<ProductDto>> SearchProducts(string searchText);
    Task<List<string>> GetProductSearchSuggestions(string searchText);
}
