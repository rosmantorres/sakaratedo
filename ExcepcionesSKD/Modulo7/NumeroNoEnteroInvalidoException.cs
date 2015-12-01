using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo7
{
    public class NumeroNoEnteroInvalidoException : ExceptionSKD
    {
        public NumeroNoEnteroInvalidoException() : base()
        { }

        public NumeroNoEnteroInvalidoException(string message)
            : base(message)
        {
        }

        public NumeroNoEnteroInvalidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public NumeroNoEnteroInvalidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
