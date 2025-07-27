using PoliMarketDomain.Entidades;

namespace PoliMarketDomain.Repositories;

public interface IPedidoRepositorio
{
    public Task<Pedido> Guardar(Pedido pedido);
    public Task<Pedido> ActualizarPedido(Pedido pedido);
    public Task<Pedido> ObtenerPorI(Guid idPedido);
    public Task<List<Pedido>> ObtenerPorCliente(Guid idCliente);
}
