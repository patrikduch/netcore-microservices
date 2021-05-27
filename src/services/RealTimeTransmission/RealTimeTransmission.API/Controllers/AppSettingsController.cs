using Microsoft.AspNetCore.Mvc;

namespace RealTimeTransmission.API.Controllers
{
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
