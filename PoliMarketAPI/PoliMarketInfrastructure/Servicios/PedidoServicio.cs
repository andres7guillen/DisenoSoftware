using CSharpFunctionalExtensions;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;
using PoliMarketDomain.Services;

namespace PoliMarketInfrastructure.Servicios;

public class PedidoServicio : IPedidoServicio
{
    private readonly IPedidoRepositorio _pedidoRepositorio;

    public PedidoServicio(IPedidoRepositorio pedidoRepositorio)
    {
        _pedidoRepositorio = pedidoRepositorio;
    }

    public async Task<Result<List<Pedido>>> ConsultarPedidosCliente(Guid clienteId) => await _pedidoRepositorio.ObtenerPorCliente(clienteId);

    public async Task<Result<Pedido>> ModificarPedido(Pedido pedido) => await _pedidoRepositorio.ActualizarPedido(pedido);

    public async Task<Result<Pedido>> RegistrarPedido(Pedido pedido) => await _pedidoRepositorio.Guardar(pedido);
}
