using CSharpFunctionalExtensions;
using PoliMarketDomain.Entities;

namespace PoliMarketDomain.Entidades;

public class Pedido
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public List<Producto> Productos { get; set; } = new();

    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public Guid VendedorId { get; set; }

    public int Cantidad { get; set; }

    public Result AgregarProducto(Producto producto, int nuevaCantidad)
    {
        if (producto == null)
            return Result.Failure("Producto no encontrado en el pedido.");

        if (nuevaCantidad <= 0)
            return Result.Failure("La cantidad debe ser mayor que cero.");

        Productos.Add(producto);
        Cantidad += nuevaCantidad;

        return Result.Success();
    }

    public Result<decimal> CalcularTotal()
    {
        if (Productos.Count == 0)
            return Result.Failure<decimal>("No hay productos para calcular el total.");

        decimal total = Productos.Sum(p => p.Precio);
        return Result.Success(total);
    }
}
