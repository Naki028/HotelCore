using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCore.Exceptions;

public class BusinessRuleException : BaseException
{
    public BusinessRuleException(string message)
        : base(message, "BUSINESS_RULE_VIOLATION")
    {
    }
}