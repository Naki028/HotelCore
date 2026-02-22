using System;
using System.Threading.Tasks;
using HotelCore.Application.Interfaces;
using HotelCore.Domain.Interfaces;

namespace HotelCore.Application.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        public async Task<decimal> CalcularTarifaAsync(int categoriaId, DateTime inicio, DateTime fin)
        {
            if (inicio >= fin)
                throw new Exception("Rango de fechas invalido");

            var tarifa = await _tarifaRepository.ObtenerTarifaVigenteAsync(categoriaId, inicio);
            if (tarifa == null)
                throw new Exception("No existe tarifa vigente");

            var dias = (fin - inicio).Days;
            return tarifa.PrecioBase * dias;
        }
    }
}