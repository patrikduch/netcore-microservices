using IdentityAuth;

var builder = WebApplication.CreateBuilder(args);

// Automatically configure all MVC oontrollers
builder.Services.AddControllersWithViews();

// Add required services for IdentityServer
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestsUsers)
    .AddDeveloperSigningCredential(); // Certificate our application

var app = builder.Build();

app.UseStaticFiles(); // Enable the static files from wwwroot directory
app.UseRouting();
app.UseIdentityServer(); // Add IdentityServer middleware

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();
