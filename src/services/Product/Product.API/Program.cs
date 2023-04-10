//---------------------------------------------------------------------------
// <copyright file="Program.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IÈ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NetMicroservices.SqlWrapper.Nuget;
using Product.Application;
using Product.Infrastructure;
using Product.Persistence;
using Product.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = configuration["IDENTITY_SERVER_URL"];
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Access the logger from the DI container
var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Product.API started");

// Get IdentityServer Url
logger.LogInformation("IDENTITY_SERVER_URL: {url}", configuration["IDENTITY_SERVER_URL"]);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<ProductContext>((_, _) =>
{
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();