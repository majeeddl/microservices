
using Basket.API.Frameworks.Data;
using Basket.API.GrpcServices;
using Discount.Grpc.Protos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
// Add services to the container.

services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});

services.AddRedisRepository();

//var t = builder.Configuration.GetValue<string>("GrpcSettings:DiscountUrl");
var t = builder.Configuration["GrpcSettings:DiscountUrl"];
services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(o=> o.Address = new Uri(t));
services.AddScoped<DiscountGrpcServices>();

services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
