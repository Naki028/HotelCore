using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.DTOs;

public class ClienteDTO
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
}