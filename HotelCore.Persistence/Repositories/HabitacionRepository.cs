using HotelCore.Domain.Entities;
using HotelCore.Domain.Enums;
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

public class HabitacionRepository : IHabitacionRepository
{
    private readonly HotelCoreDbContext _context;

    public HabitacionRepository(HotelCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Habitacion>> GetAllAsync()
        => await _context.Habitaciones.ToListAsync();

    public async Task<Habitacion?> GetByIdAsync(int id)
        => await _context.Habitaciones.FindAsync(id);

    public async Task<IEnumerable<Habitacion>> GetDisponiblesAsync()
        => await _context.Habitaciones
            .Where(h => h.Estado == EstadoHabitacion.Disponible)
            .ToListAsync();

    public async Task AddAsync(Habitacion habitacion)
    {
        await _context.Habitaciones.AddAsync(habitacion);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Habitacion habitacion)
    {
        _context.Habitaciones.Update(habitacion);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var habitacion = await GetByIdAsync(id);
        if (habitacion != null)
        {
            _context.Habitaciones.Remove(habitacion);
            await _context.SaveChangesAsync();
        }
    }
}