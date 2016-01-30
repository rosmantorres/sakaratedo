using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo7
{
    public class TipoEventoM7 : Entidad
    {
        #region Atributos
        private String nombre;
        #endregion

        #region Constructores
        public TipoEventoM7()
        {
            nombre = "";
        }
        #endregion

        #region Propiedades


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion
    }
}
