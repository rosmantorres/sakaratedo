using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{

    public enum EstadoSolicitudInsciptcionDojo { Aceptada, Rechazada, Pendiente }
    public class SolicitudInsciptcionDojo
    {

        private int _id;
        private String _numero;
        private DateTime _creacion;
        private DateTime _actualizacion;

        public EstadoSolicitudInsciptcionDojo Estado;

        public SolicitudInsciptcionDojo(int id)
        {
            this._id = id;
        }

        public SolicitudInsciptcionDojo()
        {
            this._id = -1;
        }

        public String Numero
        {
            set
            {
                this._numero = value;
            }
            get
            {
                return this._numero;
            }
        }

        public DateTime FechaCreacion
        {
            set
            {
                this._creacion = value;
            }
            get
            {
                return this._creacion;
            }
        }

        public DateTime FechaActualizacion
        {
            set
            {
                this._actualizacion = value;
            }
            get
            {
                return this._actualizacion;
            }
        }



    }
}
