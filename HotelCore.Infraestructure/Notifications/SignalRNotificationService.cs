using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Application.Interfaces;

namespace HotelCore.Infrastructure.Notifications;

public class SignalRNotificationService : INotificationService
{
    public Task NotificarAsync(string usuarioId, string mensaje)
    {
        Console.WriteLine($"Notificacion para usuario {usuarioId}: {mensaje}");
        return Task.CompletedTask;
    }
}