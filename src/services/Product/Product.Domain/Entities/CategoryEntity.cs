//---------------------------------------------------------------------------
// <copyright file="CategoryEntity.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Domain.Entities;

/// <summary>
/// Entity for representation product's categories.
/// </summary>
public class CategoryEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets product url..
    /// </summary>
    public string Url { get; set; } = string.Empty;
}
