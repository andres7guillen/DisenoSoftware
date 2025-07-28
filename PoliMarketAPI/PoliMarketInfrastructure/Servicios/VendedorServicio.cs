using PoliMarketDomain.Entidades;
using PoliMarketDomain.Repositories;
using PoliMarketDomain.Services;

namespace PoliMarketInfrastructure.Servicios;

public class VendedorServicio : IVendedorServicio
{
    private readonly IVendedorRepositorio _vendedorRepositorio;
    public VendedorServicio(IVendedorRepositorio vendedorRepositorio)
    {
        _vendedorRepositorio = vendedorRepositorio;
    }

    public async Task<List<Vendedor>> ObtenrVendedores() => await _vendedorRepositorio.ObtenerTodos();

    public async Task<Vendedor> RegistrarVendedor(Vendedor vendedor) => await _vendedorRepositorio.Guardar(vendedor);
}
