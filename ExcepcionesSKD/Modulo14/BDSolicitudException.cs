using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    public class BDSolicitudException : ExceptionSKD
    {
        public BDSolicitudException(): base()
        { }

        public BDSolicitudException(string message)
            : base(message)
        { 
        }

        public BDSolicitudException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BDSolicitudException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
