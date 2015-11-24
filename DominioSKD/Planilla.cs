using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Planilla
    {
        #region atributos

        private int id;
        private string nombre;
        private Boolean status;
        private string tipoPlanilla;
        private List<Diseño> diseño;
        private List<SolicitudPlanilla> solicitud;

        #endregion

        #region metodos

        public Planilla(string nombre, Boolean status, string tipoPlanilla)
        {
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla=tipoPlanilla;
        }

        public Planilla(int id, string nombre, Boolean status, string tipoPlanilla)
        {
            this.id = id;
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla=tipoPlanilla;
        }
        
        public void AgregarSolicitud(SolicitudPlanilla solicitud)
        {
            this.solicitud.Add(solicitud);
        }

        public void AgregarDiseño(Diseño diseño)
        {
            this.diseño.Add(diseño);
        }

        #endregion

        #region gets y sets

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Boolean Status
        {
            get { return status; }
            set { status = value; }
        }

        public string TipoPlanilla
        {
            get { return tipoPlanilla; }
            set { tipoPlanilla = value; }
        }

        public List<Diseño> Diseño
        {
            get { return diseño; }
            set { diseño = value; }
        }

        public List<SolicitudPlanilla> Solicitud
        {
            get { return solicitud; }
            set { solicitud = value; }
        }
        #endregion
    }
}
