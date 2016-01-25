using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
    public class ExcepcionlistaInventarioDatos2 : ExceptionSKD
    {
         public ExcepcionlistaInventarioDatos2()
            : base()
        { }

        public ExcepcionlistaInventarioDatos2(string message)
            : base(message)
        {
        }

        public ExcepcionlistaInventarioDatos2(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionlistaInventarioDatos2(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
