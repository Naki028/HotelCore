using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelCore.Application.DTOs;

namespace HotelCore.Application.Interfaces;

public interface IReservaService
{
    Task<IEnumerable<ReservaDTO>> GetAllAsync();
    Task<ReservaDTO?> GetByIdAsync(int id);
    Task<int> CrearReservaAsync(CrearReservaDTO dto);
    Task CancelarReservaAsync(int id);
}