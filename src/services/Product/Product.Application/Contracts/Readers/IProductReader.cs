//---------------------------------------------------------------------------
// <copyright file="IProductReader.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Contracts.Readers;

using Product.Application.Dtos;

/// <summary>
/// Contract for ProductReader implementation class, that provides quering product data.
/// </summary>
public interface IProductReader
{
    Task<ProductDetailDto> FetchProductDetail(Guid productId);
    Task<List<ProductDto>> FetchProducts();
    Task<List<ProductDto>> FetchProducts(string categoryUrl);
}
