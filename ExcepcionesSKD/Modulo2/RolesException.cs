using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo2
{
    public class RolesException : ExceptionSKD
    {
        public RolesException()
            : base()
        { }

        public RolesException(string message)
            : base(message)
        {
        }

        public RolesException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public RolesException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
