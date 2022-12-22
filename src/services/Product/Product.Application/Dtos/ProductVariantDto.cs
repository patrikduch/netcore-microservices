//---------------------------------------------------------------------------
// <copyright file="ProductVariantDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Dtos;

public record ProductVariantDto(Guid Id, decimal price, decimal originalPrice, ProductTypeItemDto? ProductType);