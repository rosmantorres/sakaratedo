using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo7
{
    public class DojoM7 : Entidad
    {
        #region atributos

        private String rif_dojo;
        private String nombre_dojo;
        private int telefono_dojo;
        private String email_dojo;
        private String logo_dojo;
        private DateTime registro_dojo;
        private String status_dojo;
        private String orgNombre_dojo;
        private int organizacion_dojo;
        private UbicacionM7 ubicacion;
        #endregion

        #region propiedades

        public DateTime Registro_dojo
        {
            get { return registro_dojo; }

            set { registro_dojo = value; }
        }


        public String Status_dojo
        {
            get { return orgNombre_dojo; }
            set { orgNombre_dojo = value; }
        }

        public int Telefono_dojo
        {
            get { return telefono_dojo; }
            set { telefono_dojo = value; }
        }

        public String Rif_dojo
        {
            get { return rif_dojo; }
            set { rif_dojo = value; }
        }
        public String OrgNombre_dojo
        {
            get { return orgNombre_dojo; }
            set { orgNombre_dojo = value; }
        }
        public int Organizacion_dojo
        {
            get { return organizacion_dojo; }
            set { organizacion_dojo = value; }
        }
        public String Nombre_dojo
        {
            get { return nombre_dojo; }
            set { nombre_dojo = value; }
        }
        public String Email_dojo
        {
            get { return email_dojo; }
            set { email_dojo = value; }
        }

        public String Logo_dojo
        {
            get { return logo_dojo; }
            set { logo_dojo = value; }
        }

        public UbicacionM7 Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        #endregion

        #region constructores

        //constructor vacio
        public DojoM7()
        {
            this.rif_dojo = "";
            this.nombre_dojo = "";
            this.telefono_dojo = 0;
            this.email_dojo = "";
            this.logo_dojo = "";
            this.orgNombre_dojo = "";
            this.organizacion_dojo = 0;
            this.ubicacion = null;
        }

        
        #endregion

    }
}
