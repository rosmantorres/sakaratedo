using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Rol
    {
        #region atributos
        private int id_rol;
        private String nombre;
        private String descripcion;
        private String fecha_creacion;
        #endregion

        #region propiedades
        public int Id_rol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Fecha_creacion
        {
            get { return Fecha_creacion; }
            set { Fecha_creacion = value; }
        }
        #endregion

        #region constructores
         public Rol()
        {
            id_rol  = 0;
            nombre = "";
            descripcion = "";
            fecha_creacion = "";
        }

                public Rol(int  elId, String elNombre, String laDescripcion, String laFecha)
        {
            id_rol = elId;
            nombre = elNombre;
            descripcion = laDescripcion;
            fecha_creacion = laFecha;
        }
        #endregion
    }
}
