using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{

    public enum EstadoSolicitudInscripcionDojo { Aceptada, Rechazada, Pendiente }
    public class SolicitudInscripcionDojo
    {

        private int _id;
        private DateTime _creacion;
        private DateTime _actualizacion;
        public EstadoSolicitudInscripcionDojo Estado;
        private Persona _solicitante;
        private Dojo _dojo;

        public SolicitudInscripcionDojo(int id)
        {
            this._id = id;
        }

        public SolicitudInscripcionDojo()
        {
            this._id = -1;
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

        public Persona Solicitante
        {
            set
            {
                this._solicitante = value;
            }
            get
            {
                return this._solicitante;
            }
        }

        public Dojo Dojo
        {
            set
            {
                this._dojo = value;
            }
            get
            {
                return this._dojo;
            }
        }

    }
}
