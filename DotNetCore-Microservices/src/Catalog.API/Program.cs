using Catalog.API.Domains.Interfaces;
using Catalog.API.Frameworks.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;


services.ConfigureDatabase();
services.AddMongoRepository();

services.AddControllers();


services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
