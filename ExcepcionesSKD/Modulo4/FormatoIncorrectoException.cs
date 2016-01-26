using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo4
{
    /// <summary>
    /// Excepcion de errores en formatos en la bd
    /// con código y mensaje que corresponda
    /// </summary>
    public class FormatoIncorrectoException : ExceptionSKD
    {
        public FormatoIncorrectoException()
            : base()
        { }

        public FormatoIncorrectoException(string message)
            : base(message)
        {
        }

        public FormatoIncorrectoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public FormatoIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
