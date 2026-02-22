using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelCore.Application.DTOs;

namespace HotelCore.Application.Interfaces;

public interface IServicioService
{
    Task<IEnumerable<ServicioDTO>> GetAllAsync();
    Task<int> CreateAsync(ServicioDTO dto);
}