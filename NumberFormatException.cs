using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class NumberFormatException : Exception
    {
        public NumberFormatException()
        {
        }
        public NumberFormatException(string message) : base(message)
        {
        }
        public NumberFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
