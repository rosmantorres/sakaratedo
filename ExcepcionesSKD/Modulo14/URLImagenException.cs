using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo14
{
    public class URLImagenException: ExceptionSKD
    {
         public URLImagenException(): base()
        { }

        public URLImagenException(string message)
            : base(message)
        { 
        }

        public URLImagenException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public URLImagenException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
