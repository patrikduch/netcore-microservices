using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web.Blazor.Client;
using Web.Blazor.Client.Services.Auth;
using Web.Blazor.Client.Services.Category;
using Web.Blazor.Client.Services.Products;
using Web.Blazor.Client.Services.ProjectDetailService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.Configuration.GetValue<string>("APIGwUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProjectDetailService, ProjectDetailService>();
builder.Services.AddScoped<IProductService, ProductService>();


await builder.Build().RunAsync();
