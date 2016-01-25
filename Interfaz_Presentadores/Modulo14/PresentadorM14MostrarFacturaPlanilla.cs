using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo14;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DominioSKD.Entidades.Modulo16;

namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14MostrarFacturaPlanilla
    {
        private IContartoM14MostrarFacturaPlanilla vita;

        public PresentadorM14MostrarFacturaPlanilla(IContartoM14MostrarFacturaPlanilla vista)
        {
            this.vita = vista;
        }

        public Compra DetalleFactura1(Entidad compra)
        {
            try
            {

                //Casteamos
                Comando<Entidad> DetalleFactura = FabricaComandos.CrearComandoDetallarFactura(compra);
                Compra laFactura = (Compra)DetalleFactura.Ejecutar();

                // Retornamos la Factura
                return laFactura;
            }

            #region Catches
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (OverflowException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }


            #endregion
        }
    }
}
