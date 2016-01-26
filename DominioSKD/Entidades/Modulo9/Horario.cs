using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo9
{
    public class Horario : Entidad
    {
        #region Atributos
 
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int horaInicio;
        private int horaFin;
        #endregion

        #region Constructores
        public Horario( DateTime fechaInicio, DateTime fechaFin, int horaInicio, int horaFin) : base()
        {

            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
        }

        public Horario() : base()
        {

        }

        #endregion

        #region Propiedades

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public int HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public int HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }

        #endregion  
    }

}

