using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DatosSKD.Modulo6;

namespace LogicaNegociosSKD.Modulo6
{
    class LogicaSolicitudInscripcion
    {
        #region Atributos
        private List<DominioSKD.SolicitudInscripcionDojo> _solicitudLista;
        #endregion

        public List<DominioSKD.SolicitudInscripcionDojo> SolicitudLista
        {
            set
            {
                this._solicitudLista = value;
            }
            get
            {
                return this._solicitudLista;
            }
        }

        public List<DominioSKD.SolicitudInscripcionDojo> ObtenerListaSolicitud()
        {
            try
            {
                return BDUsuarios
            }
        }

        public void NuevaSolicitud(Persona prospecto)
        {

        }

    }
}
