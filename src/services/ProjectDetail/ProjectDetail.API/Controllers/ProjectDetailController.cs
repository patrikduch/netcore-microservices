using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetMicroservices.ServiceConfig.Nuget;
using ProjectDetail.Application.Features.ProjectName.Queries.GetProjectName;
using System;
using System.Threading.Tasks;

namespace ProjectDetail.API.Controllers
{
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
        public async Task<ActionResult<Result<ProjectVm>>> GetPersonsList()
        {
            var query = new GetProjectNameQuery();
            var personsList = await _mediatR.Send(query);

            return Ok(personsList);
        }

    }
}
