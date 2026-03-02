using HotelCore.Domain.Entities;
using HotelCore.Domain.Interfaces;
using HotelCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelCore.Persistence.Repositories;

public class TarifaRepository : ITarifaRepository
{
    private readonly HotelCoreDbContext _context;

    public TarifaRepository(HotelCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tarifa>> GetAllAsync()
        => await _context.Tarifas.ToListAsync();

    public async Task<Tarifa?> GetByIdAsync(int id)
        => await _context.Tarifas.FindAsync(id);

    // Busca la tarifa vigente para una categoria en una fecha dada
    public async Task<Tarifa?> ObtenerTarifaVigenteAsync(int categoriaId, DateTime fecha)
        => await _context.Tarifas
            .Where(t => t.CategoriaId == categoriaId && t.VigenciaDesde <= fecha)
            .OrderByDescending(t => t.VigenciaDesde)
            .FirstOrDefaultAsync();

    public async Task AddAsync(Tarifa tarifa)
    {
        await _context.Tarifas.AddAsync(tarifa);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tarifa tarifa)
    {
        _context.Tarifas.Update(tarifa);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tarifa = await GetByIdAsync(id);
        if (tarifa != null)
        {
            _context.Tarifas.Remove(tarifa);
            await _context.SaveChangesAsync();
        }
    }
}