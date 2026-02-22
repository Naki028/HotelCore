using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmailAsync(string destinatario, string asunto, string mensaje);
    }
}
