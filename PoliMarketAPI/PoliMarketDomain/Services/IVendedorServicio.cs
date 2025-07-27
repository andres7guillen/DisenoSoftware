using PoliMarketDomain.Entidades;

namespace PoliMarketDomain.Services;

public interface IVendedorServicio
{
    public Task<Vendedor> RegistrarVendedor(Vendedor vendedor);
    public Task<List<Vendedor>> ObtenrVendedores();
}
