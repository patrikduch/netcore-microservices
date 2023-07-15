namespace Web.Mvc.Controllers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    public async Task Logout()
    {
        // Sign out from the cookie
        //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        // Sign out from openid donnect
        //await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

        await HttpContext.SignOutAsync("Cookies");
        await HttpContext.SignOutAsync("oidc");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}