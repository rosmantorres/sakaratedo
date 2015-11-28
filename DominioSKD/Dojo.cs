using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    class Dojo
    {
        #region atributos

        private int id_dojo;
        private String rif_dojo;
        private String nombre_dojo;
        private int telefono_dojo;
        private String email_dojo;
        private String logo_dojo;
        private bool status_dojo;
        private Ubicacion ubicacion;
        #endregion

        #region propiedades

        public int Id_dojo
        {
            get { return id_dojo; }
            set { id_dojo = value; }
        }

        public bool Status_dojo
        {
            get { return status_dojo; }
            set { status_dojo = value; }
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

        public Ubicacion Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        #endregion

        #region constructores

        //constructor vacio
        public Dojo()
        {
            this.id_dojo = 0;
            this.rif_dojo = "";
            this.nombre_dojo = "";
            this.telefono_dojo = 0;
            this.email_dojo = "";
            this.logo_dojo = "";
            this.status_dojo = false;
            this.ubicacion = null;
        }

        //constructor con parametros 
        public Dojo(int Id, string Rif, string Nombre, int Telefono, string Email, string Logo, bool Status, Ubicacion ubicacion)
        {
            this.id_dojo = Id;
            this.rif_dojo = Rif;
            this.nombre_dojo = Nombre;
            this.telefono_dojo = Telefono;
            this.email_dojo = Email;
            this.logo_dojo = Logo;
            this.status_dojo = Status;
            this.ubicacion = ubicacion;
        }
        //constructor sin id 
        public Dojo(string Rif, string Nombre, int Telefono, string Email, string Logo, bool Status, Ubicacion ubicacion)
        {
            this.rif_dojo = Rif;
            this.nombre_dojo = Nombre;
            this.telefono_dojo = Telefono;
            this.email_dojo = Email;
            this.logo_dojo = Logo;
            this.status_dojo = Status;
            this.ubicacion = ubicacion;
        }

        #endregion

    }
}
