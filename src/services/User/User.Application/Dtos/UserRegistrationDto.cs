//---------------------------------------------------------------------------
// <copyright file="UserRegistrationDto.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application.Dtos;

public class UserRegistrationDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }
}
