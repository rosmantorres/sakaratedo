using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    public class BDDiseñoException : ExceptionSKD
    {
        public BDDiseñoException(): base()
        { }

        public BDDiseñoException(string message)
            : base(message)
        { 
        }

        public BDDiseñoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BDDiseñoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
