using CSharpFunctionalExtensions;
using PoliMarketDomain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Services;

public interface IVentaServicio
{
    public Task<Result<Venta>> RegistrarVenta(Guid pedidoId);
    public Task<Result<List<Venta>>> ConsultarVentas();
}
