using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelCore.Domain.Entities
{
    public class Auditoria
    {
        public Guid Id { get; set; }
        public string Accion { get; set; }
        public string Entidad { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}