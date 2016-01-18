using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    public class TipoPlanilllaRepetidaException:ExceptionSKD
    {
        public TipoPlanilllaRepetidaException(): base()
        { }

        public TipoPlanilllaRepetidaException(string message)
            : base(message)
        { 
        }

        public TipoPlanilllaRepetidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public TipoPlanilllaRepetidaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
