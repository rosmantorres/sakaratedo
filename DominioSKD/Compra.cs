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
    public class Compra : Entidad
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Carrito
        /// </summary>
        /*
        List<Inventario> listaInventario;
        List<Evento> listaEvento;
        List<Matricula> listaMatricula;*/
        int com_id;
        string com_tipo_pago;
        DateTime com_fecha_compra;
        string com_estado;
        int persona_per_id;
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
        /// Propiedad del atributo Com_id
        /// </summary>
        public int Com_id
        {
            get
            {
                return this.com_id;
            }
            set
            {
                this.com_id = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo Com_tipo_pago
        /// </summary>
        public string Com_tipo_pago
        {
            get
            {
                return this.com_tipo_pago;
            }
            set
            {
                this.com_tipo_pago = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo Com_fecha_compra
        /// </summary>
        public DateTime Com_fecha_compra
        {
            get
            {
                return this.com_fecha_compra;
            }
            set
            {
                this.com_fecha_compra = value;
            }
        }


        /// <summary>
        /// Propiedad del atributo Com_estado
        /// </summary>
        public string Com_estado
        {
            get
            {
                return this.com_estado;
            }
            set
            {
                this.com_estado = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo Persona_per_id
        /// </summary>
        public int Persona_per_id
        {
            get
            {
                return this.persona_per_id;
            }
            set
            {
                this.persona_per_id = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Compra
        /// </summary>
        public Compra()
        {
            this.com_id = 0;
            this.com_tipo_pago = "";
            this.com_fecha_compra = DateTime.Now;
            this.com_estado ="";
            this.persona_per_id = 0;
        }

        /// <summary>
        /// Constructor con todos los atributos de la clase compra
        /// </summary>
        public Compra(int com_id, string com_tipo_pago, DateTime com_fecha_compra, string com_estado, int persona_per_id)
        {
            this.com_id = com_id;
            this.com_tipo_pago = com_tipo_pago;
            this.com_fecha_compra = com_fecha_compra;
            this.com_estado = com_estado;
            this.persona_per_id = persona_per_id;
        }
        #endregion

    }
}
