using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelCore.Application.DTOs;

namespace HotelCore.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDTO>> GetAllAsync();
    Task<ClienteDTO?> GetByIdAsync(int id);
    Task<int> CreateAsync(ClienteDTO dto);
    Task UpdateAsync(int id, ClienteDTO dto);
    Task DeleteAsync(int id);
}