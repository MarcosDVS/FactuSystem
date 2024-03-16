
using FactuSystem.Data.Request;
using FactuSystem.Data.Response;
using FactuSystem.Data.Services;

namespace FactuSystem.Data.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<Result<List<ClienteResponse>>> Consultar(string filtro);
        Task<Result> Crear(ClienteRequest request);
        Task<Result> Eliminar(ClienteRequest request);
        Task<Result> Modificar(ClienteRequest request);
        Task CrearCliente();
    }
}