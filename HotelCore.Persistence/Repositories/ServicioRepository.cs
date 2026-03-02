using HotelCore.Domain.Entities;
using HotelCore.Domain.Interfaces;
using HotelCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelCore.Persistence.Repositories;

public class ServicioRepository : IServicioRepository
{
    private readonly HotelCoreDbContext _context;

    public ServicioRepository(HotelCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ServicioAdicional>> GetAllAsync()
        => await _context.Servicios.ToListAsync();

    public async Task<ServicioAdicional?> GetByIdAsync(int id)
        => await _context.Servicios.FindAsync(id);

    public async Task AddAsync(ServicioAdicional servicio)
    {
        await _context.Servicios.AddAsync(servicio);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ServicioAdicional servicio)
    {
        _context.Servicios.Update(servicio);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var servicio = await GetByIdAsync(id);
        if (servicio != null)
        {
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
        }
    }
}