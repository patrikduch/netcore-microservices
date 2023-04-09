//---------------------------------------------------------------------------
// <copyright file="ProductTypeItemDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace Product.Application.Products.Dtos;

/// <summary>
/// ProductType DTO object for transfering only relevant data about product type inside product variant object.
/// </summary>
/// <param name="Name">ProductType name.</param>
public record ProductTypeItemDto(string Name);
