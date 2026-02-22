using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelCore.Domain.Common;
using HotelCore.Domain.Enums;

namespace HotelCore.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public RolUsuario Rol { get; private set; }

        public Usuario(string username, string passwordHash, RolUsuario rol)
        {
            Username = username;
            PasswordHash = passwordHash;
            Rol = rol;
        }

        public bool ValidarPassword(string password)
        {
            return PasswordHash == password;
        }
    }
}