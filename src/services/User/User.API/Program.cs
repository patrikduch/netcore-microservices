using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NetMicroservices.SqlWrapper.Nuget;
using User.Application;
using User.Persistence;
using User.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = configuration["IDENTITY_SERVER_URL"]; // This is the address of the IdentityServer where OpenID calls will be processed
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, // Audience value to be checked for each OpenId call
            ValidateIssuer = false,
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Access the logger from the DI container
var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("User.API started");

// Get IdentityServer Url
logger.LogInformation("IDENTITY_SERVER_URL: {url}", configuration["IDENTITY_SERVER_URL"]);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Migrate database on each deploy if it is necessary.
app.MigrateDatabase<UserContext>((_, _) =>
{
});

app.UseAuthorization();

app.MapControllers();

app.Run();
