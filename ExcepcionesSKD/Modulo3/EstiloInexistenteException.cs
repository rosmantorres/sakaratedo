using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo3
{
    public class EstiloInexistenteException : ExceptionSKD
    {
        public EstiloInexistenteException()
            : base()
        { }

        public EstiloInexistenteException(string message)
            : base(message)
        {
        }

        public EstiloInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public EstiloInexistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
