//------------------------------------------------------------------------------------
// <copyright file="Program.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IÈ: 09225471
// </copyright>
// <author>Patrik Duch</author>
// -----------------------------------------------------------------------------------
using NetMicroservices.SqlWrapper.Nuget;
using ProjectDetail.Application;
using ProjectDetail.Persistence;
using ProjectDetail.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<ProjectDetailContext>((context, services) =>
{
     var logger = services.GetService(typeof(ILogger<ProjectDetailContextSeed>)) as ILogger<ProjectDetailContextSeed>;

     ProjectDetailContextSeed
            .SeedAsync(context, logger)
            .Wait();
});


app.UseAuthorization();
app.MapControllers();
app.Run();
