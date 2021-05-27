using Microsoft.AspNetCore.Mvc;

namespace RealTimeTransmission.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AppSettingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAppSettings()
        {
            return Ok(new { name = "RealTimeTransmission.API" });
        }
    }
}
