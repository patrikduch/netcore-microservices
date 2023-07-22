using IdentityAuth;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Automatically configure all MVC oontrollers
builder.Services.AddControllersWithViews();


// In this system we are using Nginx Ingress, therefore we need to resend the headers into this service
#region ReverseProxy - header forwarding
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

    // Everything what was configured implicitly, we need to reset.
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});
#endregion


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
    options.Secure = CookieSecurePolicy.Always;
});

// Add required services for IdentityServer
builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseSuccessEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
    })
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestsUsers)
    .AddDeveloperSigningCredential(); // Certificate our application

var app = builder.Build();

app.UseForwardedHeaders();
app.UseCookiePolicy();
app.UseStaticFiles(); // Enable the static files from wwwroot directory
app.UseRouting();
app.UseIdentityServer(); // Add IdentityServer middleware
app.UseAuthorization(); // Without that i won't navigate to login page
 

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute(); // Using default HomeController with index view
});

app.Run();