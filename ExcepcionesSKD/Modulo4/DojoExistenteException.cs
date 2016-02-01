using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo4
{
    public class DojoExistenteException : ExceptionSKD
    {
        public DojoExistenteException() : base()
        {}

        public DojoExistenteException(string message)
            : base(message)
        {
        }

        public DojoExistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public DojoExistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
