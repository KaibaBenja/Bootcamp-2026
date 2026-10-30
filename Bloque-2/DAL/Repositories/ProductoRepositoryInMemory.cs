using Bloque2.DAL.Entities;
using Bloque2.DAL.Interfaces;

namespace Bloque2.DAL.Repositories;

public class ProductoRepositoryInMemory : IProductoRepository
{
    private readonly List<Producto> productos =
    [
        new Producto { Id = 1, Nombre = "Notebook", Precio = 850000m, Categoria = "Tecnología", Activo = true },
        new Producto { Id = 2, Nombre = "Teclado mecánico", Precio = 75000m, Categoria = "Tecnología", Activo = true },
        new Producto { Id = 3, Nombre = "Silla de oficina", Precio = 180000m, Categoria = "Muebles", Activo = true },
        new Producto { Id = 4, Nombre = "Cuaderno", Precio = 4500m, Categoria = "Librería", Activo = false }
    ];

    private int siguienteId = 5;

    public IReadOnlyList<Producto> ObtenerTodos() => productos.ToList();

    public Producto? ObtenerPorId(int id) => productos.FirstOrDefault(producto => producto.Id == id);

    public Producto Agregar(Producto producto)
    {
        producto.Id = siguienteId++;
        productos.Add(producto);
        return producto;
    }

    public bool Actualizar(Producto producto)
    {
        var existente = ObtenerPorId(producto.Id);
        if (existente is null)
        {
            return false;
        }

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Categoria = producto.Categoria;
        existente.Activo = producto.Activo;
        return true;
    }

    public bool Eliminar(int id)
    {
        var producto = ObtenerPorId(id);
        return producto is not null && productos.Remove(producto);
    }
}
