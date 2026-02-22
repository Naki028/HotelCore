using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.DTOs;

public class HabitacionDTO
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}