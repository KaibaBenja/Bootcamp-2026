using ProductoGestion.Models;

namespace ProductoGestion.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly List<Producto> productos;

    public ProductoRepository()
    {
        productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Notebook", Precio = 850000m, Categoria = "Tecnología", Activo = true },
            new Producto { Id = 2, Nombre = "Teclado mecánico", Precio = 75000m, Categoria = "Tecnología", Activo = true },
            new Producto { Id = 3, Nombre = "Silla de oficina", Precio = 180000m, Categoria = "Muebles", Activo = true },
            new Producto { Id = 4, Nombre = "Cuaderno", Precio = 4500m, Categoria = "Librería", Activo = false }
        };
    }

    public void Agregar(Producto producto)
    {
        productos.Add(producto);
    }

    public List<Producto> ObtenerTodos()
    {
        return productos.ToList();
    }

    public Producto? ObtenerPorId(int id)
    {
        return productos.FirstOrDefault(producto => producto.Id == id);
    }

    public List<Producto> BuscarPorCategoria(string categoria)
    {
        return productos
            .Where(producto => producto.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
