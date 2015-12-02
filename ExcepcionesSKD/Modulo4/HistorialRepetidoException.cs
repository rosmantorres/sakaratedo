using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo4
{
    public class HistorialExistenteException : ExceptionSKD
    {
        public HistorialExistenteException() : base()
        {}

        public HistorialExistenteException(string message)
            : base(message)
        {
        }

        public HistorialExistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public HistorialExistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
