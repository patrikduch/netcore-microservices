//---------------------------------------------------------------------------
// <copyright file="UAuthService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Persistence.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Dtos;
using User.Domain.Entities;
using User.Persistence.Contexts;


public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly UserContext _userContext;


    public AuthService(IMapper mapper, UserContext userContext)
    {
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<ServiceResponse<Guid>> Register(UserRegistrationDto user, string password)
    {
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<Guid> { Success = false, Message = "User already exists." };
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordSalt = passwordSalt;
        user.PasswordHash = passwordHash;

        var userEntity = _mapper.Map<UserEntity>(user);

        _userContext.Users.Add(userEntity);

        await _userContext.SaveChangesAsync();

        return new ServiceResponse<Guid> { Data = userEntity.Id, Success = true };
    }

    public async Task<bool> UserExists(string email)
    {
        if (await _userContext.Users
            .AnyAsync(user => user.Email
            .ToLower().Equals(email))
        )
        {
            return true;
        }

        return false;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        // Cryptography algorithm

        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        };

    }
}
