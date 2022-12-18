//---------------------------------------------------------------------------
// <copyright file="ProductTypeEntity.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Domain.Entities;

using NetMicroservices.SqlWrapper.Nuget;

public class ProductTypeEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
}
