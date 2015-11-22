using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{

    /// <summary>
    /// Clase que representa una cuenta de usuario
    /// </summary>
    public class CuentaUsuario
    {

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        private String _nombreUsuario;

        /// <summary>
        /// Url de imagen
        /// </summary>
        private String _imagen;

        /// <summary>
        /// Datos de la persona
        /// </summary>
        private Persona _persona;

        /*
         * TODO: Módulo 1, Privilegio
        private Roll....
        */

        #region Constructor
        public CuentaUsuario(Persona persona)
        {
            this._persona = persona;
        }
        #endregion

        #region Métodos
        public String NombreUsuario
        {
            set
            {
                this._nombreUsuario = value;
            }
            get
            {
                return this._nombreUsuario;
            }
        }

        public String Imagen
        {
            set
            {
                this._imagen = value;
            }
            get
            {
                return this._imagen;
            }
        }

        public Persona Persona
        {
            get { return this._persona; }
        }
        #endregion
    }
}
