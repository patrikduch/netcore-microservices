//---------------------------------------------------------------------------
// <copyright file="UAuthService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Persistence.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Dtos;
using User.Application.Dtos.Requests;
using User.Domain.Entities;
using User.Infrastructure;
using User.Persistence.Contexts;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly UserContext _userContext;


    public AuthService(IMapper mapper, UserContext userContext, IConfiguration configuration)
    {
        _configuration = configuration;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task<ServiceResponse<string>> Login(UserLoginRequestDto userloginDto)
    {
        var response = new ServiceResponse<string>();
        var user = await _userContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(userloginDto.Email));

        if (user is null)
        {
            response.Success = false;
            response.Message = "User not found.";

        } else if (!PasswordUtil.VerifyPasswordHash(userloginDto.Password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password";
        } else
        {
            response.Data = PasswordUtil.CreateToken(user, _configuration.GetSection("Appsettings:Token").Value);
        }

        return response;
    }

    public async Task<ServiceResponse<Guid>> Register(UserRegistrationDto user, string password)
    {
        if (await UserExists(user.Email))
        {
            return new ServiceResponse<Guid> { Success = false, Message = "User already exists." };
        }

        PasswordUtil.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

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
}
