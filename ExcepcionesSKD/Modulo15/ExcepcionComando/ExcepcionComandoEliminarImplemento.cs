using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
    public class ExcepcionComandoEliminarImplemento : ExceptionSKD
    {
         public ExcepcionComandoEliminarImplemento()
            : base()
        { }

        public ExcepcionComandoEliminarImplemento(string message)
            : base(message)
        {
        }

        public ExcepcionComandoEliminarImplemento(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoEliminarImplemento(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
