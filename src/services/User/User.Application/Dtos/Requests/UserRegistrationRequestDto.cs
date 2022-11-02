//---------------------------------------------------------------------------
// <copyright file="UserRegistrationRequestDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application.Dtos.Requests;

public record UserRegistrationRequestDto(string Email, string Password);
