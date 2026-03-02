using HotelCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Domain.Entities;

public class Cliente : BaseEntity
{
    public string NombreCompleto { get; private set; }
    public string Documento { get; private set; }
    public string Email { get; private set; }
    public string Telefono { get; private set; }

    public Cliente(string nombreCompleto, string documento, string email, string telefono)
    {
        NombreCompleto = nombreCompleto;
        Documento = documento;
        Email = email;
        Telefono = telefono;
    }
}