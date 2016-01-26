using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
    public class ExcepcionComandoConsultarTodosImplementos2 : ExceptionSKD
    {
         public ExcepcionComandoConsultarTodosImplementos2()
            : base()
        { }

        public ExcepcionComandoConsultarTodosImplementos2(string message)
            : base(message)
        {
        }

        public ExcepcionComandoConsultarTodosImplementos2(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoConsultarTodosImplementos2(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
