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
        #endregion

        public List<Rol> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        #region constructores
         public Cuenta()
        {
            id_usuario = 0;
            nombre_usuario = "";
            contrasena = "";
        }

         public Cuenta(int elIdUsuario, String elNombreUsuario, String laContrasena)
        {
            id_usuario = elIdUsuario;
            nombre_usuario = elNombreUsuario;
            contrasena = laContrasena;
        }
         public Cuenta(String elNombreUsuario, String laContrasena,List<Rol> listaRoles)
         {
             nombre_usuario = elNombreUsuario;
             contrasena = laContrasena;
             roles = listaRoles;
         }

        #endregion
    }
}
