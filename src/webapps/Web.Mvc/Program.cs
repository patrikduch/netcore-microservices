using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.HttpOverrides;
using Web.Mvc.ApiServices;
using Web.Mvc.Config;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
var apiSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();

#region HttpClients configuration
builder.Services.AddHttpClient("api-gw", c =>
{
    c.BaseAddress = new Uri(apiSettings.ApiGwUrl);
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddHttpClient("identity-server", c =>
{
    c.BaseAddress = new Uri(apiSettings.IdentityUrl);
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});
#endregion

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    // Everything what was configured implicitly, we need to reset.
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
    options.ForwardLimit = 2; // if there are 2 proxies
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "https://identity.shopwinner.org";
        options.CallbackPath = new PathString("/signin-oidc");
        options.ClientId = "mvc_client";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.RequireHttpsMetadata = true; // Set this to true in production
        options.SaveTokens = true;
    });


#region Infrastructure services
builder.Services.AddScoped<IProductService, ProductService>();
#endregion

// Add services to the container.
var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("RequestInfoLogger");
app.UseForwardedHeaders();
app.UseCookiePolicy();

// Log the updated request details
app.Use(async (context, next) =>
{
    logger.LogInformation("Request scheme: {Scheme}", context.Request.Scheme);
    logger.LogInformation("Request host: {Host}", context.Request.Host);
    logger.LogInformation("Request path base: {PathBase}", context.Request.PathBase);

    await next.Invoke();
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Now log the configuration values:
var programLogger = app.Services.GetRequiredService<ILogger<Program>>();
programLogger.LogInformation("ApiSettings: {@ApiSettings}", apiSettings);

app.Run();
