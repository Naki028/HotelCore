using AutoMapper;
using HotelCore.Application.DTOs;
using HotelCore.Application.Interfaces;
using HotelCore.Domain.Entities;
using HotelCore.Domain.Interfaces;

namespace HotelCore.Application.Services;

public class ServicioService : IServicioService
{
    private readonly IServicioRepository _repository;
    private readonly IMapper _mapper;

    public ServicioService(IServicioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServicioDTO>> GetAllAsync()
    {
        var servicios = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ServicioDTO>>(servicios);
    }

    public async Task<int> CreateAsync(ServicioDTO dto)
    {
        var entity = _mapper.Map<ServicioAdicional>(dto);
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}