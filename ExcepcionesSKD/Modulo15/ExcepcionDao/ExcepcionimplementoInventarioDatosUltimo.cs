using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
   public class ExcepcionimplementoInventarioDatosUltimo : ExceptionSKD
    {
       public ExcepcionimplementoInventarioDatosUltimo()
            : base()
        { }

        public ExcepcionimplementoInventarioDatosUltimo(string message)
            : base(message)
        {
        }

        public ExcepcionimplementoInventarioDatosUltimo(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionimplementoInventarioDatosUltimo(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
