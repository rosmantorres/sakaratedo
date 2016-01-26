using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo16;

namespace DominioSKD.Entidades.Modulo16
{
    /// <summary>
    /// Clase Compra con sus constructores y atributos
    /// </summary>
    public class Compra : Entidad
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Compra
        /// </summary>
        
        List<DetalleFacturaProducto> listaInventario;
        List<DetalleFacturaEvento> listaEvento;
        List<DetalleFacturaMatricula> listaMatricula;
        List<Pago> listaPago;
        int com_id;
        string com_estado;
        DateTime com_fecha_compra;
        float monto;

        #endregion

        #region Propiedades
        
        /// <summary>
        /// Propiedad del atributo listaInventario
        /// </summary>
        public List<DetalleFacturaProducto> Listainventario
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
        public List<DetalleFacturaEvento> Listaevento
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
        public List<DetalleFacturaMatricula> Listamatricula
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
        /// Propiedad del atributo listaPago
        /// </summary>
        public List<Pago> Listapago
        {
            get
            {
                return this.listaPago;
            }
            set
            {
                this.listaPago = value;
            }
        }


        /// <summary>
        /// Propiedad del atributo id de la factura
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
        /// Propiedad del atributo estado de la factura
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
        /// Propiedad del atributo monto
        /// </summary>
        public float Monto
        {
            get
            {
                return this.monto;
            }

            set
            {
                this.monto = value;
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
            this.com_estado = "";
            this.com_fecha_compra = DateTime.Now;
            this.monto = 0;
        }

        /// <summary>
        /// Constructor con todos los atributos de la clase compra
        /// </summary>
        public Compra(int com_id, string com_estado, DateTime com_fecha_compra, float monto)
        {
            this.com_id = com_id;
            this.com_estado = com_estado;
            this.com_fecha_compra = com_fecha_compra;
            this.monto = monto;
        }
        #endregion

    }
}
