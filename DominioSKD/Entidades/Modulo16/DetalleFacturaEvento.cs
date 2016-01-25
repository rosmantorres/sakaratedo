using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo16
{
   public class DetalleFacturaEvento : Entidad
    {
        #region Atributos

        private Evento evento;
        private int cantidad_evento;
        private float subtotal;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad del atributo producto
        /// </summary>
        public Evento Evento
        {
            get
            {
                return this.evento;
            }
            set
            {
                this.evento = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo cantidad_evento
        /// </summary>
        public int Cantidad_evento
        {
            get
            {
                return this.cantidad_evento;
            }
            set
            {
                this.cantidad_evento = value;
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
        /// Constructor vacio de la clase DetalleFacturaEvento
        /// </summary>
        public DetalleFacturaEvento()
        {
            this.evento = new Evento();
            this.evento.Nombre = "";
            this.evento.Costo = 0;
            this.cantidad_evento = 0;
            this.Subtotal = 0;
            
        }

        #endregion 
    }
}
