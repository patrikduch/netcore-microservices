using IdentityAuth;
using IdentityModel.Client;
using IdentityServer4.Configuration;
using IdentityServer4.Extensions;
using Microsoft.Extensions.Options;
using System.Collections;

var builder = WebApplication.CreateBuilder(args);

// Automatically configure all MVC oontrollers
builder.Services.AddControllersWithViews();


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
    options.Secure = CookieSecurePolicy.Always;
});

// Add required services for IdentityServer
builder.Services.AddIdentityServer(options =>
    {
        options.IssuerUri = "https://identity.shopwinner.org";
    })
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestsUsers)
    .AddDefaultEndpoints()
    .AddDeveloperSigningCredential(); // Certificate our application



var app = builder.Build();

app.Use(async (ctx, next) =>
{
    ctx.SetIdentityServerOrigin("https://identity.shopwinner.org");
    await next();
});

app.UseCookiePolicy();

app.UseStaticFiles(); // Enable the static files from wwwroot directory

app.UseRouting();
app.UseIdentityServer(); // Add IdentityServer middleware

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


// Create a logger instance
using var scope = app.Services.CreateScope();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

var envVars = Environment.GetEnvironmentVariables();
foreach (DictionaryEntry envVar in envVars)
{
    logger.LogInformation("{envKey}={envValue}", envVar.Key, envVar.Value);
}


app.Run();
