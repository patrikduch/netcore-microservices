using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Web.Gw.Constants;
using Web.Gw.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true)
                            .Build();

builder.Services.AddOcelot(configuration)
    .AddKubernetesFixed();

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsConstants.CORSPOLICYRELEASE, builder =>
        builder
        .WithOrigins(
            DomainConstants.PRODUCTION_HOST
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsConstants.CORSPOLICYDEV, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();
var isDevelopment = Environment.GetEnvironmentVariable(EnvConstants.ASPNETCORE_ENVIRONMENT) == EnvConstants.DEV_ENVIRONMENT;

if (isDevelopment)
{
    app.UseCors(CorsConstants.CORSPOLICYDEV);
    app.UseDeveloperExceptionPage();

} else
{
    app.UseCors(CorsConstants.CORSPOLICYRELEASE);
}

app.MapControllers();
await app.UseOcelot();

app.Run();
