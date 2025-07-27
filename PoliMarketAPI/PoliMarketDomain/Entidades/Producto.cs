namespace PoliMarketDomain.Entidades;

public class Producto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
}
