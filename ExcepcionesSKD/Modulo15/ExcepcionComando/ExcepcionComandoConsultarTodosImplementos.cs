using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
   public class ExcepcionComandoConsultarTodosImplementos : ExceptionSKD
    {
        public ExcepcionComandoConsultarTodosImplementos()
            : base()
        { }

        public ExcepcionComandoConsultarTodosImplementos(string message)
            : base(message)
        {
        }

        public ExcepcionComandoConsultarTodosImplementos(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoConsultarTodosImplementos(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
