using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo4
{
    class Dojo
    {
        #region atributos
        private int id_dojo;
        private String nombre;
        private String direccion;
        #endregion

        #region propiedades
        public int Id_dojo
        {
            get { return id_dojo; }
            set { id_dojo = value; }
        }

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
        #endregion
        public Dojo(int id, String nombre, String direccion): base()
        {
            this.id_dojo = id;
            this.nombre = nombre;
            this.direccion = direccion;
        }
    }
} 
