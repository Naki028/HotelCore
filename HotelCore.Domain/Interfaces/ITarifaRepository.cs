using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Entities;

namespace HotelCore.Domain.Interfaces;

public interface ITarifaRepository
{
    Task<IEnumerable<Tarifa>> GetAllAsync();
    Task<Tarifa?> GetByIdAsync(int id);
    Task<Tarifa?> ObtenerTarifaVigenteAsync(int categoriaId, DateTime fecha);
    Task AddAsync(Tarifa tarifa);
    Task UpdateAsync(Tarifa tarifa);
    Task DeleteAsync(int id);
}