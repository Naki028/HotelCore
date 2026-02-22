using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.Interfaces;

public interface ITarifaService
{
    Task<decimal> CalcularTarifaAsync(int categoriaId, DateTime fechaInicio, DateTime fechaFin);
}