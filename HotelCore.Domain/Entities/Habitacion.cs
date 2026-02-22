using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Common;
using HotelCore.Domain.Enums;

namespace HotelCore.Domain.Entities
{
    public class Habitacion : BaseEntity
    {
        public string Numero { get; private set; }
        public int CategoriaId { get; private set; }
        public EstadoHabitacion Estado { get; private set; }

        public Habitacion(string numero, int categoriaId)
        {
            Numero = numero;
            CategoriaId = categoriaId;
            Estado = EstadoHabitacion.Disponible;
        }

        public void CambiarEstado(EstadoHabitacion nuevoEstado)
        {
            Estado = nuevoEstado;
        }
    }
}