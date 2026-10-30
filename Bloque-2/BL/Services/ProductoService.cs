using Bloque2.BL.DTOs;
using Bloque2.BL.Interfaces;
using Bloque2.DAL.Entities;
using Bloque2.DAL.Interfaces;

namespace Bloque2.BL.Services;

public class ProductoService(IProductoRepository repository) : IProductoService
{
    public IReadOnlyList<ProductoDto> ObtenerTodos() =>
        repository.ObtenerTodos().Select(Mapear).ToList();

    public ProductoDto? ObtenerPorId(int id)
    {
        var producto = repository.ObtenerPorId(id);
        return producto is null ? null : Mapear(producto);
    }

    public ProductoDto Crear(CreateProductoDto dto)
    {
        var producto = repository.Agregar(new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            Activo = dto.Activo
        });

        return Mapear(producto);
    }

    public bool Actualizar(int id, CreateProductoDto dto) => repository.Actualizar(new Producto
    {
        Id = id,
        Nombre = dto.Nombre,
        Precio = dto.Precio,
        Categoria = dto.Categoria,
        Activo = dto.Activo
    });

    public bool Eliminar(int id) => repository.Eliminar(id);

    private static ProductoDto Mapear(Producto producto) => new()
    {
        Id = producto.Id,
        Nombre = producto.Nombre,
        Precio = producto.Precio,
        Categoria = producto.Categoria,
        Activo = producto.Activo
    };
}
