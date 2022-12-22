//---------------------------------------------------------------------------
// <copyright file="ProductDetailDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Dtos;

public record ProductDetailDto(Guid Id, string Name, string Description, string ImgUrl, Guid CategoryId, List<ProductVariantDto> ProductVariants);
