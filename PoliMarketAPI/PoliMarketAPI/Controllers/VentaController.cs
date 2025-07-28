using Microsoft.AspNetCore.Mvc;
using PoliMarketDomain.Services;

namespace PoliMarketAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentaController : ControllerBase
{
    private readonly IVentaServicio _ventaServicio;

    public VentaController(IVentaServicio ventaServicio)
    {
        _ventaServicio = ventaServicio;
    }

    [HttpPost("{pedidoId}")]
    public async Task<IActionResult> RegistrarVenta(Guid pedidoId)
    {
        var resultado = await _ventaServicio.RegistrarVenta(pedidoId);

        if (resultado.IsFailure)
            return BadRequest(resultado.Error);

        return CreatedAtAction(nameof(ConsultarVentas), new { id = resultado.Value.Id }, resultado.Value);
    }

    [HttpGet]
    public async Task<IActionResult> ConsultarVentas()
    {
        var resultado = await _ventaServicio.ConsultarVentas();

        if (resultado.IsFailure)
            return BadRequest(resultado.Error);

        return Ok(resultado.Value);
    }

    [HttpGet("vendedor/{idVendedor}")]
    public async Task<IActionResult> ObtenerPorVendedor(Guid idVendedor)
    {
        var resultado = await _ventaServicio.ObtenerPorVendedor(idVendedor);

        if (resultado.IsFailure)
            return BadRequest(resultado.Error);

        if (resultado.Value == null || !resultado.Value.Any())
            return NotFound("No se encontraron ventas para este vendedor.");

        return Ok(resultado.Value);
    }

}
