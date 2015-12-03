using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo8
{
    public class RestriccionExistenteException : ExceptionSKD
    {
        public RestriccionExistenteException() : base()
        {}

        public RestriccionExistenteException(string message)
            : base(message)
        {
        }

        public RestriccionExistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public RestriccionExistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
