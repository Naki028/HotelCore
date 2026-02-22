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

public class ReservaRepository : IReservaRepository
{
    private readonly HotelCoreDbContext _context;

    public ReservaRepository(HotelCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reserva>> GetAllAsync()
        => await _context.Reservas.ToListAsync();

    public async Task<Reserva?> GetByIdAsync(int id)
        => await _context.Reservas.FindAsync(id);

    public async Task<IEnumerable<Reserva>> GetByClienteIdAsync(int clienteId)
        => await _context.Reservas
            .Where(r => r.ClienteId == clienteId)
            .ToListAsync();

    public async Task<IEnumerable<Reserva>> GetActivasAsync()
        => await _context.Reservas
            .Where(r => r.Estado != EstadoReserva.Cancelada)
            .ToListAsync();

    public async Task<decimal> CalcularIngresosAsync(DateTime inicio, DateTime fin)
        => await _context.Reservas
            .Where(r => r.FechaInicio >= inicio && r.FechaFin <= fin)
            .SumAsync(r => r.Total);

    public async Task<int> ContarReservasActivasAsync()
        => await _context.Reservas
            .CountAsync(r => r.Estado != EstadoReserva.Cancelada);

    public async Task AddAsync(Reserva reserva)
    {
        await _context.Reservas.AddAsync(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reserva reserva)
    {
        _context.Reservas.Update(reserva);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var reserva = await GetByIdAsync(id);
        if (reserva != null)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }
    }
}