using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelCore.Domain.Common;

namespace HotelCore.Domain.Entities;

public class ReservaServicio : BaseEntity
{
    public int ReservaId { get; private set; }
    public int ServicioId { get; private set; }

    public ReservaServicio(int reservaId, int servicioId)
    {
        ReservaId = reservaId;
        ServicioId = servicioId;
    }
}