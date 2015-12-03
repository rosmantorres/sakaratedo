using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo12
{
    public class CompetenciaExistenteException : ExceptionSKD
    {
        public CompetenciaExistenteException() : base()
        {}

        public CompetenciaExistenteException(string message)
            : base(message)
        {
        }

        public CompetenciaExistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CompetenciaExistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
