using PoliMarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Repositories;

public interface IClienteRepositorio
{
    public Task<Cliente> Guardar(Cliente cliente);
    public Task<Cliente> ObtenerPorId(Guid idCliente);
    public Task<List<Cliente>> ObtenerTodos();
}
