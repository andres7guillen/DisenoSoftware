using Microsoft.EntityFrameworkCore;
using PoliMarketData.Context;
using PoliMarketDomain.Entities;
using PoliMarketDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketInfrastructure.Repositories;

public class ClienteRepositorio : IClienteRepositorio
{
    private readonly ApplicationDbContext _context;

    public ClienteRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> ActualizarCliente(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> EliminarCliente(Guid idCliente)
    {
        var cliente = await _context.Clientes.FindAsync(idCliente);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }
        return false;
    }

    public async Task<Cliente> Guardar(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> ObtenerPorId(Guid idCliente)
    {
        var cliente = await _context.Clientes.FindAsync(idCliente);
        return cliente;
    }

    public async Task<List<Cliente>> ObtenerTodos()
    {
        return await _context.Clientes.ToListAsync();
    }
}
