using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Web.Spa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AppSettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult GetConfigurationValue(string sectionName, string paramName)
        {
            var parameterValue = _configuration[$"{sectionName}:{paramName}"];
            return Ok(new { parameter = parameterValue });
        }

        [HttpGet("all")]
        public ActionResult GetConfigurations()
        {

            return Ok(_configuration.AsEnumerable());
        }

    }
}
