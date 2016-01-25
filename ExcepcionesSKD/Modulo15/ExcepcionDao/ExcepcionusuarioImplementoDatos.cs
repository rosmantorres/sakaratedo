using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
   public class ExcepcionusuarioImplementoDatos : ExceptionSKD
    {
         public ExcepcionusuarioImplementoDatos()
            : base()
        { }

        public ExcepcionusuarioImplementoDatos(string message)
            : base(message)
        {
        }

        public ExcepcionusuarioImplementoDatos(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionusuarioImplementoDatos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
