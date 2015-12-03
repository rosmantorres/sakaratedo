using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo15
{
    public class ErrorInputInterfaz : ExceptionSKD
    {
        
        public ErrorInputInterfaz()
            : base()
        { }

        public ErrorInputInterfaz(string message)
            : base(message)
        {
        }

        public ErrorInputInterfaz(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorInputInterfaz(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
