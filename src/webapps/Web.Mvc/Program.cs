using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true; // This one is optional
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    // Everything what was configured implicitly, we need to reset.
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

//builder.Services.Configure<CookiePolicyOptions>(options =>
//{
//  options.MinimumSameSitePolicy = SameSiteMode.Lax;
//  options.Secure = CookieSecurePolicy.Always;
//});
//int httpsPort = builder.Configuration.GetValue<int>("HTTPS_PORT");
//builder.Services.AddHttpsRedirection(options =>
//{
//  options.HttpsPort = httpsPort;
//});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
        options.DefaultSignOutScheme = "Cookies";
        options.DefaultSignInScheme = "Cookies";
    })
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
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

var app = builder.Build();

//app.UseForwardedHeaders();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
    RequireHeaderSymmetry = false,
    ForwardLimit = null
});


app.UseCookiePolicy();

//app.Use((context, next) =>
//{
  //  context.Request.Host = new HostString("https://webmvc.shopwinner.org");
  //  return next();
//});

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


app.Run();
