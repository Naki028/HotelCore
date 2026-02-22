using AutoMapper;
using HotelCore.Application.DTOs;
using HotelCore.Application.Interfaces;
using HotelCore.Domain.Enums;
using HotelCore.Domain.Interfaces;

namespace HotelCore.Application.Services;

public class HabitacionService : IHabitacionService
{
    private readonly IHabitacionRepository _repository;
    private readonly IMapper _mapper;

    public HabitacionService(IHabitacionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HabitacionDTO>> GetAllAsync()
    {
        var habitaciones = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<HabitacionDTO>>(habitaciones);
    }

    public async Task<HabitacionDTO?> GetByIdAsync(int id)
    {
        var habitacion = await _repository.GetByIdAsync(id);
        return habitacion == null ? null : _mapper.Map<HabitacionDTO>(habitacion);
    }

    public async Task UpdateEstadoAsync(int id, string estado)
    {
        var habitacion = await _repository.GetByIdAsync(id);
        if (habitacion == null) throw new Exception("Habitación no encontrada");

        habitacion.CambiarEstado(Enum.Parse<EstadoHabitacion>(estado));
        await _repository.UpdateAsync(habitacion);
    }
}