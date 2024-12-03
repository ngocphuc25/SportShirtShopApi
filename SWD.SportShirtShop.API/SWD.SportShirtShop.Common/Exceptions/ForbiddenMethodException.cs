using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Common.Exceptions
{
    public class ForbiddenMethodException : ApplicationException
    {
        public ForbiddenMethodException(string message) : base(message)
        {
        }
    }
}