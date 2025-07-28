using CSharpFunctionalExtensions;

namespace PoliMarketDomain.Entidades;

public class Vendedor
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Cedula { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public List<Venta> Ventas { get; set; }
    public List<Pedido> Pedidos { get; set; }

    private Vendedor(Guid conId, string conNombre, string conCedula, string conTelefono, string conCorreo)
    {
        Id = conId;
        Nombre = conNombre;
        Cedula = conCedula;
        Telefono = conTelefono;
        Correo = conCorreo;
    }
    public static Result<Vendedor> Crear(Guid id, string nombre, string apellido, string correo, string telefono, string direccion, string cedula)
    {
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            return Result.Failure<Vendedor>("Nombre y apellido son requeridos.");
        if (!correo.Contains("@"))
            return Result.Failure<Vendedor>("Correo invalido.");

        return Result.Success<Vendedor>(new Vendedor(conId: id, conNombre: nombre, conCorreo: correo, conTelefono: telefono, conCedula: cedula));
    }

    public Result ActualizarDatos(string nombre, string correo, string telefono, string cedula)
    {
        if (!correo.Contains("@"))
            return Result.Failure("Correo invalido.");
        Nombre = nombre;
        
        Correo = correo;
        Telefono = telefono;
        Cedula = cedula;

        return Result.Success();
    }

}
