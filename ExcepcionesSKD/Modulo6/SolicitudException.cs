using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo6
{
    public class SolicitudException : ExceptionSKD
    {
        public SolicitudException() : base()
        {}

        public SolicitudException(string message)
            : base(message)
        {
        }

        public SolicitudException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public SolicitudException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
