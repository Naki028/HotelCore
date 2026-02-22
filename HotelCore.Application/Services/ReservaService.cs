using AutoMapper;
using HotelCore.Application.DTOs;
using HotelCore.Application.Interfaces;
using HotelCore.Domain.Entities;
using HotelCore.Domain.Enums;
using HotelCore.Domain.Interfaces;

namespace HotelCore.Application.Services;

public class ReservaService : IReservaService
{
    private readonly IReservaRepository _repository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IHabitacionRepository _habitacionRepository;
    private readonly IServicioRepository _servicioRepository;
    private readonly ITarifaService _tarifaService;
    private readonly IMapper _mapper;

    public ReservaService(
        IReservaRepository repository,
        IClienteRepository clienteRepository,
        IHabitacionRepository habitacionRepository,
        IServicioRepository servicioRepository,
        ITarifaService tarifaService,
        IMapper mapper)
    {
        _repository = repository;
        _clienteRepository = clienteRepository;
        _habitacionRepository = habitacionRepository;
        _servicioRepository = servicioRepository;
        _tarifaService = tarifaService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReservaDTO>> GetAllAsync()
    {
        var reservas = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ReservaDTO>>(reservas);
    }

    public async Task<ReservaDTO?> GetByIdAsync(int id)
    {
        var reserva = await _repository.GetByIdAsync(id);
        return reserva == null ? null : _mapper.Map<ReservaDTO>(reserva);
    }

    public async Task<int> CrearReservaAsync(CrearReservaDTO dto)
    {
        var habitacion = await _habitacionRepository.GetByIdAsync(dto.HabitacionId);
        if (habitacion == null)
            throw new Exception("Habitación no encontrada");

        if (habitacion.Estado != Domain.Enums.EstadoHabitacion.Disponible)
            throw new Exception("Habitación no disponible");

        var total = await _tarifaService.CalcularTarifaAsync(
            habitacion.CategoriaId,
            dto.FechaInicio,
            dto.FechaFin);

        var reserva = new Reserva(
            dto.ClienteId,
            dto.HabitacionId,
            dto.FechaInicio,
            dto.FechaFin,
            total);

        await _repository.AddAsync(reserva);

        return reserva.Id;
    }

    public async Task CancelarReservaAsync(int id)
    {
        var reserva = await _repository.GetByIdAsync(id);
        if (reserva == null) throw new Exception("Reserva no encontrada");

        reserva.Cancelar();
        await _repository.UpdateAsync(reserva);
    }
}
