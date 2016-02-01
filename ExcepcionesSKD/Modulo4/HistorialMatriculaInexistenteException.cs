using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo4
{
    public class HistorialMatriculaInexistenteException : ExceptionSKD
    {
        public HistorialMatriculaInexistenteException() : base()
        {}

        public HistorialMatriculaInexistenteException(string message)
            : base(message)
        {
        }

        public HistorialMatriculaInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public HistorialMatriculaInexistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
