using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Entities;

namespace HotelCore.Domain.Interfaces;

public interface IReservaRepository
{
    Task<IEnumerable<Reserva>> GetAllAsync();
    Task<Reserva?> GetByIdAsync(int id);
    Task<IEnumerable<Reserva>> GetByClienteIdAsync(int clienteId);
    Task<IEnumerable<Reserva>> GetActivasAsync();
    Task<decimal> CalcularIngresosAsync(DateTime inicio, DateTime fin);
    Task<int> ContarReservasActivasAsync();
    Task AddAsync(Reserva reserva);
    Task UpdateAsync(Reserva reserva);
    Task DeleteAsync(int id);
}
