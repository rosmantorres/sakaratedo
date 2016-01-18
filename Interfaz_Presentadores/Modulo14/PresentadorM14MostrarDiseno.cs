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

        public void MostrarInformacion(int idIns, int idPersona,int idSolici, int planilla)
        {
            FabricaComandos fabrica = new FabricaComandos();
            FabricaEntidades entidad = new FabricaEntidades();
            try
            {
                Planilla plani = (Planilla)entidad.ObtenerPlanilla();
                plani.ID = planilla;
                ComandoConsultarDiseño command = (ComandoConsultarDiseño)
                    fabrica.ObtenerComandoComandoConsultarDiseño();
                command.IdIns = idIns;
                command.IdPersona = idPersona;
                command.IdSolici = idSolici;
                command.Planilla = plani;
                Entidad diseño = command.Ejecutar();
                string contenido = ((Diseño)diseño).Contenido;
                vista.informacion.Text = contenido;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                //throw ex;
            }
        }
    }
}
