using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo4
{
    /// <summary>
    /// E
    /// xcepcion de existencia de dojos en la bd
    /// con código y mensaje que corresponda
    /// </summary>
    public class DojoInexistenteException : ExceptionSKD
    {
        public DojoInexistenteException() : base()
        {}

        public DojoInexistenteException(string message)
            : base(message)
        {
        }

        public DojoInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public DojoInexistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
