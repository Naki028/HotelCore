using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Entities;

namespace HotelCore.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<CategoriaHabitacion>> GetAllAsync();
    Task<CategoriaHabitacion?> GetByIdAsync(int id);
    Task AddAsync(CategoriaHabitacion categoria);
    Task UpdateAsync(CategoriaHabitacion categoria);
    Task DeleteAsync(int id);
}