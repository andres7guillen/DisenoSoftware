using Microsoft.EntityFrameworkCore;
using PoliMarketData.Context;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;

namespace PoliMarketInfrastructure.Repositorios;

public class PedidoRepositorio : IPedidoRepositorio
{
    private readonly ApplicationDbContext _context;

    public PedidoRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Pedido> ActualizarPedido(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido> Guardar(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<List<Pedido>> ObtenerPorCliente(Guid idCliente)
    {
        return await _context.Pedidos
            .Where(p => p.ClienteId == idCliente)
            .ToListAsync();
    }

    public async Task<Pedido> ObtenerPorId(Guid idPedido)
    {
        return await _context.Pedidos.FindAsync(idPedido);
    }
}
