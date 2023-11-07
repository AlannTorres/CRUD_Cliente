using Microsoft.EntityFrameworkCore;
using CRUDCliente.Domain.Entidades;
using CRUDCliente.Domain.Interfaces;
using CRUDCliente.Infra.Context;

namespace CRUDCliente.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationContext _context; 

    public ClienteRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        _context.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> RemoveAsync(Cliente cliente)
    {
        _context.Remove(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> UpdateAsync(Cliente cliente)
    {
        _context.Update(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
}
