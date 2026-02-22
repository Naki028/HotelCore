using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelCore.Application.DTOs;

namespace HotelCore.Application.Interfaces;

public interface IHabitacionService
{
    Task<IEnumerable<HabitacionDTO>> GetAllAsync();
    Task<HabitacionDTO?> GetByIdAsync(int id);
    Task UpdateEstadoAsync(int id, string estado);
}