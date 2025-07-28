using Microsoft.EntityFrameworkCore;
using PoliMarketData.Context;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketInfrastructure.Repositorios;

public class VentaRepositorio : IVentaRepositorio
{
    private readonly ApplicationDbContext _context;

    public VentaRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Venta> GuardarVenta(Venta venta)
    {
        await _context.Ventas.AddAsync(venta);
        await _context.SaveChangesAsync();
        return venta;
    }

    public async Task<List<Venta>> ObtenerPorVendedor(Guid idVendedor)
    {
        return await _context.Ventas
            .Where(v => v.VendedorId == idVendedor).ToListAsync();
    }

    public async Task<List<Venta>> ObtenerTodos()
    {
        return await _context.Ventas.ToListAsync();
    }
}
