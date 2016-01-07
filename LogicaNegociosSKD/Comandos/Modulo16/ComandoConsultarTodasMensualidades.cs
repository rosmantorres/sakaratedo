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
    /// Comando para consultar la lista de todas las mensualidades
    /// </summary>
   public class ComandoConsultarTodasMensualidades : Comando<Entidad>
    {
        #region Atributos
        /// <summary>
        /// Atributos del ComandoConsultarTodasMensualidades
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
        /// Constructor vacio del ComandoConsultarTodasMensualidades
        /// </summary>
        public ComandoConsultarTodasMensualidades()
        {

        }

        /// <summary>
        /// Constructor del ComandoConsultarTodasMensualidades
        /// </summary>
        /// <param name="p">La persona que se encuentra logueada</param>
        public ComandoConsultarTodasMensualidades(PersonaM1 p)
        {
            this.p = p;
        }

        #endregion

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="p">id de persona</param>
        /// <returns>lista de Mensualidades</returns>

       public override Entidad Ejecutar()
       {
           try
           {
               FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
               IdaoMensualidad daoMensualidades = laFabrica.ObtenerDaoMensualidades();
               PersonaM1 p = (PersonaM1)this.LaEntidad;

               return daoMensualidades.ConsultarXId(p);
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
