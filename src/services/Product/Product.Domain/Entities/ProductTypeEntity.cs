//---------------------------------------------------------------------------
// <copyright file="ProductTypeEntity.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Domain.Entities;

using NetMicroservices.SqlWrapper.Nuget;

/// <summary>
/// Entity for representation product's type inside product's variants.
/// </summary>
public class ProductTypeEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
}
