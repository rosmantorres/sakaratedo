﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo5
{
    public class OrganizacionInexistenteException : ExceptionSKD
    {
        public OrganizacionInexistenteException()
            : base()
        { }

        public OrganizacionInexistenteException(string message)
            : base(message)
        {
        }

        public OrganizacionInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public OrganizacionInexistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
