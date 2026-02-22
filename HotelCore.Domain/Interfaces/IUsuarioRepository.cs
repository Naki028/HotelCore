using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Entities;

namespace HotelCore.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario?> GetByUsernameAsync(string username);
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(int id);
}