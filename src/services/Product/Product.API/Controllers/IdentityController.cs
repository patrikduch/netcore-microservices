namespace Product.API.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/{controller}")]
[ApiController]
[Authorize]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public IActionResult GetClaims()
    {
        var user = User.Claims.Select(c => new
        {
            tzpe = c.Type,
            value = c.Value
        });


        return new JsonResult(user);
    }
}
