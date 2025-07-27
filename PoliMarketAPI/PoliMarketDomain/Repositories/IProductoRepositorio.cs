using PoliMarketDomain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Repositories;

public interface IProductoRepositorio
{
    public Task<List<Producto>> ObtenerTodos();
    public Task<Producto> ObtenerPorId(Guid idProducto);
}
