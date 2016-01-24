using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
    public class ExcepcionimplementoInventarioDatos : ExceptionSKD

    {
          public ExcepcionimplementoInventarioDatos()
            : base()
        { }

        public ExcepcionimplementoInventarioDatos(string message)
            : base(message)
        {
        }

        public ExcepcionimplementoInventarioDatos(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionimplementoInventarioDatos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
