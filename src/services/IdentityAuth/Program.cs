using IdentityAuth;

var builder = WebApplication.CreateBuilder(args);

// Add required services for IdentityServer
builder.Services.AddIdentityServer()
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddDeveloperSigningCredential();

var app = builder.Build();


app.UseIdentityServer(); // Add IdentityServer middleware


app.MapGet("/", () => "Hello World!");

app.Run();
