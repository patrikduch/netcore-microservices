//---------------------------------------------------------------------------
// <copyright file="IProductService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Contracts.Services;

using Product.Application.Dtos;

/// <summary>
/// Contract for ProductService, that provides all functionality for reading and mutating product's data.
/// </summary>
public interface IProductService
{
    Task<ProductDetailDto?> GetProductDetail(Guid productId);

    Task<List<ProductDto>> GetProducts();

    Task<List<ProductDto>> GetProductsByCategory(string categoryUrl);

    Task<List<ProductDto>> SearchProducts(string searchText);

    Task<List<string>> GetProductSearchSuggestions(string searchText);
}