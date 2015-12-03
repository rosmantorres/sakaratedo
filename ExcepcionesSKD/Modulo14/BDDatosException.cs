using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    public class BDDatosException : ExceptionSKD
    {
        public BDDatosException(): base()
        { }

        public BDDatosException(string message)
            : base(message)
        { 
        }

        public BDDatosException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BDDatosException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
