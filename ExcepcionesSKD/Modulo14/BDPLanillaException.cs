using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    class BDPLanillaException : ExceptionSKD
    {
        public BDPLanillaException(): base()
        { }

        public BDPLanillaException(string message)
            : base(message)
        { 
        }

        public BDPLanillaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BDPLanillaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
