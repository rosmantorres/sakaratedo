using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;
using DominioSKD.Entidades.Modulo1;

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

        #region Metodo Ejecutar
        /// <summary>
        /// Metodo que ejecuta la accion de consultarTodasLasMensualidades
        /// </summary>
        /// <returns>el exito o fallo del proceso</returns>

       public override Entidad Ejecutar()
       {
           try
           {
               //Escribo en el logger la entrada a este metodo
               Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                   System.Reflection.MethodBase.GetCurrentMethod().Name);

               //Instancio el DAO de Mensualidad
               IdaoMensualidad daoMensualidades = FabricaDAOSqlServer.ObtenerDaoMensualidades();

               // Cateamos
               PersonaM1 p = (PersonaM1)this.LaEntidad;

               //Escribo en el logger la salida a este metodo
               Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

               //retorno la entidad de donde sea llamado
               return daoMensualidades.ConsultarXId(p);
           }
           #region catches

           catch (PersonaNoValidaException e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (LoggerException e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (ArgumentNullException e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (FormatException e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (OverflowException e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (ParametroInvalidoException e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (ExceptionSKDConexionBD e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (ExceptionSKD e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }
           catch (Exception e)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
               throw e;
           }

           #endregion
       }
        #endregion
    }
}
