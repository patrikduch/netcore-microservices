//---------------------------------------------------------------------------
// <copyright file="ProjectDetailController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
namespace ProjectDetail.API.Controllers;

using Application.Features.ProjectName.Queries.GetProjectName;
using Application.ProjectName.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/[controller]")]
[ApiController]
public class ProjectDetailController : ControllerBase
{
    private readonly IMediator _mediatR;

    /// <summary>
    /// Initializes a new instance of the <seealso cref="ProjectDetailController"/>.
    /// </summary>
    /// <param name="mediatR">Mediator dependency object.</param>
    public ProjectDetailController(IMediator mediatR)
    {
        _mediatR = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
    }

    /// <summary>
    /// Get detail about project.
    /// </summary>
    /// <returns>Project detail information.</returns>
    [HttpGet]
    [Produces("application/json")]
    public async Task<ActionResult<ProjectDetailDto>> GetProjectDetail()
    {
        var query = new GetProjectNameQuery();
        var personsList = await _mediatR.Send(query);

        return Ok(personsList.Value);
    }
}