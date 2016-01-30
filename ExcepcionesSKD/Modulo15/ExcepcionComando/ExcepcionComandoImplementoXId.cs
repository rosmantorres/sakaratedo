using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
    public class ExcepcionComandoImplementoXId : ExceptionSKD
    {
         public ExcepcionComandoImplementoXId()
            : base()
        { }

        public ExcepcionComandoImplementoXId(string message)
            : base(message)
        {
        }

        public ExcepcionComandoImplementoXId(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoImplementoXId(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
