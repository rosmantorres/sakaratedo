using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    public class PlanillaRepetidaException: ExceptionSKD
    {
        public PlanillaRepetidaException(): base()
        { }

        public PlanillaRepetidaException(string message)
            : base(message)
        { 
        }

        public PlanillaRepetidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public PlanillaRepetidaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
