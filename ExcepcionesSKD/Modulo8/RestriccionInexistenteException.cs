using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo12
{
    public class RestriccionNoExisteException : ExceptionSKD
    {
        public RestriccionNoExisteException()
            : base()
        { }

        public RestriccionNoExisteException(string message)
            : base(message)
        {
        }

        public RestriccionNoExisteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public RestriccionNoExisteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
