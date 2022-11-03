//---------------------------------------------------------------------------
// <copyright file="UserLoginCommandHandler.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.Application.Features.Auth.Commands.UserLogin;

using AutoMapper;
using MediatR;
using NetMicroservices.ServiceConfig.Nuget;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts;
using User.Application.Dtos.Requests;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ServiceResponse<string>>
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public UserLoginCommandHandler(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<string>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var requestDto =_mapper.Map<UserLoginRequestDto>(request);

        return await _authService.Login(requestDto);
    }
}
