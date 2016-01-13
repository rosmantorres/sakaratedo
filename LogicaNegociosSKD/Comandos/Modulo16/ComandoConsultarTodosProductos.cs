using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando para consultar la lista de todos los productos
    /// </summary>
    public class ComandoConsultarTodosProductos : Comando<Entidad>
    {
        #region Atributos
        /// <summary>
        /// Atributos del ComandoConsultarTodosProductos
        private PersonaM1 p;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del Atributo p

        public PersonaM1 P
        {
            get { return this.p; }
            set { this.p = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del ComandoConsultarTodosProductos
        /// </summary>
        public ComandoConsultarTodosProductos()
        {

        }

        /// <summary>
        /// Constructor del ComandoConsultarTodosProductos
        /// </summary>
        /// <param name="p">La persona que se encuentra logueada</param>
        public ComandoConsultarTodosProductos(PersonaM1 p)
        {
            this.p = p;
        }
        #endregion

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="NONE">Este procedimiento no posee paso de parametros</param>
        /// <returns>lista de Productos</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IdaoImplemento daoImplementos = FabricaDAOSqlServer.ObtenerDaoProductos();
                PersonaM1 p = (PersonaM1)this.LaEntidad;
                return daoImplementos.ConsultarXId(p);
            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }
    }
}
