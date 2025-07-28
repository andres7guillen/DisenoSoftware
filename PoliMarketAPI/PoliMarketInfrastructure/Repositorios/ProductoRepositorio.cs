using Microsoft.EntityFrameworkCore;
using PoliMarketData.Context;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;

namespace PoliMarketInfrastructure.Repositorios;

public class ProductoRepositorio : IProductoRepositorio
{
    private readonly ApplicationDbContext _context;

    public ProductoRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Producto> Guardar(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto> ObtenerPorId(Guid idProducto)
    {
        return await _context.Productos.FindAsync(idProducto);
    }

    public async Task<List<Producto>> ObtenerTodos()
    {
        return await _context.Productos.ToListAsync();
    }
}
