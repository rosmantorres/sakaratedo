using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /*
        List<Inventario> listaInventario;
        List<Evento> listaEvento;
        List<Matricula> listaMatricula;*/
        #endregion

        #region Propiedades
        /*
        /// <summary>
        /// Propiedad del atributo listaInventario
        /// </summary>
        public List<Inventario> Listainventario
        {
            get
            {
                return this.listaInventario;
            }
            set
            {
                this.listaInventario = value;
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
        
        */
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Carrito()
        {

        }
        
        /// <summary>
        /// Constructor de la case que llena todos los atributos de la clase Carrito
        /// </summary>
        /// <param name="listaInventario">La lista de todos los inventarios que se han agregado al Carrito</param>
        /// <param name="listaEvento">La lista de todos los eventos que se han agregado al Carrito</param>
        /// <param name="listaMatricula">La lista de todas las mastriculas que se han agregado al Carrito</param>
        /*
        public Carrito(List<Inventario> listaInventario, List<Evento> listaEvento, List<Matricula> listaMatricula)
        {
            this.listaInventario = listaInventario;
            this.listaEvento = listaEvento;
            this.listaMatricula = listaMatricula;
        }*/
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
