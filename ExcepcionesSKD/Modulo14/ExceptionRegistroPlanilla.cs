using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    class ExceptionRegistroPlanilla :ExceptionSKD
    {
           public ExceptionRegistroPlanilla()
            : base()
        { }

        public ExceptionRegistroPlanilla(string message)
            : base(message)
        {
        }

        public ExceptionRegistroPlanilla(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionRegistroPlanilla(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
