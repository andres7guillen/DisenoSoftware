using PoliMarketDomain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Repositories;

public interface IVentaRepositorio
{
    public Task<Venta> GuardarVenta(Venta venta);
    public Task<List<Venta>> ObtenerTodos();
    public Task<List<Venta>> ObtenerPorVendedor(Guid idVendedor);
}
