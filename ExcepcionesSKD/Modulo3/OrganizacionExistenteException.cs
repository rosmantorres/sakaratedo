using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo3
{
    public class OrganizacionExistenteException : ExceptionSKD
    {
        public OrganizacionExistenteException()
            : base()
        { }

        public OrganizacionExistenteException(string message)
            : base(message)
        {
        }

        public OrganizacionExistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public OrganizacionExistenteException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
