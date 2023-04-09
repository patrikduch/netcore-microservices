//---------------------------------------------------------------------------
// <copyright file="ProductDetailVariantDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Application.Products.Dtos;

/// <summary>
/// DTO for displaying product detail variant info.
/// </summary>
/// <param name="Id">Product unique identifier.</param>
/// <param name="Price">Product price.</param>
/// <param name="OriginalPrice">Original price of a product.</param>
/// <param name="ProductTypeId">ProdutType identifier.</param>
/// <param name="ProductType">Product type object.</param>
public record ProductDetailVariantDto(Guid Id, decimal Price, decimal OriginalPrice, Guid ProductTypeId, ProductTypeItemDto? ProductType);
