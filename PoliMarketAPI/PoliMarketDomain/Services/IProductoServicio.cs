using CSharpFunctionalExtensions;
using PoliMarketDomain.Entidades;

namespace PoliMarketDomain.Services;

public interface IProductoServicio
{
    public Task<Result<List<Producto>>> ConsultarProductos();
    public Task<Producto> Guardar(Producto producto);
}
