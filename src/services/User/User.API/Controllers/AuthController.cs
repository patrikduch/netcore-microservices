//---------------------------------------------------------------------------
// <copyright file="ÄuthController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace User.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using User.Application.Dtos;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        return Ok(await Task.FromResult(new AuthorizedUserDto("patrikduch")));
    }
}
