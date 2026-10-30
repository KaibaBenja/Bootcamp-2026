using Bloque2.BL.DTOs;

namespace Bloque2.BL.Interfaces;

public interface IProductoService
{
    IReadOnlyList<ProductoDto> ObtenerTodos();
    ProductoDto? ObtenerPorId(int id);
    ProductoDto Crear(CreateProductoDto dto);
    bool Actualizar(int id, CreateProductoDto dto);
    bool Eliminar(int id);
}
