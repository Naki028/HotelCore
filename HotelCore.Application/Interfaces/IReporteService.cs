using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.Interfaces;

public interface IReporteService
{
    Task<decimal> ObtenerIngresosPorFechaAsync(DateTime inicio, DateTime fin);
    Task<int> ObtenerReservasActivasAsync();
}