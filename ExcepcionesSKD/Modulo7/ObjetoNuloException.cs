using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo7
{
    public class ObjetoNuloException : ExceptionSKD
    {
        public ObjetoNuloException() : base()
        { }

        public ObjetoNuloException(string message)
            : base(message)
        {
        }

        public ObjetoNuloException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ObjetoNuloException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
