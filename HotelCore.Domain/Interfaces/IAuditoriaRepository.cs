using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Entities;

namespace HotelCore.Domain.Interfaces;

public interface IAuditoriaRepository
{
    Task<IEnumerable<Auditoria>> GetAllAsync();
    Task<Auditoria?> GetByIdAsync(int id);
    Task AddAsync(Auditoria auditoria);
}