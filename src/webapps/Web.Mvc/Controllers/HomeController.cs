// <copyright file="HomeController.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
namespace Web.Mvc.Controllers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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

    /// <summary>
    /// Asynchronously signs the user out from the application.
    /// </summary>
    /// <returns>A task that represents the asynchronous logout operation.</returns>
    [Authorize]
    public async Task Logout()
    {
        // Sign the user out from the application by invalidating the authentication cookie.
        // This removes the cookie that keeps track of the user's authenticated session.
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // Sign the user out from the OpenID Connect session.
        // This sends a request to the OpenID Connect server to end the user's session.
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

    /// <summary>
    /// View for managing error states in the application.
    /// </summary>
    // "Duration = 0" means this response is not cached.
    // "Location = ResponseCacheLocation.None" means the response cannot be stored in any cache location.
    // "NoStore = true" directs that the response should not be stored in the cache.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}