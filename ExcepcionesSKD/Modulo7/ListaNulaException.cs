using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo7
{
    public class ListaNulaException : ExceptionSKD
    {
        public ListaNulaException() : base()
        { }

        public ListaNulaException(string message)
            : base(message)
        {
        }

        public ListaNulaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ListaNulaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
