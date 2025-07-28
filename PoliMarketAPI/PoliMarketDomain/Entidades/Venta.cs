using CSharpFunctionalExtensions;
using PoliMarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PoliMarketDomain.Entidades;

public class Venta
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public Pedido Detalle{ get; set; }
    public decimal Total { get; set; }
    public Guid VendedorId { get; set; }
    public Vendedor Vendedor { get; set; }

    private Venta(Guid conId, DateTime conFecha, Pedido conDetalle, decimal conTotal, Guid conVendedorId)
    {
        Id = conId;
        Fecha = conFecha;
        Detalle = conDetalle;
        Total = conTotal;
        VendedorId = conVendedorId;
    }

    public static Result<Venta> CrearVenta(DateTime fecha, Pedido detalle, decimal total, Guid vendedorId) 
    {
        return Result.Success<Venta>(new Venta(conId: Guid.NewGuid(), conFecha: fecha, conDetalle: detalle, conTotal: total, conVendedorId: vendedorId));
    }

}
