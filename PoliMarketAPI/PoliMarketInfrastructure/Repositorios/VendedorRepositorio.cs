using Microsoft.EntityFrameworkCore;
using PoliMarketData.Context;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;

namespace PoliMarketInfrastructure.Repositorios;

public class VendedorRepositorio : IVendedorRepositorio
{
    private readonly ApplicationDbContext _context;

    public VendedorRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Vendedor> Guardar(Vendedor vendedor)
    {
        await _context.Vendedores.AddAsync(vendedor);
        await _context.SaveChangesAsync();
        return vendedor;
    }

    public async Task<List<Vendedor>> ObtenerTodos()
    {
        return await _context.Vendedores.ToListAsync();
    }

    public async Task<Vendedor> ObtnerPorId(Guid idVendedor)
    {
        return await _context.Vendedores.FindAsync(idVendedor);
    }
}
