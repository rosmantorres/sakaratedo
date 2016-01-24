using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
    public class ExcepcionDetallarDojo : ExceptionSKD
    {
         public ExcepcionDetallarDojo()
            : base()
        { }

        public ExcepcionDetallarDojo(string message)
            : base(message)
        {
        }

        public ExcepcionDetallarDojo(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionDetallarDojo(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
