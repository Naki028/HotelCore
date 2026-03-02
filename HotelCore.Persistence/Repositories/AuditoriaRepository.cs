using HotelCore.Domain.Entities;
using HotelCore.Domain.Interfaces;
using HotelCore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HotelCore.Persistence.Repositories;

public class AuditoriaRepository : IAuditoriaRepository
{
    private readonly HotelCoreDbContext _context;

    public AuditoriaRepository(HotelCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Auditoria>> GetAllAsync()
        => await _context.Auditorias.ToListAsync();

    public async Task<Auditoria?> GetByIdAsync(int id)
        => await _context.Auditorias.FindAsync(id);

    public async Task AddAsync(Auditoria auditoria)
    {
        await _context.Auditorias.AddAsync(auditoria);
        await _context.SaveChangesAsync();
    }
}