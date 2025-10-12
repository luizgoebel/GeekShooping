using AutoMapper;
using GeekShooping.ProductAPI.Config;
using GeekShooping.ProductAPI.Model.Context;
using GeekShooping.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GeekShoopig",
        Version = "v1"
    });
});

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingConfig>());
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connection,
        new MySqlServerVersion(new Version(8, 0, 32))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GeekShoopig v1");
    //    c.DocumentTitle = "GeekShoopig";
    //});
}

app.UseAuthorization();

app.MapControllers();

app.Run();
