using IdentityAuth;

var builder = WebApplication.CreateBuilder(args);

// Automatically configure all MVC oontrollers
builder.Services.AddControllersWithViews();


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
    options.Secure = CookieSecurePolicy.Always;
});

// Add required services for IdentityServer
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestsUsers)
    .AddDeveloperSigningCredential(); // Certificate our application

var app = builder.Build();

app.UseCookiePolicy();

app.UseStaticFiles(); // Enable the static files from wwwroot directory
app.UseRouting();
app.UseIdentityServer(); // Add IdentityServer middleware

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();
