using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true)
                            .Build();

builder.Services.AddOcelot(configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicyRelease", builder =>
        builder
        .WithOrigins(

            "http://20.23.74.87",
            "http://shopwinner.org"
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicyDev", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

if (isDevelopment)
{
    app.UseCors("CorsPolicyDev");
    app.UseDeveloperExceptionPage();

} else
{
    app.UseCors("CorsPolicyRelease");
}

app.MapControllers();
await app.UseOcelot();

app.Run();
