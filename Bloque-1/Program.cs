
using ProductoGestion.Models;
using ProductoGestion.Repositories;

IProductoRepository repo = new ProductoRepository();

// 1. Mostrar todos los productos.
Console.WriteLine("=== TODOS LOS PRODUCTOS ===");

foreach (Producto producto in repo.ObtenerTodos())
{
    Console.WriteLine(
        $"ID: {producto.Id} | " +
        $"Nombre: {producto.Nombre} | " +
        $"Precio: ${producto.Precio} | " +
        $"Categoría: {producto.Categoria} | " +
        $"Activo: {producto.Activo}"
    );
}

// 2. Buscar un producto por ID.
Console.WriteLine("\n=== BUSCAR POR ID ===");

Producto? encontrado = repo.ObtenerPorId(2);

if (encontrado != null)
{
    Console.WriteLine(
        $"Encontrado: {encontrado.Nombre} - ${encontrado.Precio}"
    );
}
else
{
    Console.WriteLine("No se encontró el producto.");
}

// 3. Buscar productos por categoría.
Console.WriteLine("\n=== BUSCAR POR CATEGORÍA ===");

List<Producto> productosElectronica =
    repo.BuscarPorCategoria("Electrónica");

foreach (Producto producto in productosElectronica)
{
    Console.WriteLine($"{producto.Nombre} - ${producto.Precio}");
}

// 4. Agregar un nuevo producto.
Console.WriteLine("\n=== AGREGAR PRODUCTO ===");

Producto nuevoProducto = new Producto
{
    Id = 5,
    Nombre = "Auriculares",
    Precio = 35000m,
    Categoria = "Electrónidotnetca",
    Activo = true
};

repo.Agregar(nuevoProducto);

Console.WriteLine($"Producto agregado: {nuevoProducto.Nombre}");

// Verificar que se actualizo.
Console.WriteLine("\n=== LISTA ACTUALIZADA ===");

foreach (Producto producto in repo.ObtenerTodos())
{
    Console.WriteLine($"{producto.Id} - {producto.Nombre}");
}