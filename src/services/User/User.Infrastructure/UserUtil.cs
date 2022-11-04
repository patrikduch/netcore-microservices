//---------------------------------------------------------------------------
// <copyright file="UserUtil.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Infrastructure;

using User.Domain.Entities;

public static class UserUtil
{
    public static UserEntity CreateUser(string email, string password)
    {
        PasswordUtil.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            Email = "patrikduch@test.com",
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        return user;
    }
}
