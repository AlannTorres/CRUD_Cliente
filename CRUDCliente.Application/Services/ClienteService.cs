using AutoMapper;
using CRUDCliente.Application.DTOs;
using CRUDCliente.Application.Interfaces;
using CRUDCliente.Domain.Entidades;
using CRUDCliente.Domain.Interfaces;

namespace CRUDCliente.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
    }

    public async Task<IEnumerable<ClienteDTO>> GetClientes()
    {
        var clienteEntity = await _clienteRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
    }

    public async Task<ClienteDTO> GetClienteById(int id)
    {
        var clienteEntity = await _clienteRepository.GetByIdAsync(id);
        return _mapper.Map<ClienteDTO>(clienteEntity);
    }

    public async Task AdicionarCliente(ClienteDTO clienteDTO)
    {
        var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
        await _clienteRepository.CreateAsync(clienteEntity);
    }

    public async Task DeleteCliente(int id)
    {
        var clienteEntity = _clienteRepository.GetByIdAsync(id).Result;
        await _clienteRepository.RemoveAsync(clienteEntity);
    }

    public async Task EditarCliente(ClienteDTO clienteDTO)
    {
        var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
        await _clienteRepository.UpdateAsync(clienteEntity);
    }
}
