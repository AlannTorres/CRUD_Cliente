using CRUDCliente.Application.DTOs;

namespace CRUDCliente.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDTO>> GetClientes();
    Task<ClienteDTO> GetClienteById(int idCliente);
    Task AdicionarCliente(ClienteDTO clienteDTO);
    Task EditarCliente(ClienteDTO clienteDTO);
    Task DeleteCliente(int idCliente);
}
