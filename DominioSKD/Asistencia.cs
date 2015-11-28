using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Asistencia
    {
        #region Atributos
        private string asistio;
        private Inscripcion inscripcion;
        #endregion

        #region Constructores
        public Asistencia(String asistio, Inscripcion inscripcion)
        {
            this.asistio = asistio;
            this.inscripcion = inscripcion;
        }

        public Asistencia()
        {
            this.asistio = " ";
            this.inscripcion = new Inscripcion();
        }

        #endregion

        #region Propiedades
        public String Asistio
        {
            get { return asistio; }
            set { asistio = value; }
        }

        public Inscripcion Inscripcion
        {
            get { return inscripcion; }
            set { inscripcion = value; }
        }
        #endregion
    }
}
