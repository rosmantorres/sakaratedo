using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo5
{
    public class OrdenCintaRepetidoException : ExceptionSKD
    {
        public OrdenCintaRepetidoException()
            : base()
        { }

        public OrdenCintaRepetidoException(string message)
            : base(message)
        {
        }

        public OrdenCintaRepetidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public OrdenCintaRepetidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
