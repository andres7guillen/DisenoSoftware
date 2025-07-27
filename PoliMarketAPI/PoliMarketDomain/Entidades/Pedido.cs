using CSharpFunctionalExtensions;
using PoliMarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Entidades;

public class Pedido
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente  Cliente{ get; set; }
    public List<Producto>  Productos { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

    public Result ModificarProducto() 
    { 
    
    }

    public Result<decimal> CalcularTotal() 
    { 
    
    }
}
