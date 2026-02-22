using HotelCore.Application.Interfaces;
using HotelCore.Domain.Interfaces;

namespace HotelCore.Application.Services;

public class ReporteService : IReporteService
{
    private readonly IReservaRepository _reservaRepository;

    public ReporteService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task<decimal> ObtenerIngresosPorFechaAsync(DateTime inicio, DateTime fin)
    {
        return await _reservaRepository.CalcularIngresosAsync(inicio, fin);
    }

    public async Task<int> ObtenerReservasActivasAsync()
    {
        var reservas = await _reservaRepository.GetActivasAsync();
        return reservas.Count();
    }
}