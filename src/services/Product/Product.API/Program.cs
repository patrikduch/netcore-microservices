//---------------------------------------------------------------------------
// <copyright file="Program.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, I�: 09225471
// </copyright>
// <author>Patrik Duch</author>
//---------------------------------------------------------------------------
using NetMicroservices.SqlWrapper.Nuget;
using Product.Application;
using Product.Infrastructure;
using Product.Persistence;
using Product.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<ProductContext>((context, services) =>
{
});

app.UseAuthorization();

app.MapControllers();

app.Run();
