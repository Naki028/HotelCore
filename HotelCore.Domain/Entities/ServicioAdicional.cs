using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Common;

namespace HotelCore.Domain.Entities
{
    public class ServicioAdicional : BaseEntity
    {
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }

        public ServicioAdicional(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}