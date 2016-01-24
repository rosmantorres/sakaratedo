using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo15;

namespace DominioSKD.Entidades.Modulo16
{
   public class DetalleFacturaProducto : Entidad
    {

        #region Atributos

        private Implemento producto;
        private int cantidad_producto;
        private float subtotal;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad del atributo producto
        /// </summary>
        public Implemento Producto
        {
            get
            {
                return this.producto;
            }
            set
            {
                this.producto = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo cantidad_producto
        /// </summary>
        public int Cantidad_producto
        {
            get
            {
                return this.cantidad_producto;
            }
            set
            {
                this.cantidad_producto = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo Subtotal
        /// </summary>
        public float Subtotal
        {
            get
            {
                return this.subtotal;
            }
            set
            {
                this.subtotal = value;
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase DetalleFacturaProducto
        /// </summary>
        public DetalleFacturaProducto()
        {
            this.producto = new Implemento();
            this.producto.Nombre_Implemento = "";
            this.producto.Precio_Implemento = 0;
            this.cantidad_producto = 0;
            this.Subtotal = 0;
            
        }

        #endregion 
    }
}
