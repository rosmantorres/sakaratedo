using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
    public class ExcepcionComandoDojoId : ExceptionSKD
    {
         public ExcepcionComandoDojoId()
            : base()
        { }

        public ExcepcionComandoDojoId(string message)
            : base(message)
        {
        }

        public ExcepcionComandoDojoId(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoDojoId(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
