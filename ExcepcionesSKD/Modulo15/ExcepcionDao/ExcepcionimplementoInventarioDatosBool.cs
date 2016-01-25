using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
    public class ExcepcionimplementoInventarioDatosBool : ExceptionSKD
    {
          public ExcepcionimplementoInventarioDatosBool()
            : base()
        { }

        public ExcepcionimplementoInventarioDatosBool(string message)
            : base(message)
        {
        }

        public ExcepcionimplementoInventarioDatosBool(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionimplementoInventarioDatosBool(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
