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
    /// Comando para consultar la lista de todas las facturas
    /// </summary>
    public class ComandoConsultarTodasFacturas : Comando<Entidad>
    {
         #region Atributos
        /// <summary>
        /// Atributos del ComandoConsultarTodasFacturas
        private PersonaM1 p;
        #endregion

         #region Propiedades
        /// <summary>
        /// Propiedad del Atributo p

        public PersonaM1 P
        {
            get {return this.p;}
            set {this.p = value;}
        }
        
        #endregion

         #region Constructores
        /// <summary>
        /// Constructor vacio del ComandoConsultarTodasFacturas
        /// </summary>
        public ComandoConsultarTodasFacturas()
        {

        }

        /// <summary>
        /// Constructor del ComandoConsultarTodasFacturas
        /// </summary>
        /// <param name="p">La persona que se encuentra logueada</param>
        public ComandoConsultarTodasFacturas(PersonaM1 p)
        {
            this.p = p;
        }

        #endregion

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="p">id de persona</param>
        /// <returns>lista de Facturas</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IdaoCompra daoCompras = laFabrica.ObtenerDaoFacturas();
                PersonaM1 p = (PersonaM1)this.LaEntidad;

                return daoCompras.ConsultarXId(p);
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
