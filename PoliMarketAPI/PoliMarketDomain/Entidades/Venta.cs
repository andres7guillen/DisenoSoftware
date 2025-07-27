using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Entidades;

public class Venta
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public Pedido Detalle{ get; set; }
    public decimal Total { get; set; }
}
