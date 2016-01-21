using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo11
{
    public class ResultadoAscenso : Entidad
    {
        #region Atributos
        private string aprobado;
        private DominioSKD.Entidades.Modulo10.Inscripcion inscripcion;
        #endregion

        #region Constructores
        public ResultadoAscenso(string aprobado, DominioSKD.Entidades.Modulo10.Inscripcion inscripcion)
        {
            this.aprobado = aprobado;
            this.inscripcion = inscripcion;
        }
        public ResultadoAscenso()
        {
            this.aprobado = " ";
            this.inscripcion = new Modulo10.Inscripcion();
        }
        #endregion

        #region Propiedades
        public string Aprobado
        {
            get { return aprobado; }
            set { aprobado = value; }
        }
        public DominioSKD.Entidades.Modulo10.Inscripcion Inscripcion
        {
            get { return inscripcion; }
            set { inscripcion = value; }
        }
        #endregion
    }
}
