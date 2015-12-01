using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    class ExceptionTipoPlanilla : ExceptionSKD
    {
           public ExceptionTipoPlanilla()
            : base()
        { }

        public ExceptionTipoPlanilla(string message)
            : base(message)
        {
        }

        public ExceptionTipoPlanilla(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionTipoPlanilla(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
