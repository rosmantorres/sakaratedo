using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
   public class ExcepcionListarInventarioDatos : ExceptionSKD
    {
        public ExcepcionListarInventarioDatos()
            : base()
        { }

        public ExcepcionListarInventarioDatos(string message)
            : base(message)
        {
        }

        public ExcepcionListarInventarioDatos(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionListarInventarioDatos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
