using CSharpFunctionalExtensions;
using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;
using PoliMarketDomain.Services;

namespace PoliMarketInfrastructure.Servicios;

public class ProductoServicio : IProductoServicio
{
    private readonly IProductoRepositorio _productoRepositorio;

    public ProductoServicio(IProductoRepositorio productoRepositorio)
    {
        _productoRepositorio = productoRepositorio;
    }

    public async Task<Result<List<Producto>>> ConsultarProductos() => await _productoRepositorio.ObtenerTodos();
    public async Task<Producto> Guardar(Producto producto) => await _productoRepositorio.Guardar(producto);
}
