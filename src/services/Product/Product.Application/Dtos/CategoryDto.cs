//---------------------------------------------------------------------------
// <copyright file="CategoryDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

namespace Product.Application.Dtos;

/// <summary>
/// Data transfer object for transfer relevant product category information.
/// </summary>
public record CategoryDto(Guid Id, string Name, string Url);
