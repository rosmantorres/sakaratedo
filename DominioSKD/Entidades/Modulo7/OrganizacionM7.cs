using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo7
{
    public class OrganizacionM7 : Entidad
    {
        private String nombre;
        private String direccion;
        private int telefono;
        private String email;
        private String estado;
        private String estilo;
        private Boolean status;


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Estilo
        {
            get { return estilo; }
            set { estilo = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }


        public OrganizacionM7() : base()
        {
            nombre = "";
            direccion = "";
            telefono = 0;
            email = "";
            estado = "";
            estilo = "";
            status = false;
        }

        
    
    }
}