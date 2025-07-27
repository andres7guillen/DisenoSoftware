using PoliMarketDomain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Repositories;

public interface IVendedorRepositorio
{
    public Task<Vendedor> Guardar(Vendedor vendedor);
    public Task<Vendedor> ObtnerPorId(Guid idVendedor);
    public Task<List<Vendedor>> ObtenerTodos();
}
