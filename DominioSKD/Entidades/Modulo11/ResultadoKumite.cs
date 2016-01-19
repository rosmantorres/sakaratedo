using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo11
{
    public class ResultadoKumite : Entidad
    {
        #region Atributos
        private int puntaje1;
        private int puntaje2;
        private DominioSKD.Entidades.Modulo10.Inscripcion inscripcion1;
        private DominioSKD.Entidades.Modulo10.Inscripcion inscripcion2;
        #endregion

        #region Constructores
        public ResultadoKumite(int puntaje1, int puntaje2, DominioSKD.Entidades.Modulo10.Inscripcion inscripcion1, DominioSKD.Entidades.Modulo10.Inscripcion inscripcion2)
        {
            this.puntaje1 = puntaje1;
            this.puntaje2 = puntaje2;
            this.inscripcion1 = inscripcion1;
            this.inscripcion2 = inscripcion2;
        }

        public ResultadoKumite()
        {
            this.puntaje1 = 0;
            this.puntaje2 = 0;
            this.inscripcion1 = new Modulo10.Inscripcion();
            this.inscripcion2 = new Modulo10.Inscripcion();
        }
        #endregion

        #region Propiedades
        public int Puntaje1
        {
            get { return puntaje1; }
            set { puntaje1 = value; }
        }
        public int Puntaje2
        {
            get { return puntaje2; }
            set { puntaje2 = value; }
        }
        public DominioSKD.Entidades.Modulo10.Inscripcion Inscripcion1
        {
            get { return inscripcion1; }
            set { inscripcion1 = value; }
        }
        public DominioSKD.Entidades.Modulo10.Inscripcion Inscripcion2
        {
            get { return inscripcion2; }
            set { inscripcion2 = value; }
        }
        #endregion
    }
}
