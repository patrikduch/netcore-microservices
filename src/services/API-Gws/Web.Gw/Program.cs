using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true)
                            .Build();

builder.Services.AddOcelot(configuration);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
await app.UseOcelot();

app.Run();
