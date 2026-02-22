using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Application.Interfaces;

public interface IUsuarioService
{
    Task<string> LoginAsync(string username, string password);
}