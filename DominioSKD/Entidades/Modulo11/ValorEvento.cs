using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo11
{
    public class ValorEvento
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string resultado;

        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public ValorEvento()
        {
            this.nombre = "";
            this.resultado = "";
        }
    }
}
