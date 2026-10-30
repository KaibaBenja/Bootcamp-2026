using Bloque2.BL.DTOs;
using Bloque2.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bloque2.PL.Controllers;

[ApiController]
[Route("api/productos")]
public class ProductosController(IProductoService service) : ControllerBase
{
    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(service.ObtenerTodos());
    }

    [HttpGet("{id:int}")]
    public IActionResult ObtenerPorId(int id)
    {
        var producto = service.ObtenerPorId(id);
        return producto is null ? NotFound() : Ok(producto);
    }

    [HttpPost]
    public IActionResult Crear([FromBody] CreateProductoDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var producto = service.Crear(dto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
    }

    [HttpPut("{id:int}")]
    public IActionResult Actualizar(int id, [FromBody] CreateProductoDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return service.Actualizar(id, dto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Eliminar(int id)
    {
        return service.Eliminar(id) ? NoContent() : NotFound();
    }
}
