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
public record ProductDto(Guid Id, string Name, string Description, string ImgUrl, decimal Price, Guid CategoryId);