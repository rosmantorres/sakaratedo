using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15
{
    public class ImplementoSinIDException : ExceptionSKD
    {
        public ImplementoSinIDException()
            : base()
        { }

        public ImplementoSinIDException(string message)
            : base(message)
        {
        }

        public ImplementoSinIDException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ImplementoSinIDException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
