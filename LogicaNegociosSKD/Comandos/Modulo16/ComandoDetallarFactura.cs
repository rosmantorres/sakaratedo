using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.Fabrica;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo16;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando que ejecuta la accion de detallar una factura en especifico
    /// </summary>
    public class ComandoDetallarFactura : Comando<Entidad>
    {
        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private  Entidad compra;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo compra
        /// </summary>
        public Entidad Compra
        {
            get{ return this.compra;}
            set{this.compra = value;}
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del Comando
        /// </summary>
        public ComandoDetallarFactura()
        {

        }

        /// <summary>
        /// Constructor del comando con todos los datos requeridos para el detalleFactura
        /// </summary>
        /// <param name="compra">La factura a la que se le mostrara el detalle</param>
        public ComandoDetallarFactura(Entidad compra)
        {
            this.compra = compra;
        }
        #endregion

        #region Metodo Ejecutar

        /// <summary>
        /// Metodo que ejecuta la accion del detalleEvento
        /// </summary>
        /// <returns>El evento en especifico</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                     System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Instancio el DAO de compra
                IdaoCompra daocompra = FabricaDAOSqlServer.ObtenerDaoDetalleFactura();

                //Casteamos
                Compra comp = (Compra)this.compra;

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //retorno la entidad de donde sea llamada
                return daocompra.DetallarFactura(comp);
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
