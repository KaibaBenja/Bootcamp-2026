using Bloque2.BL.Interfaces;
using Bloque2.BL.Services;
using Bloque2.DAL.Interfaces;
using Bloque2.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
