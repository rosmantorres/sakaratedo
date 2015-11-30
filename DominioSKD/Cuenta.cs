using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Cuenta
    {
        #region atributos
        private int id_usuario;
        private String nombre_usuario;
        private String contrasena;
        private List<Rol> roles;
        private String imagen;
        #endregion

        #region propiedades
        public int Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public String Nombre_usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }

        public String Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public String Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public List<Rol> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
        #endregion

        #region constructores
        public Cuenta()
        {
            id_usuario = 0;
            nombre_usuario = "";
            contrasena = "";
            imagen = "";
        }

         public Cuenta(int elIdUsuario, String elNombreUsuario, String laContrasena, String laImagen)
        {
            id_usuario = elIdUsuario;
            nombre_usuario = elNombreUsuario;
            contrasena = laContrasena;
            imagen = laImagen;
        }
         public Cuenta(String elNombreUsuario, String laContrasena, List<Rol> listaRoles, String laImagen)
         {
             nombre_usuario = elNombreUsuario;
             contrasena = laContrasena;
             roles = listaRoles;
             imagen = laImagen;
         }

        #endregion
    }
}
