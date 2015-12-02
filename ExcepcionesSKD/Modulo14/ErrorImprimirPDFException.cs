using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    class ErrorImprimirPDFException : ExceptionSKD
    {
        public ErrorImprimirPDFException(): base()
        { }

        public ErrorImprimirPDFException(string message)
            : base(message)
        { 
        }

        public ErrorImprimirPDFException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorImprimirPDFException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
