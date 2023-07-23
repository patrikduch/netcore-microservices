//---------------------------------------------------------------------------
// <copyright file="HomeController.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//----------------------------------------------------------------------------
namespace Web.Mvc.Controllers;

using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        LogTokenAndClaim();

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
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        // Sign out from openid donnect
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
    }


    public async Task LogTokenAndClaim()
    {
        var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

        Debug.WriteLine($"Identity token: {identityToken}");

        foreach (var userClaim in User.Claims)
        {
            Debug.WriteLine($"Claim type {userClaim.Type} - Claim value: {userClaim.Value}");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}