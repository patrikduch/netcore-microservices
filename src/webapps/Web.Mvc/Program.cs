// <copyright file="Program.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IÈ: 09225471
// </copyright>
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using Web.Mvc.ApiServices;
using Web.Mvc.Auth.HttpHandlers;
using Web.Mvc.Config;
using Web.Mvc.Constants;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
var apiGwUrl = builder.Configuration.GetValue<string>("ApiGwUrl");
var identityUrl = builder.Configuration.GetValue<string>("IdentityUrl");

#region HttpClients configuration
builder.Services.AddTransient<AuthenticationDelegatingHandler>();

// creation of http client for fetching the data though API GW (Ocelot API GW)
builder.Services.AddHttpClient(HttpClientConstants.ApiGwHttpClientName, c =>
{
    c.BaseAddress = new Uri(apiGwUrl);
    c.DefaultRequestHeaders.Clear();
    c.DefaultRequestHeaders.Add("Accept", "application/json");
}).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

// creation of http client for IDP purposes
builder.Services.AddHttpClient(HttpClientConstants.IdenityServerHttpClientName, c =>
{
    c.BaseAddress = new Uri(identityUrl);
    c.DefaultRequestHeaders.Clear();
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});

var connectTokenUrl = identityUrl + "/connect/token";
builder.Services.AddSingleton(new ClientCredentialsTokenRequest
{
    Address = connectTokenUrl,
    ClientId = "productClient",
    ClientSecret = "secret",
    Scope = "productAPI"
});


#endregion

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    // Everything what was configured implicitly, we need to reset.
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
    options.ForwardLimit = 2; // if there are 2 proxies
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "https://identity.shopwinner.org";
        options.CallbackPath = new PathString("/signin-oidc");
        options.ClientId = "mvc_client";
        options.ClientSecret = "secret";
        //options.ResponseType = "code"; // Authorization Code Flow
        options.ResponseType = "code id_token"; // Hybrid Flow

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
        options.Scope.Add("productAPI");


        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = false,

            // Other validation parameters...
        };


        //options.Scope.Add("openid");
        //options.Scope.Add("profile");
        options.RequireHttpsMetadata = true; // Set this to true in production
        options.SaveTokens = true;
    });


#region Infrastructure services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
#endregion

// Add services to the container.
var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("RequestInfoLogger");
app.UseForwardedHeaders();
app.UseCookiePolicy();

// Log the updated request details
app.Use(async (context, next) =>
{
    logger.LogInformation("Request scheme: {Scheme}", context.Request.Scheme);
    logger.LogInformation("Request host: {Host}", context.Request.Host);
    logger.LogInformation("Request path base: {PathBase}", context.Request.PathBase);

    await next.Invoke();
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Now log the configuration values:
var programLogger = app.Services.GetRequiredService<ILogger<Program>>();
programLogger.LogInformation("ApiGwUrl: {ApiGwUrl}", apiGwUrl);
programLogger.LogInformation("IdentityUrl: {IdentityUrl}", identityUrl);

app.Run();
