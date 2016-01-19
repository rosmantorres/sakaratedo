using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo10
{
    public class Asistencia : Entidad
    {
        #region Atributos
        private string asistio;
        private Inscripcion inscripcion;
        private DominioSKD.Entidades.Modulo9.Evento evento;
        private DominioSKD.Entidades.Modulo12.Competencia competencia;
        #endregion

        #region Constructores
        public Asistencia(String asistio, Inscripcion inscripcion, DominioSKD.Entidades.Modulo9.Evento evento)
        {
            this.asistio = asistio;
            this.inscripcion = inscripcion;
            this.evento = evento;
        }

        public Asistencia(String asistio, Inscripcion inscripcion, DominioSKD.Entidades.Modulo12.Competencia competencia)
        {
            this.asistio = asistio;
            this.inscripcion = inscripcion;
            this.competencia = competencia;
        }

        public Asistencia()
        {
            this.asistio = " ";
            this.inscripcion = new Inscripcion();
            this.competencia = new Modulo12.Competencia();
            this.evento = new Modulo9.Evento();
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

        public DominioSKD.Entidades.Modulo9.Evento Evento
        {
            get { return evento; }
            set { evento = value; }
        }

        public DominioSKD.Entidades.Modulo12.Competencia Competencia
        {
            get { return competencia; }
            set { competencia = value; }
        }
        #endregion
    }
}
