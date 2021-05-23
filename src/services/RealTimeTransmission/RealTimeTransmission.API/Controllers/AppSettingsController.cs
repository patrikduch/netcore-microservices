using Microsoft.AspNetCore.Mvc;

namespace RealTimeTransmission.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSettingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAppSettings()
        {
            return Ok(new { name = "RealTimeTransmission.API" });

        }
    }
}
