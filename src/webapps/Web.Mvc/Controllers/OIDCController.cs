namespace Web.Mvc.Controllers;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class OidcController : Controller
{
    [HttpGet("/your-callback-path")]
    public async Task<IActionResult> Callback()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (!authenticateResult.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("Privacy", "Home");
    }
}
