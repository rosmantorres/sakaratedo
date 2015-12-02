using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo7
{
    public class ListaVaciaException : ExceptionSKD
    {
        public ListaVaciaException() : base()
        { }

        public ListaVaciaException(string message)
            : base(message)
        {
        }

        public ListaVaciaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ListaVaciaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
