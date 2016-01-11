using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DominioSKD.Entidades.Modulo6;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using DominioSKD.Fabrica;


namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando que ejecuta la accion de detallar de una mensualidad en especifico
    /// </summary>
    public class ComandoDetallarMatricula : Comando<Entidad>
    {
        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private  Entidad matricula;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo matricula
        /// </summary>
        public Entidad Matricula
        {
            get{ return this.matricula;}
            set{this.matricula = value;}
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del Comando
        /// </summary>
        public ComandoDetallarMatricula()
        {

        }

        /// <summary>
        /// Constructor del comando con todos los datos requeridos para el detalleMatricula
        /// </summary>
        /// <param name="matricula">La matricula a la que se le mostrara el detalle</param>
        public ComandoDetallarMatricula(Entidad matricula)
        {
            this.matricula = matricula;
        }
        #endregion

        #region Metodo

        /// <summary>
        /// Metodo que ejecuta la accion del detalleEvento
        /// </summary>
        /// <returns>La Matricula en especifico</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                     System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el DAO de Matricula
                IdaoMensualidad daomatricula = FabricaDAOSqlServer.ObtenerDaoDetalleMatricula();

                //Obtengo todos los items del evento
                Matricula mat = (Matricula)this.matricula;

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //retorno la entidad de donde sea llamada
                return daomatricula.DetallarMensualidad(mat);
            }
            // Robusteciendo
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

        }

        #endregion
    }
}
