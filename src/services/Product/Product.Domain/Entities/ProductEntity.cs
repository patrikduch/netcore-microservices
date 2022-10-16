//---------------------------------------------------------------------------
// <copyright file="ProductEntity.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Domain.Entities;

using NetMicroservices.SqlWrapper.Nuget;

/// <summary>
/// Entity that represents set of products.
/// </summary>
public class ProductEntity : EntityBase
{
    /// <summary>
    /// Gets or sets product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product imageUrl.
    /// </summary>
    public string ImgUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product price.
    /// </summary>
    public decimal Price { get; set; }
}