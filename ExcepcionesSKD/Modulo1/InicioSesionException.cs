using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo1
{
    public class InicioSesionException : ExceptionSKD
    {
         public InicioSesionException() : base()
        {}

        public InicioSesionException(string message)
            : base(message)
        {
        }

        public InicioSesionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InicioSesionException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
