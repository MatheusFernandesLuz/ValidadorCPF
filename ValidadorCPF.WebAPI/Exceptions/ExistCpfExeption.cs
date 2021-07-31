using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidadorCPF.WebAPI.Exceptions
{
    public class ExistCpfExeption : Exception
    {
        public ExistCpfExeption() : base("CPF already exists.") { }
        public ExistCpfExeption(string message) : base(message) { }
        public ExistCpfExeption(string message, Exception inner) : base(message, inner) { }
    }
}
