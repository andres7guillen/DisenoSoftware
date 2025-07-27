using CSharpFunctionalExtensions;
using PoliMarketDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarketDomain.Services;

public interface IClienteServicio
{
    public Task<Result<Cliente>> RegistrarCliente(Cliente cliente);
    public Task<Result<List<Cliente>>> ConsultarClientes();
    public Task<Result<Cliente>> ActualizarCliente(Cliente cliente);
    public Task<Result<bool>> EliminarCliente(Guid idCliente);
}
