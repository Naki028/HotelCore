using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Exceptions;

public abstract class BaseException : Exception
{
    public string ErrorCode { get; }

    protected BaseException(string message, string errorCode)
        : base(message)
    {
        ErrorCode = errorCode;
    }
}