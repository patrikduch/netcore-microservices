using IdentityAuth;

var builder = WebApplication.CreateBuilder(args);

// Add required services for IdentityServer
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestsUsers)
    .AddDeveloperSigningCredential(); // Certificate our application

var app = builder.Build();


app.UseIdentityServer(); // Add IdentityServer middleware


app.MapGet("/", () => "Identity Server v4!");

app.Run();
