using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidadorCPF.Dominio;

namespace ValidadorCPF.WebAPI.Exceptions
{
    [Serializable]
    public class NotFoundCpfException : Exception 
    {
        public NotFoundCpfException() : base("CPF not found.") { }
        public NotFoundCpfException(string message) : base(message)  { }
        public NotFoundCpfException(string message, Exception inner) : base(message, inner) { }
    }
}
