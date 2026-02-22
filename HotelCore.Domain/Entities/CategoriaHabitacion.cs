using HotelCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Domain.Entities;

public class CategoriaHabitacion : BaseEntity
{
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }

    public CategoriaHabitacion(string nombre, string descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }
}