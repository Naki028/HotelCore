using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Entities;

namespace HotelCore.Domain.Interfaces;

public interface IServicioRepository
{
    Task<IEnumerable<ServicioAdicional>> GetAllAsync();
    Task<ServicioAdicional?> GetByIdAsync(int id);
    Task AddAsync(ServicioAdicional servicio);
    Task UpdateAsync(ServicioAdicional servicio);
    Task DeleteAsync(int id);
}