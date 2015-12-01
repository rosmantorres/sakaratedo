using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    class ExceptionDatoPlanilla : ExceptionSKD
    {
          public ExceptionDatoPlanilla()
            : base()
        { }

        public ExceptionDatoPlanilla(string message)
            : base(message)
        {
        }

        public ExceptionDatoPlanilla(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionDatoPlanilla(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
