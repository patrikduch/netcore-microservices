namespace Web.Mvc.Controllers;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

[Authorize]
public class OidcController : Controller
{
    private readonly ILogger<OidcController> _logger;

    public OidcController(ILogger<OidcController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/your-callback-path")]
    public async Task<IActionResult> Callback()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (!authenticateResult.Succeeded)
        {
            // Log the failure details
            var logger = HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("OpenIdConnect");
            logger.LogError($"Authentication failed: {authenticateResult.Failure.Message}");

            return RedirectToAction("Index", "Home");
        }

        // Retrieve the access token from the authentication properties
        var accessToken = authenticateResult.Properties.GetTokenValue(OpenIdConnectParameterNames.AccessToken);

        // Log the access token
        _logger.LogInformation($"Access Token: {accessToken}");

        return RedirectToAction("Privacy", "Home");
    }
}
