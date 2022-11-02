//---------------------------------------------------------------------------
// <copyright file="ÄuthController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetMicroservices.ServiceConfig.Nuget;
using User.Application.Dtos;
using User.Application.Dtos.Requests;
using User.Application.Features.Auth.Commands.UserRegistration;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        return Ok(await Task.FromResult(new AuthorizedUserDto("patrikduch")));
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServiceResponse<Guid>>> Register(UserRegistrationRequestDto request)
    {
        var response = await _mediator.Send(new UserRegistrationCommand
        {
            Email = request.Email,
            Password = request.Password
        });

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    } 
}
