using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;

namespace RealTimeTransmission.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AppSettingsController : ControllerBase
    {

        private readonly IDistributedCache _redisCache;

        public AppSettingsController(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }


        [HttpGet]
        public async Task<ActionResult> GetAppSettings()
        {

            await _redisCache.SetStringAsync("test", "test");

            return Ok(new { name = "RealTimeTransmission.API", redisValue= await _redisCache.GetStringAsync("test") });
        }
    }
}
