//---------------------------------------------------------------------------
// <copyright file="UserRegistrationCommandHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application.Features.Auth.Commands.UserRegistration;

using AutoMapper;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Dtos;

public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, ServiceResponse<Guid>>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public UserRegistrationCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<Guid>> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        return await _authService.Register(_mapper.Map<UserRegistrationDto>(request), request.Password);
    }
}
