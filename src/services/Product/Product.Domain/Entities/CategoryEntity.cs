//---------------------------------------------------------------------------
// <copyright file="CategoryEntity.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Domain.Entities;

using NetMicroservices.SqlWrapper.Nuget;

/// <summary>
/// Entity for representation product's categories.
/// </summary>
public class CategoryEntity: EntityBase
{
    /// <summary>
    /// Gets or sets product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product url..
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets collection of products that are associated with particular Category.
    /// </summary>
    public List<ProductEntity> Products { get; set; } = new();
}
