using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
    
        public class ExcepcionComandoAgregarImplemento : ExceptionSKD
    {
         public ExcepcionComandoAgregarImplemento()
            : base()
        { }

        public ExcepcionComandoAgregarImplemento(string message)
            : base(message)
        {
        }

        public ExcepcionComandoAgregarImplemento(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoAgregarImplemento(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
