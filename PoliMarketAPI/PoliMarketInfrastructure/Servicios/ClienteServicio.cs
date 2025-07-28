using CSharpFunctionalExtensions;
using PoliMarketDomain.Entities;
using PoliMarketDomain.Repositories;
using PoliMarketDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketInfrastructure.Servicios;

public class ClienteServicio : IClienteServicio
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ClienteServicio(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    public async Task<Result<Cliente>> ActualizarCliente(Cliente cliente) => await _clienteRepositorio.ActualizarCliente(cliente);

    public async Task<Result<List<Cliente>>> ConsultarClientes() => await _clienteRepositorio.ObtenerTodos();

    public async Task<Result<bool>> EliminarCliente(Guid idCliente) => await _clienteRepositorio.EliminarCliente(idCliente);

    public async Task<Result<Cliente>> RegistrarCliente(Cliente cliente) => await _clienteRepositorio.Guardar(cliente);
}
