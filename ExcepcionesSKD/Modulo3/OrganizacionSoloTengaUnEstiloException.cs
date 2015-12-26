using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo3
{
    public class OrganizacionSoloTengaUnEstiloException : ExceptionSKD
    {
        public OrganizacionSoloTengaUnEstiloException()
            : base()
        { }

        public OrganizacionSoloTengaUnEstiloException(string message)
            : base(message)
        {
        }

        public OrganizacionSoloTengaUnEstiloException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public OrganizacionSoloTengaUnEstiloException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
