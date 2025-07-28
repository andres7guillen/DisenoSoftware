using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Services;

namespace PoliMarketAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly IPedidoServicio _pedidoServicio;

    public PedidoController(IPedidoServicio pedidoServicio)
    {
        _pedidoServicio = pedidoServicio;
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarPedido([FromBody] Pedido pedido)
    {
        var resultado = await _pedidoServicio.RegistrarPedido(pedido);

        if (resultado.IsFailure)
            return BadRequest(resultado.Error);

        return CreatedAtAction(nameof(ConsultarPedidosPorCliente), new { clientId = resultado.Value.ClienteId }, resultado.Value);
    }

    [HttpPut]
    public async Task<IActionResult> ModificarPedido([FromBody] Pedido pedido)
    {
        var resultado = await _pedidoServicio.ModificarPedido(pedido);

        if (resultado.IsFailure)
            return BadRequest(resultado.Error);

        return Ok(resultado.Value);
    }

    [HttpGet("cliente/{clientId}")]
    public async Task<IActionResult> ConsultarPedidosPorCliente(Guid clientId)
    {
        var resultado = await _pedidoServicio.ConsultarPedidosCliente(clientId);

        if (resultado.IsFailure)
            return BadRequest(resultado.Error);

        if (resultado.Value == null || !resultado.Value.Any())
            return NotFound("No se encontraron pedidos para el cliente.");

        return Ok(resultado.Value);
    }
}
