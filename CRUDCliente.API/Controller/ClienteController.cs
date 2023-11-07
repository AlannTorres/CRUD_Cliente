using Microsoft.AspNetCore.Mvc;
using CRUDCliente.Application.DTOs;
using CRUDCliente.Application.Interfaces;

namespace CRUDCliente.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet("BuscarClientes")]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
    {
        var cliente = await _clienteService.GetClientes();
        if (cliente == null) return NotFound("Cliente não encontrado");
        return Ok(cliente);
    }

    [HttpGet("BuscarCliente/{id:int}")]
    public async Task<ActionResult<ClienteDTO>> GetClienteById(int id)
    {
        var cliente = await _clienteService.GetClienteById(id);
        if (cliente == null) return NotFound("Cliente não encontrado");
        return Ok(cliente);
    }

    [HttpPost("CadastrarCliente")]
    public async Task<ActionResult> CreateCliente([FromBody] ClienteDTO clienteDTO)
    {
        if (clienteDTO == null) return BadRequest("Dados inválidos");
        await _clienteService.AdicionarCliente(clienteDTO);
        return Ok(clienteDTO);
    }

    [HttpPut("EditarCliente")]
    public async Task<ActionResult> EditCliente(int id, [FromBody] ClienteDTO clienteDTO)
    {
        if (id != clienteDTO.Id) return BadRequest("Id invalido");
        if (clienteDTO == null) return BadRequest("Dados inválidos");
        await _clienteService.EditarCliente(clienteDTO);
        return Ok(clienteDTO);
    }

    [HttpDelete("RemoverCliente/{id:int}")]
    public async Task<ActionResult<ClienteDTO>> DeletCliente(int id)
    {
        var cliente = await _clienteService.GetClienteById(id);
        if (cliente == null) return NotFound("Cliente não encontrado");
        await _clienteService.DeleteCliente(id);
        return Ok(cliente);
    }
}
