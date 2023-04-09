//---------------------------------------------------------------------------
// <copyright file="ProductVariantDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------
namespace Product.Application.Products.Dtos;

/// <summary>
/// Product type dto that is needed for representing product variant objects.
/// </summary>
/// <param name="Id">Product variant unique identifier.</param>
/// <param name="Price">Price of product.</param>
/// <param name="OriginalPrice">Original product price.</param>
/// <param name="ProductType">Type of product.</param>
public record ProductVariantDto(Guid Id, decimal Price, decimal OriginalPrice, ProductTypeItemDto? ProductType);