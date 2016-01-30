using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo11
{
    public class ValorKataKumite
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string resultado1;

        public string Resultado1
        {
            get { return resultado1; }
            set { resultado1 = value; }
        }
        private string resultado2;

        public string Resultado2
        {
            get { return resultado2; }
            set { resultado2 = value; }
        }
        private string resultado3;

        public string Resultado3
        {
            get { return resultado3; }
            set { resultado3 = value; }
        }

        public ValorKataKumite()
        {
            this.nombre = "";
            this.resultado1 = "";
            this.resultado2 = "";
            this.resultado3 = "";
        }
    }
}
