//---------------------------------------------------------------------------
// <copyright file="ProductDetailDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.Dtos;

using Product.Application.Dtos;

/// <summary>
/// Data transfer object for displaying details about selected product.
/// </summary>
/// <param name="Id">Product unique identifier.</param>
/// <param name="Name">Product name.</param>
/// <param name="Description">Product description.</param>
/// <param name="ImgUrl">Product image url.</param>
/// <param name="CategoryId">CategoryId that is associated with current Product.</param>
/// <param name="ProductVariants">Product variants that are associated with current Product.</param>
public record ProductDetailDto(Guid Id, string Name, string Description, string ImgUrl, Guid CategoryId, List<ProductDetailVariantDto> ProductVariants);