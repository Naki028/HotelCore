using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Entities;

namespace HotelCore.Domain.Interfaces;

public interface IHabitacionRepository
{
    Task<IEnumerable<Habitacion>> GetAllAsync();
    Task<Habitacion?> GetByIdAsync(int id);
    Task<IEnumerable<Habitacion>> GetDisponiblesAsync();
    Task AddAsync(Habitacion habitacion);
    Task UpdateAsync(Habitacion habitacion);
    Task DeleteAsync(int id);
}