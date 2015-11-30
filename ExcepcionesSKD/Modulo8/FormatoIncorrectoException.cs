using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo8
{
    public class FormatoIncorrectoException : ExceptionSKD
    {
        public FormatoIncorrectoException() : base()
        {}

        public FormatoIncorrectoException(string message)
            : base(message)
        {
        }

        public FormatoIncorrectoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public FormatoIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
