using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelCore.Application.DTOs;
using HotelCore.Application.Interfaces;
using HotelCore.Domain.Interfaces;

namespace HotelCore.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
    }

    public async Task<ClienteDTO?> GetByIdAsync(int id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        return cliente == null ? null : _mapper.Map<ClienteDTO>(cliente);
    }

    public async Task<int> CreateAsync(ClienteDTO dto)
    {
        var entity = _mapper.Map<Domain.Entities.Cliente>(dto);
        await _repository.AddAsync(entity);
        return entity.Id;
    }

    public async Task UpdateAsync(int id, ClienteDTO dto)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception("Cliente no encontrado");

        _mapper.Map(dto, entity);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}