namespace Web.Mvc.Controllers;

using ApiServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller
{
    private readonly IIdentityService _identityService;

    public UserController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync("Cookies");
        var accessToken = authenticateResult.Properties.GetTokenValue("access_token");
        
        var userProfile = await _identityService.GetUserProfileInfo(accessToken, CancellationToken.None);

        return View(userProfile);
    }
}
