using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
  public  class ExcepcionmodificarInventarioDatos : ExceptionSKD
    {
          public ExcepcionmodificarInventarioDatos()
            : base()
        { }

        public ExcepcionmodificarInventarioDatos(string message)
            : base(message)
        {
        }

        public ExcepcionmodificarInventarioDatos(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionmodificarInventarioDatos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
