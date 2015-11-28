using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo12
{
    public class CompetenciaInexistenteException : ExceptionSKD
    {
        public CompetenciaInexistenteException() : base()
        {}

        public CompetenciaInexistenteException(string message)
            : base(message)
        {
        }

        public CompetenciaInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CompetenciaInexistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
