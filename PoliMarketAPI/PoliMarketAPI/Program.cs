using Microsoft.EntityFrameworkCore;
using PoliMarketData.Context;
using PoliMarketDomain.Repositories;
using PoliMarketDomain.Services;
using PoliMarketInfrastructure.Repositories;
using PoliMarketInfrastructure.Repositorios;
using PoliMarketInfrastructure.Servicios;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        );
    })
);

builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IClienteServicio, ClienteServicio>();

// 🗃️ Registro de repositorios
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
