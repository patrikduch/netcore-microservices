//---------------------------------------------------------------------------
// <copyright file="Program.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IÈ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Product.Application;
using Product.Persistence;
using Product.Persistence.Contexts;
using Product.Persistence.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);


var connectionString = builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProductContext>();
    context.Database.Migrate();

    var productSeeder = scope.ServiceProvider.GetService<ProductSeeder>();
    productSeeder?.Seed();

    var categorySeeder = scope.ServiceProvider.GetService<CategorySeeder>();
    categorySeeder?.Seed();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
