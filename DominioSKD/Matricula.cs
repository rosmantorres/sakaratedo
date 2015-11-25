using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Matricula
    {

        #region Atributos
        /// <summary>
        /// Atributos de la clase Carrito
        /// </summary>

        #region Atributos
        /// <summary>
        /// Atributos de la clase Carrito
        /// </summary>
        int mat_id;
        string mat_identificador;
        int mat_activa;
        int id_Dojo;
        int identificadorUsuario;
        DateTime fechaCreacion;
        DateTime ultimaFechapago;
        string modalidad;
        float costoPeriodo;
        bool status;




        #endregion

        #region Propiedades


        /// <summary>
        /// Propiedad del atributo listaInventario
        /// </summary>
        public string Mat_identificador
        {
            get
            {
                return this.mat_identificador;
            }
            set
            {
                this.mat_identificador = value;
            }
        }




        /// <summary>
        /// Propiedad del atributo listaInventario
        /// </summary>
        public int IdentificadorUsuario
        {
            get
            {
                return this.identificadorUsuario;
            }
            set
            {
                this.identificadorUsuario = value;
            }
        }







        /// <summary>
        /// Propiedad del atributo listaEvento
        /// </summary>
        public DateTime FechaTope
        {
            get
            {
                return this.ultimaFechapago;
            }
            set
            {
                this.ultimaFechapago = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo listaEvento
        /// </summary>
        public DateTime FechaCreacion
        {
            get
            {
                return this.fechaCreacion;
            }
            set
            {
                this.fechaCreacion = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo listaMatricula
        /// </summary>
        public DateTime UltimaFechapago
        {
            get
            {
                return this.ultimaFechapago;
            }
            set
            {
                this.ultimaFechapago = value;
            }
        }



        /// <summary>
        /// Propiedad del atributo listaMatricula
        /// </summary>
        public string Modalidad
        {
            get
            {
                return this.modalidad;
            }
            set
            {
                this.modalidad = value;
            }
        }



        /// <summary>
        /// Propiedad del atributo listaMatricula
        /// </summary>
        public float CostoPeriodo
        {
            get
            {
                return this.costoPeriodo;
            }
            set
            {
                this.costoPeriodo = value;
            }
        }


        /// <summary>
        /// Propiedad del atributo listaMatricula
        /// </summary>
        public bool Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }



        #endregion


        #endregion


    }
}
