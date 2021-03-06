﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionPresentador
{
    public class ExcepcionPresentadorConsultarImplemento : ExceptionSKD
    {

         public ExcepcionPresentadorConsultarImplemento()
            : base()
        { }

        public ExcepcionPresentadorConsultarImplemento(string message)
            : base(message)
        {
        }

        public ExcepcionPresentadorConsultarImplemento(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionPresentadorConsultarImplemento(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
