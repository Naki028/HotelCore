using AutoMapper;
using HotelCore.Application.DTOs;
using HotelCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelCore.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cliente, ClienteDTO>().ReverseMap();
        CreateMap<Habitacion, HabitacionDTO>().ReverseMap();
        CreateMap<ServicioAdicional, ServicioDTO>().ReverseMap();
        CreateMap<Reserva, ReservaDTO>();
    }
}