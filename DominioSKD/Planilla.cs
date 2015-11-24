using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    class Planilla
    {
        #region atributos

        private int id;
        private string nombre;
        private Boolean status;
        private List<TipoPlanilla> tipoPlanilla;
        private List<Diseño> diseño;
        private List<SolicitudPlanilla> solicitud;

        #endregion

        #region metodos

        public Planilla(string nombre, Boolean status, TipoPlanilla tipoPlanilla, Diseño diseño)
        {
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla.Add(tipoPlanilla);
            this.diseño.Add(diseño);
        }

        public Planilla(string nombre, Boolean status, List<TipoPlanilla> tipoPlanilla, List<Diseño> diseño)
        {
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla =tipoPlanilla;
            this.diseño = diseño;
        }

        public Planilla(int id,string nombre, Boolean status, TipoPlanilla tipoPlanilla, Diseño diseño)
        {
            this.id = id;
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla.Add(tipoPlanilla);
            this.diseño.Add(diseño);
        }

        public Planilla(int id,string nombre, Boolean status, List<TipoPlanilla> tipoPlanilla, List<Diseño> diseño)
        {
            this.id = id;
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla = tipoPlanilla;
            this.diseño = diseño;
        }

        public void AgregarSolicitud(SolicitudPlanilla solicitud)
        {
            this.solicitud.Add(solicitud);
        }
        #endregion

        #region gets y sets

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

        public List<TipoPlanilla> TipoPlanilla
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
