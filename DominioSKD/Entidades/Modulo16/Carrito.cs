using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo15;
using DominioSKD.Entidades.Modulo6;
using DominioSKD;

namespace DominioSKD.Entidades.Modulo16
{
    /// <summary>
    /// Clase Carrito con sus constructores y atributos
    /// </summary>
    public class Carrito : Entidad
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Carrito
        /// </summary>
        private Dictionary<Entidad, int> listaImplemento;
        private Dictionary<Entidad, int> listaEvento;
        private Dictionary<Entidad, int> listaMatricula;
        private float MontoPagado;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo listaInventario
        /// </summary>
        public Dictionary<Entidad, int> ListaImplemento
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
        public Dictionary<Entidad, int> Listaevento
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
        public Dictionary<Entidad, int> Listamatricula
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

        /// <summary>
        /// Propiedad del atributo MontoPagado
        /// </summary>
        public float montoPagado
        {
            get
            {
                return this.MontoPagado;
            }

            set
            {
                this.MontoPagado = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Carrito()
        {

            listaImplemento = null;
            listaEvento = null;
            listaMatricula = null;
            MontoPagado = 0;

        }

        /// <summary>
        /// Constructor con todos los datos requeridos de la clase
        /// </summary>
        /// <param name="implementos">Lista con todos los implementos del carrito</param>
        /// <param name="eventos">Lista con todos los eventos del carrito</param>
        /// <param name="matriculas">Lista con todas las matriculas del carrito</param>
        /// <param name="monto"> Monto de ese carrito pagado</param>
        public Carrito(Dictionary<Entidad, int> implementos,
            Dictionary<Entidad, int> eventos, Dictionary<Entidad, int> matriculas, float monto)
        {
            this.listaImplemento = implementos;
            this.listaEvento = eventos;
            this.listaMatricula = matriculas;
            this.MontoPagado = monto;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Borra todos los items que existan en el carrito
        /// </summary>
        /// <returns>El exito o fallo del proceso</returns>
        public bool limpiar()
        {
            this.listaImplemento.Clear();
            this.listaEvento.Clear();
            this.listaMatricula.Clear();
            return true;
        }
        #endregion
    }
}
