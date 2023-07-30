namespace Product.API.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize("ClientIdPolicy")]
[Route("api/v1/{controller}")]
[ApiController]
public class IdentityController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
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
