using Bloque2.DAL.Entities;

namespace Bloque2.DAL.Interfaces;

public interface IProductoRepository
{
    IReadOnlyList<Producto> ObtenerTodos();
    Producto? ObtenerPorId(int id);
    Producto Agregar(Producto producto);
    bool Actualizar(Producto producto);
    bool Eliminar(int id);
}
