using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class TipoPlanilla
    {
        #region atributos
       
        private string nombre;

        #endregion

        #region metodos

        public TipoPlanilla(string nombre)
        {
            this.nombre = nombre;
        }
        #endregion

        #region gets y sets

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion



    }
}
