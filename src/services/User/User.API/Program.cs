using NetMicroservices.SqlWrapper.Nuget;
using User.Application;
using User.Persistence;
using User.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Migrate database on each deploy if it is necesarry.
app.MigrateDatabase<UserContext>((context, services) =>
{
});

app.UseAuthorization();

app.MapControllers();

app.Run();
