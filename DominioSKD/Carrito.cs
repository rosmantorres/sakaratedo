using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace DominioSKD
{
    /// <summary>
    /// Clase Carrito con sus constructores y atributos
    /// </summary>
    public class Carrito
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Carrito
        /// </summary>
        List<Implemento> listaImplemento;
        List<Evento> listaEvento;
        List<Matricula> listaMatricula;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo listaInventario
        /// </summary>
        public List<Implemento> ListaImplemento
        {
            get
            {
                return this.listaImplemento;
            }
            set
            {
                this.listaImplemento = value;
            }

        }

        /// <summary>
        /// Propiedad del atributo listaEvento
        /// </summary>
        public List<Evento> Listaevento
        {
            get
            {
                return this.listaEvento;
            }
            set
            {
                this.listaEvento = value;
            }
        }
        
        /// <summary>
        /// Propiedad del atributo listaMatricula
        /// </summary>
        public List<Matricula> Listamatricula
        {
            get
            {
                return this.listaMatricula;
            }
            set
            {
                this.listaMatricula = value;
            }
        }
        
        
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Carrito()
        {

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que elimina un item especifico del carrito del usuario
        /// </summary>
        /// <param name="tipoObjeto">Especifica si se trata de un inventario, matricula o evento</param>
        /// <param name="objetoBorrar">Elimina el objeto en especifico del carrito</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool eliminarItem(int tipoObjeto, int objetoBorrar)
        {
            return true;
        }

        /// <summary>
        /// Borra todos los items que existan en el carrito
        /// </summary>
        /// <returns>El exito o fallo del proceso</returns>
        public bool limpiar()
        {
            return true;
        }
        #endregion
    }
}
