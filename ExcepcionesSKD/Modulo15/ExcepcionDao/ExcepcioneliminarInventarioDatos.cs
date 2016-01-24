using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
   public class ExcepcioneliminarInventarioDatos : ExceptionSKD
    {
         public ExcepcioneliminarInventarioDatos()
            : base()
        { }

        public ExcepcioneliminarInventarioDatos(string message)
            : base(message)
        {
        }

        public ExcepcioneliminarInventarioDatos(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcioneliminarInventarioDatos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
