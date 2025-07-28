using Microsoft.AspNetCore.Mvc;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Services;

namespace PoliMarketAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendedorController : ControllerBase
{
    private readonly IVendedorServicio _vendedorServicio;

    public VendedorController(IVendedorServicio vendedorServicio)
    {
        _vendedorServicio = vendedorServicio;
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarVendedor([FromBody] Vendedor vendedor)
    {
        if (vendedor == null)
            return BadRequest("Datos del vendedor inválidos.");

        var resultado = await _vendedorServicio.RegistrarVendedor(vendedor);

        if (resultado == null)
            return BadRequest("No se pudo registrar el vendedor.");

        return CreatedAtAction(nameof(ObtenerVendedores), new { id = resultado.Id }, resultado);
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerVendedores()
    {
        var resultado = await _vendedorServicio.ObtenrVendedores();

        if (resultado == null || resultado.Count == 0)
            return NotFound("No hay vendedores registrados.");

        return Ok(resultado);
    }

}
