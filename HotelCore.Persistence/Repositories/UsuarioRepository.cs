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

public class UsuarioRepository : IUsuarioRepository
{
    private readonly HotelCoreDbContext _context;

    public UsuarioRepository(HotelCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
        => await _context.Usuarios.ToListAsync();

    public async Task<Usuario?> GetByIdAsync(int id)
        => await _context.Usuarios.FindAsync(id);

    public async Task<Usuario?> GetByUsernameAsync(string username)
        => await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username == username);

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await GetByIdAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}