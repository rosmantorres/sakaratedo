using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo5
{
    public class ListaVaciaExcepcion : ExceptionSKD
    {
        public ListaVaciaExcepcion()
            : base()
        { }

        public ListaVaciaExcepcion(string message)
            : base(message)
        {
        }

        public ListaVaciaExcepcion(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ListaVaciaExcepcion(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
