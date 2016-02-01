using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo4
{
    public class HistorialMatriculaExistenteException: ExceptionSKD
    {
        public HistorialMatriculaExistenteException() : base()
        {}

        public HistorialMatriculaExistenteException(string message)
            : base(message)
        {
        }

        public HistorialMatriculaExistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public HistorialMatriculaExistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
