using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.DTOs;

public class CrearReservaDTO
{
    public int ClienteId { get; set; }
    public int HabitacionId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public List<int> ServiciosIds { get; set; } = new();
}