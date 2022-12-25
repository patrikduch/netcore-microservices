//---------------------------------------------------------------------------
// <copyright file="ProductDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Dtos;

/// <summary>
/// Data transfer object for transfer relevant product's information.
/// </summary>
/// <param name="Id">Product unique identifier.</param>
/// <param name="Name">Product name.</param>
/// <param name="Description">Product description.</param>
/// <param name="ImgUrl">Product image url.</param>
/// <param name="CategoryId">CategoryId that is associated with current Product.</param>
/// <param name="ProductVariants">Product variants that are associated with current Product.</param>
public record ProductDto(Guid Id, string Name, string Description, string ImgUrl, Guid CategoryId, List<ProductVariantDto> ProductVariants);