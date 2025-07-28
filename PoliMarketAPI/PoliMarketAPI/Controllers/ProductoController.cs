using Microsoft.AspNetCore.Mvc;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Services;

namespace PoliMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;

        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarProductos()
        {
            var resultado = await _productoServicio.ConsultarProductos();

            if (resultado.IsFailure)
                return BadRequest(resultado.Error);

            return Ok(resultado.Value);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest("Producto inválido.");

            var resultado = await _productoServicio.Guardar(producto);

            if (resultado == null)
                return BadRequest("No se pudo guardar el producto.");

            return CreatedAtAction(nameof(ConsultarProductos), new { id = resultado.Id }, resultado);
        }

    }
}
