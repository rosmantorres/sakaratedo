using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo5
{
    public class CintaRepetidaException : ExceptionSKD
    {
        public CintaRepetidaException()
            : base()
        { }

        public CintaRepetidaException(string message)
            : base(message)
        {
        }

        public CintaRepetidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CintaRepetidaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
