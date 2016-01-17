using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Cuenta: Entidad
    {
        #region atributos
        private String nombre_usuario;
        private String contrasena;
        private PersonaM1 personaUsuario;
        private List<Rol> roles;
        private String imagen;
        #endregion

        #region propiedades


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
        public PersonaM1 PersonaUsuario
        {
            get { return personaUsuario; }
            set { personaUsuario = value; }
        }
        #endregion
        #region constructores
        /// <summary>
        /// constructor numero 1 de cuenta el cual no recibe   parametros
        /// </summary>
        public Cuenta()
        {
            nombre_usuario = "";
            contrasena = "";
            imagen = "";
            personaUsuario = new PersonaM1();
        }
        /// <summary>
        /// constructor numero 3 de cuenta el cual recibe mas parametros
        /// </summary>
        /// <param name="elNombreUsuario"> el nombre del usuario</param>
        /// <param name="laContrasena">la contraseña del usuario</param>
        /// <param name="listaRoles">lsita de los roles a los cuales pertenece el usuario</param>
        /// <param name="laImagen">la imagen del usuario</param>
        public Cuenta(String elNombreUsuario, String laContrasena, List<Rol> listaRoles, String laImagen,PersonaM1 datosPersonales)
        {
            nombre_usuario = elNombreUsuario;
            contrasena = laContrasena;
            roles = listaRoles;
            imagen = laImagen;
            personaUsuario = datosPersonales;
        }

        #endregion
    }
}
