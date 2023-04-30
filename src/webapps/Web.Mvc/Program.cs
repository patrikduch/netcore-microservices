using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using System.Collections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// OpenId configuration

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "https://identity.shopwinner.org"; // identity server address
        options.ClientId = "mvc_client";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        options.RequireHttpsMetadata = true;

        options.Scope.Add("openid");
        options.Scope.Add("profile");

        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
    });


var app = builder.Build();

// Create a logger instance
using var scope = app.Services.CreateScope();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

if (app.Environment.IsProduction())
{
    logger.LogInformation("Schema changed to HTTPS");
    app.Use((context, next) =>
    {
        context.Request.Scheme = "https";
        return next();
    });

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedProto
    });
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


var envVars = Environment.GetEnvironmentVariables();
foreach (DictionaryEntry envVar in envVars)
{
    logger.LogInformation("{envKey}={envValue}", envVar.Key, envVar.Value);
}


app.Run();
