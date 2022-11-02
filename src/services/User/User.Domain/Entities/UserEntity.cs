//---------------------------------------------------------------------------
// <copyright file="UserEntity.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Domain.Entities;

using NetMicroservices.SqlWrapper.Nuget;

public class UserEntity : EntityBase
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Store the password hash
    /// </summary>
    public byte[] PasswordHash { get; set; }

    /// <summary>
    /// Store the password salt
    /// </summary>
    public byte[] PasswordSalt { get; set; }
}
