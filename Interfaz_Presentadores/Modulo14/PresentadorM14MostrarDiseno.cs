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
using System.Web;
using DominioSKD;
namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14MostrarDiseno
    {
        private IContratoM14MostrarPlanilla vista;

        public PresentadorM14MostrarDiseno(IContratoM14MostrarPlanilla vista)
        {
            this.vista = vista;
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }
        /// <summary>
        /// Mostrar la informacion del diseno
        /// </summary>
        /// <returns>la entidad diseno</returns>>
        public Entidad MostrarInformacion(int idIns, int idPersona,int idSolici, int planilla)
        {
            try
            {
                DominioSKD.Entidades.Modulo14.Planilla plani =
                    (DominioSKD.Entidades.Modulo14.Planilla)FabricaEntidades.ObtenerPlanilla();
                plani.ID = planilla;
                Comando<Entidad> command = (ComandoConsultarDiseño)
                    FabricaComandos.ObtenerComandoComandoConsultarDiseño();
                ((ComandoConsultarDiseño)command).IdIns = idIns;
                ((ComandoConsultarDiseño)command).IdPersona = idPersona;
                ((ComandoConsultarDiseño)command).IdSolici = idSolici;
                ((ComandoConsultarDiseño)command).Planilla = plani;
                Entidad diseño = command.Ejecutar();
                string contenido = ((DominioSKD.Entidades.Modulo14.Diseño)diseño).Contenido;
                vista.informacion.Text = contenido;
                return diseño;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                //throw ex;
                return null;
            }
            return null;
        }
    }
}
