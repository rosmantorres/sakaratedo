using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15
{
    public class ErrorEnParametroDeProcedure : ExceptionSKD
    {
        public ErrorEnParametroDeProcedure()
            : base()
        { }

        public ErrorEnParametroDeProcedure(string message)
            : base(message)
        {
        }

        public ErrorEnParametroDeProcedure(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorEnParametroDeProcedure(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
