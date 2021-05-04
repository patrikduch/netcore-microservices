namespace AspnetCore.React.Redux.template.Controllers
{
    using AspnetCore.React.Redux.template.Services;
    using Microsoft.AspNetCore.Mvc;
    using ControllerBase = AspnetReactReduxTemplate.TypeScript.Controllers.ControllerBase;

    /// <summary>
    /// ProjectDetail REST controller for manaing current project informations.
    /// </summary>
    [ApiController]
    [Route("api/project")]
    public class ProjectDetailontroller : ControllerBase
    {
        /// <summary>
        /// Instance of ProjectDetailService.
        /// </summary>
        private readonly ProjectDetailService _projectDetailService;

        /// <summary>
        /// Default constuctor for creating new instance of ProjectDetail controller.
        /// </summary>
        /// <param name="projectDetailService"></param>
        public ProjectDetailontroller(ProjectDetailService projectDetailService)
        {
            _projectDetailService = projectDetailService;
        }

        /// <summary>
        /// Get project details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProjectDetails()
        {
            return Json(_projectDetailService.GetProjectDetail());
        }
    }
}
