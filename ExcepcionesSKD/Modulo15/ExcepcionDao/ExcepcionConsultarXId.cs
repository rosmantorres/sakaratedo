using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;

namespace ExcepcionesSKD.Modulo15.ExcepcionDao
{
    public class ExcepcionConsultarXId : ExceptionSKD
    {
         public ExcepcionConsultarXId()
            : base()
        { }

        public ExcepcionConsultarXId(string message)
            : base(message)
        {
        }

        public ExcepcionConsultarXId(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionConsultarXId(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
