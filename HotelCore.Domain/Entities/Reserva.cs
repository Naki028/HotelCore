using HotelCore.Domain.Common;
using HotelCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Domain.Entities;

public class Reserva : BaseEntity
{
    public int ClienteId { get; private set; }
    public int HabitacionId { get; private set; }
    public DateTime FechaInicio { get; private set; }
    public DateTime FechaFin { get; private set; }
    public decimal Total { get; private set; }
    public EstadoReserva Estado { get; private set; }

    public Reserva(int clienteId, int habitacionId, DateTime inicio, DateTime fin, decimal total)
    {
        ClienteId = clienteId;
        HabitacionId = habitacionId;
        FechaInicio = inicio;
        FechaFin = fin;
        Total = total;
        Estado = EstadoReserva.Pendiente;
    }

    public void Cancelar()
    {
        Estado = EstadoReserva.Cancelada;
        SetUpdated();
    }
}