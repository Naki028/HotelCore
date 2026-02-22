using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.DTOs;

public class ReservaDTO
{
    public int Id { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string Habitacion { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = string.Empty;
}