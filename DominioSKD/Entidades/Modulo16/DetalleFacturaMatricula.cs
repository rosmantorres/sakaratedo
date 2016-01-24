using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo6;

namespace DominioSKD.Entidades.Modulo16
{
   public class DetalleFacturaMatricula : Entidad
    {
        #region Atributos

        private Matricula matricula;
        private int cantidad_matricula;
        private float subtotal;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad del atributo producto
        /// </summary>
        public Matricula Matricula
        {
            get
            {
                return this.matricula;
            }
            set
            {
                this.matricula = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo cantidad_evento
        /// </summary>
        public int Cantidad_matricula
        {
            get
            {
                return this.cantidad_matricula;
            }
            set
            {
                this.cantidad_matricula = value;
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
        /// Constructor vacio de la clase DetalleFacturaMatricula
        /// </summary>
        public DetalleFacturaMatricula()
        {
            this.matricula = new Matricula();
            this.matricula.Identificador = "";
            this.matricula.Costo = 0;
            this.cantidad_matricula = 0;
            this.Subtotal = 0;
            
        }

        #endregion 

    }
}
