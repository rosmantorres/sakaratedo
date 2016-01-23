using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo16
{
    /// <summary>
    /// Clase pago con sus atributos y constructores
    /// </summary>
    public class Pago : Entidad
    {
        #region Atributos
        //Atributos de la clase de Pago
        float monto;
        String tipoPago;
        List<String>datoPago;
        #endregion

        #region Propiedades
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

        /// <summary>
        /// Propiedad del atributo tipoPago
        /// </summary>
        public String TipoPago
        {
            get
            {
                return this.tipoPago;
            }

            set
            {
                this.tipoPago = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo datoPago
        /// </summary>
        public List<String> DatoPago
        {
            get
            {
                return this.datoPago;
            }

            set
            {
                this.datoPago = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Pago():base()
        {

        }
        
        /// <summary>
        /// Constructor con el ID del pago
        /// </summary>
        /// <param name="id">El id del pago</param>
        public Pago (int id):base(id)
        {
            
        }

        /// <summary>
        /// Constructor con todos los atributos llenos de la clase compra
        /// </summary>
        /// <param name="monto">El monto de la transaccion</param>
        /// <param name="tipoPago">Tipo de pago con el que se ejecutara la transaccion</param>
        /// <param name="datoPago">Todos los datos que se requieran del pago</param>
        public Pago(float monto, String tipoPago, List<String> datoPago)
        {
            this.monto = monto;
            this.tipoPago = tipoPago;
            this.datoPago = datoPago;
        }
        #endregion
    }
}
