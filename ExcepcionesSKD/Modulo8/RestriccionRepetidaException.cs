using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo8
{
    public class RestriccionRepetidaException : ExceptionSKD
    {
        public RestriccionRepetidaException()
            : base()
        { }

        public RestriccionRepetidaException(string message)
            : base(message)
        {
        }

        public RestriccionRepetidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public RestriccionRepetidaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
