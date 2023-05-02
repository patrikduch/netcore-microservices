// <copyright file="Program.cs" company="Patrik Duch">
// Copyright (c) Patrik Duch, IÈ: 09225471
// </copyright>
#pragma warning disable SA1200 // Using directives should be placed correctly
using System.Text;
using Newtonsoft.Json;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Web.Gw.Constants;
using Web.Gw.Extensions;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);

// Read route configuration files
var mainConfigFileName = $"ocelot.{builder.Environment.EnvironmentName}.json";
var additionalConfigFileNames = new List<string>
{
    $"ocelot.{builder.Environment.EnvironmentName}.ProjectDetail.json",
    $"ocelot.{builder.Environment.EnvironmentName}.Product.json",
    $"ocelot.{builder.Environment.EnvironmentName}.IdentityAuth.json",
    $"ocelot.{builder.Environment.EnvironmentName}.User.json",
};

var mainConfigJson = File.ReadAllText(mainConfigFileName);
var mainFileConfig = JsonConvert.DeserializeObject<FileConfiguration>(mainConfigJson);

foreach (var fileName in additionalConfigFileNames)
{
    var additionalConfigJson = File.ReadAllText(fileName);
    var additionalFileConfig = JsonConvert.DeserializeObject<FileConfiguration>(additionalConfigJson);

    if (additionalFileConfig is not null)
    {
        mainFileConfig?.Routes.AddRange(additionalFileConfig.Routes);
    }
}

var mergedConfigJson = JsonConvert.SerializeObject(mainFileConfig);
using var mergedConfigStream = new MemoryStream(Encoding.UTF8.GetBytes(mergedConfigJson));

builder.Configuration.AddJsonStream(mergedConfigStream);

// Register Ocelot with the merged route configurations
builder.Services.AddOcelot(builder.Configuration).AddKubernetesFixed();

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsConstants.Corspolicyrelease, corsPolicyBuilder =>
        corsPolicyBuilder
        .WithOrigins(
            DomainConstants.ProductionHttpsHost,
            DomainConstants.ProductionHttpHost
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsConstants.Corspolicydev, corsPolicyBuilder => 
        corsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();
var isDevelopment = Environment.GetEnvironmentVariable(EnvConstants.AspnetcoreEnvironment) == EnvConstants.DevEnvironment;

if (isDevelopment)
{
    app.UseCors(CorsConstants.Corspolicydev);
    app.UseDeveloperExceptionPage();

} else
{
    app.UseCors(CorsConstants.Corspolicyrelease);
}

app.MapControllers();


await app.UseOcelot();

// Inspect the routes before app.Run()
var internalConfigRepo = app.Services.GetService(typeof(IInternalConfigurationRepository)) as IInternalConfigurationRepository;
var internalConfig = internalConfigRepo?.Get().Data;

if (internalConfig is not null)
{
    foreach (var route in internalConfig.Routes)
    {
        Console.WriteLine($"Route: {route.DownstreamRoute} => {route.UpstreamTemplatePattern}");
    }
}


app.Run();
