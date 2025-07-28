using CSharpFunctionalExtensions;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;
using PoliMarketDomain.Services;

namespace PoliMarketInfrastructure.Servicios;

public class VentaServicio : IVentaServicio
{
    private readonly IVentaRepositorio _ventaRepositorio;
    private readonly IPedidoRepositorio _pedidoRepositorio;

    public VentaServicio(IVentaRepositorio ventaRepositorio, IPedidoRepositorio pedidoRepositorio)
    {
        _ventaRepositorio = ventaRepositorio;
        _pedidoRepositorio = pedidoRepositorio;
    }

    public async Task<Result<List<Venta>>> ConsultarVentas() => await _ventaRepositorio.ObtenerTodos();

    public async Task<Result<List<Venta>>> ObtenerPorVendedor(Guid idVendedor) => await _ventaRepositorio.ObtenerPorVendedor(idVendedor);

    public async Task<Result<Venta>> RegistrarVenta(Guid pedidoId) 
    {
        var pedido = await _pedidoRepositorio.ObtenerPorId(pedidoId);
        if (pedido == null)
            return Result.Failure<Venta>("Pedido no encontrado.");
        var total = pedido.CalcularTotal();
        var idVendedor = pedido.VendedorId;
        var venta = Venta.CrearVenta(DateTime.Now, pedido, total.Value, idVendedor);
        await _ventaRepositorio.GuardarVenta(venta.Value);
        return Result.Success<Venta>(venta.Value);
    }
    
}
