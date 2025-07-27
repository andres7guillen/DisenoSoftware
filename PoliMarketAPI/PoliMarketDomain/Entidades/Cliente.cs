using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PoliMarketDomain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;

    private Cliente(Guid conId, string conNombre, string conApellido, string conCorreo, string conTelefono, string conDireccion)
    {
        Id = conId;
        Nombre = conNombre;
        Correo = conCorreo;
        Telefono = conTelefono;
        Direccion = conDireccion;
        Apellido = conApellido;
    }

    public static Result<Cliente> Crear(Guid id, string nombre, string apellido, string correo, string telefono, string direccion) 
    {
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            return Result.Failure<Cliente>("Nombre y apellido son requeridos.");
        if (!correo.Contains("@"))
            return Result.Failure<Cliente>("Correo invalido.");

        return Result.Success<Cliente>(new Cliente(conId: id, conNombre: nombre, conApellido: apellido, conCorreo: correo, conTelefono: telefono, conDireccion: direccion));
    }

    public Result ActualizarDatos(string nombre, string apellido, string correo, string telefono, string direccion) 
    {
        if (!correo.Contains("@"))
            return Result.Failure("Correo invalido.");
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Telefono = telefono;
        Direccion = direccion;

        return Result.Success();
    }

}
