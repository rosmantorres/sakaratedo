using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo1
{
    public class HashException : ExceptionSKD
    {
        public HashException()
            : base()
        { }

        public HashException(string message)
            : base(message)
        {
        }

        public HashException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public HashException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
