using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo5
{
    public class ExpresionesRegularesException : ExceptionSKD
    {
         public ExpresionesRegularesException()
            : base()
        { }

        public ExpresionesRegularesException(string message)
            : base(message)
        {
        }

        public ExpresionesRegularesException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExpresionesRegularesException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
