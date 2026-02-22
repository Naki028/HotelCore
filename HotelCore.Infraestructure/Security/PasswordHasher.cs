using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using HotelCore.Application.Interfaces;

namespace HotelCore.Infrastructure.Security;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public bool Verify(string hash, string password)
    {
        var newHash = Hash(password);
        return newHash == hash;
    }
}