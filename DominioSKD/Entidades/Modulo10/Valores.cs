using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo10
{
    public class Valores : Entidad
    {
        private string nombre;
        private string tipo;
        public Valores()
        {
            this.Id = 0;
            this.nombre = "";
            this.tipo = "";
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
