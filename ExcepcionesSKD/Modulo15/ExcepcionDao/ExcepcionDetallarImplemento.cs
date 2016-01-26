using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
   public class ExcepcionDetallarImplemento : ExceptionSKD
    {
         public ExcepcionDetallarImplemento()
            : base()
        { }

        public ExcepcionDetallarImplemento(string message)
            : base(message)
        {
        }

        public ExcepcionDetallarImplemento(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionDetallarImplemento(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
