﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15.ExcepcionComando
{
    public class ExcepcionComandoUsuarioDojo : ExceptionSKD
    {
         public ExcepcionComandoUsuarioDojo()
            : base()
        { }

        public ExcepcionComandoUsuarioDojo(string message)
            : base(message)
        {
        }

        public ExcepcionComandoUsuarioDojo(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExcepcionComandoUsuarioDojo(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
