using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidadorCPF.WebAPI.Exceptions
{
    public class InvalidCpfException : Exception
    {
        public InvalidCpfException() : base("CPF is not valid.") { }
        public InvalidCpfException(string message) : base(message) { }
        public InvalidCpfException(string message, Exception inner) : base(message, inner) { }
    }
}
