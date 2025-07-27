using CSharpFunctionalExtensions;
using PoliMarketDomain.Entidades;

namespace PoliMarketDomain.Services;

public interface IPedidoServicio
{
    public Task<Result<Pedido>> RegistrarPedido(Pedido pedido);
    public Task<Result<Pedido>> ModificarPedido(Pedido pedido);
    public Task<Result<List<Pedido>>> ConsultarPedidosCliente(Guid clientId);
}
