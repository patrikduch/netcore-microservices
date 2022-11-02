//---------------------------------------------------------------------------
// <copyright file="UserRegistrationCommand.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application.Features.Auth.Commands.UserRegistration;

using MediatR;
using NetMicroservices.ServiceConfig.Nuget;

public class UserRegistrationCommand : IRequest<ServiceResponse<Guid>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

