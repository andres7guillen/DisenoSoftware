using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliMarketDomain.Entities;
using PoliMarketDomain.Services;

namespace PoliMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCliente([FromBody] Cliente cliente)
        {
            var resultado = await _clienteServicio.RegistrarCliente(cliente);

            if (resultado.IsFailure)
                return BadRequest(resultado.Error);

            return CreatedAtAction(nameof(ConsultarClientePorId), new { id = resultado.Value.Id }, resultado.Value);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarClientes()
        {
            var resultado = await _clienteServicio.ConsultarClientes();

            if (resultado.IsFailure)
                return BadRequest(resultado.Error);

            return Ok(resultado.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarClientePorId(Guid id)
        {
            var clientes = await _clienteServicio.ConsultarClientes();

            var cliente = clientes.Value?.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return NotFound("Cliente no encontrado.");

            return Ok(cliente);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCliente([FromBody] Cliente cliente)
        {
            var resultado = await _clienteServicio.ActualizarCliente(cliente);

            if (resultado.IsFailure)
                return BadRequest(resultado.Error);

            return Ok(resultado.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(Guid id)
        {
            var resultado = await _clienteServicio.EliminarCliente(id);

            if (resultado.IsFailure)
                return BadRequest(resultado.Error);

            return Ok("Cliente eliminado exitosamente.");
        }

    }
}
