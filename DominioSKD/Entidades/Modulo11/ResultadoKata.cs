using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo11
{
    public class ResultadoKata : Entidad
    {
        #region Atributos
        private int jurado1;
        private int jurado2;
        private int jurado3;
        private DominioSKD.Entidades.Modulo10.Inscripcion inscripcion;
        #endregion

        #region Constructores
        public ResultadoKata(int jurado1, int jurado2, int jurado3, DominioSKD.Entidades.Modulo10.Inscripcion inscripcion)
        {
            this.jurado1 = jurado1;
            this.jurado2 = jurado2;
            this.jurado3 = jurado3;
            this.inscripcion = inscripcion;
        }
        public ResultadoKata()
        {
            this.jurado1 = 0;
            this.jurado2 = 0;
            this.jurado3 = 0;
            this.inscripcion = new Modulo10.Inscripcion();
        }
        #endregion

        #region Propiedades
        public int Jurado1
        {
            get { return jurado1; }
            set { jurado1 = value; }
        }

        public int Jurado2
        {
            get { return jurado2; }
            set { jurado2 = value; }
        }

        public int Jurado3
        {
            get { return jurado3; }
            set { jurado3 = value; }
        }
        public DominioSKD.Entidades.Modulo10.Inscripcion Inscripcion
        {
            get { return inscripcion; }
            set { inscripcion = value; }
        }
        #endregion
    }
}
