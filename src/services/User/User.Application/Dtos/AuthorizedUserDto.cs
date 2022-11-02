//---------------------------------------------------------------------------
// <copyright file="AuthorizedUserDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application.Dtos;

/// <summary>
/// Data transfer object for getting relevant data about particular authorized user.
/// </summary>
/// <param name="Name">Name of user.</param>
public record AuthorizedUserDto(string Name);
