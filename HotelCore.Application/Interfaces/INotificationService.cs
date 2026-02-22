using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.Interfaces
{
    public interface INotificationService
    {
        Task NotificarAsync(string usuarioId, string mensaje);
    }
}
