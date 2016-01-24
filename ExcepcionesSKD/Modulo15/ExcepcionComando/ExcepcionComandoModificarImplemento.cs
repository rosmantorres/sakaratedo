using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
    public class ExcepcionComandoModificarImplemento : ExceptionSKD
    {
         public ExcepcionComandoModificarImplemento()
            : base()
        { }

        public ExcepcionComandoModificarImplemento(string message)
            : base(message)
        {
        }

        public ExcepcionComandoModificarImplemento(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoModificarImplemento(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
