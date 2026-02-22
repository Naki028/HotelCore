using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Application.Interfaces;

namespace HotelCore.Infrastructure.Email;

public class EmailService : IEmailService
{
    public Task EnviarEmailAsync(string destinatario, string asunto, string mensaje)
    {
        // Simulación para esta entrega
        Console.WriteLine($"Enviando email a {destinatario}");
        Console.WriteLine($"Asunto: {asunto}");
        Console.WriteLine($"Mensaje: {mensaje}");

        return Task.CompletedTask;
    }
}