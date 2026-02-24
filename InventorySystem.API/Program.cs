using InventorySystem.Infrastructure.Persistence;
using InventorySystem.Application.Interfaces;
using InventorySystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Swagger (UI + generator)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductBrandService, ProductBrandService>();
builder.Services.AddScoped<IProductModelService, ProductModelService>();

builder.Services.AddDbContext<OracleDbContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("Oracle");
    options.UseOracle(cs);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // OpenAPI JSON (nativo)
    app.MapOpenApi(); // => /openapi/v1.json (según tu plantilla)

    // Swagger JSON + UI
    app.UseSwagger();      // => /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory System API v1");
        c.RoutePrefix = "swagger"; // => /swagger
    });
}
else
{
    app.UseHttpsRedirection();
}



app.UseAuthorization();

app.MapControllers();

app.Run();
