using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DominioSKD.Entidades.Modulo15;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using DominioSKD.Fabrica;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando que ejecuta la accion de detallar un producto en especifico
    /// </summary>
    class ComandoDetallarProducto : Comando<Entidad>
    {
        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private  Entidad implemento;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo implemento
        /// </summary>
        public Entidad Implemento
        {
            get{ return this.implemento;}
            set{this.implemento = value;}
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del Comando
        /// </summary>
        public ComandoDetallarProducto()
        {

        }

        /// <summary>
        /// Constructor del comando con todos los datos requeridos para el detalleProducto
        /// </summary>
        /// <param name="evento">El Producto al que se le mostrara el detalle</param>
        public ComandoDetallarProducto(Entidad implemento)
        {
            this.implemento = implemento;
        }
        #endregion

        #region Metodo

        /// <summary>
        /// Metodo que ejecuta la accion del detalleProducto
        /// </summary>
        /// <returns>El producto en especifico</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                     System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el DAO de Implemento
                IdaoImplemento daoimplemento = FabricaDAOSqlServer.ObtenerDaoDetalleProducto();

                //Obtengo todos los items del producto
                Implemento pro = (Implemento)this.implemento;

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //retorno la entidad de donde sea llamada
                return daoimplemento.ConsultarXId(pro);
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
