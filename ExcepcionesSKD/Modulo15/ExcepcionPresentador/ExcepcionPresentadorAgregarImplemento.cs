using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionPresentador
{
    public class ExcepcionPresentadorAgregarImplemento : ExceptionSKD
    {
            public ExcepcionPresentadorAgregarImplemento()
            : base()
        { }

        public ExcepcionPresentadorAgregarImplemento(string message)
            : base(message)
        {
        }

        public ExcepcionPresentadorAgregarImplemento(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionPresentadorAgregarImplemento(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
