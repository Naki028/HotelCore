using HotelCore.Domain.Entities;
using HotelCore.Domain.Interfaces;
using HotelCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelCore.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly HotelCoreDbContext _context;

    public ClienteRepository(HotelCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
        => await _context.Clientes.ToListAsync();

    public async Task<Cliente?> GetByIdAsync(int id)
        => await _context.Clientes.FindAsync(id);

    public async Task AddAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var cliente = await GetByIdAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}