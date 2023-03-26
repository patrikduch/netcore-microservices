using Newtonsoft.Json.Linq;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;
using Web.Gw.Constants;
using Web.Gw.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                                
                            .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true)
                            .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.ProjectDetail.json", false, true)
                            .Build();

IConfiguration configuration2 = new ConfigurationBuilder()

    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true)
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.Product.json", false, true)
    .Build();


// Combine the Routes sections from both configurations
JObject config1Json = JObject.Parse(configuration.GetSection("Routes").Value);
JArray config1Routes = (JArray)config1Json["Routes"];

JObject config2Json = JObject.Parse(configuration2.GetSection("Routes").Value);
JArray config2Routes = (JArray)config2Json["Routes"];

config1Routes.Merge(config2Routes);



// Create a new configuration containing the merged routes
var combinedConfigurationBuilder = new ConfigurationBuilder();
var combinedJson = new JObject(new JProperty("Routes", config1Routes));
var combinedJsonStream = new MemoryStream(Encoding.UTF8.GetBytes(combinedJson.ToString()));

combinedConfigurationBuilder.AddJsonStream(combinedJsonStream);
IConfiguration combinedConfiguration = combinedConfigurationBuilder.Build();



builder.Services.AddOcelot(combinedConfiguration)
    .AddKubernetesFixed();

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsConstants.CORSPOLICYRELEASE, corsPolicyBuilder =>
        corsPolicyBuilder
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
    options.AddPolicy(CorsConstants.CORSPOLICYDEV, corsPolicyBuilder => 
        corsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
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
