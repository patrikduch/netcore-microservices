﻿//---------------------------------------------------------------------------
// <copyright file="IAuthService.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application.Contracts;

using NetMicroservices.ServiceConfig.Nuget;
using User.Application.Dtos;

public interface IAuthService
{
    Task<ServiceResponse<Guid>> Register(UserRegistrationDto user, string password);

    Task<bool> UserExists(string email);
}
