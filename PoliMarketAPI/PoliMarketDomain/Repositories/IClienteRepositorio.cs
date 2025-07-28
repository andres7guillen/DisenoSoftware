using PoliMarketDomain.Entities;

namespace PoliMarketDomain.Repositories;

public interface IClienteRepositorio
{
    public Task<Cliente> Guardar(Cliente cliente);
    public Task<Cliente> ObtenerPorId(Guid idCliente);
    public Task<List<Cliente>> ObtenerTodos();
    public Task<Cliente> ActualizarCliente(Cliente cliente);
    public Task<bool> EliminarCliente(Guid idCliente);
}
