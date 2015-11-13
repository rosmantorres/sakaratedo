using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    /// <summary>
    /// Clase Compra con sus constructores y atributos
    /// </summary>
    public class Compra
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Carrito
        /// </summary>
        /*
        List<Inventario> listaInventario;
        List<Evento> listaEvento;
        List<Matricula> listaMatricula;*/
        DateTime fechaCompra;
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

        /// <summary>
        /// Propiedad del atributo fechaCompra
        /// </summary>
        public DateTime Fechacompra
        {
            get
            {
                return this.fechaCompra;
            }
            set
            {
                this.fechaCompra = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Compra
        /// </summary>
        public Compra()
        {

        }
        #endregion

    }
}
