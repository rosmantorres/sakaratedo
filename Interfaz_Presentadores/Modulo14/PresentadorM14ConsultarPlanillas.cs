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
namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14ConsultarPlanillas
    {
        private IContratoM14ConsultarPlanillas vista;
        List<Entidad> lista;

        public PresentadorM14ConsultarPlanillas(IContratoM14ConsultarPlanillas vista)
        {
            this.vista = vista;
        }

        public void LlenarInformacion(List<Entidad> lista)
        {
            try
            {
                this.lista = lista;
                foreach (DominioSKD.Entidades.Modulo14.Planilla plani in lista)
                {
                    vista.planillaCreadas += RecursosPresentadorModulo14.AbrirTR;
                    vista.planillaCreadas += RecursosPresentadorModulo14.AbrirTD + plani.ID.ToString() + RecursosPresentadorModulo14.CerrarTD;
                    vista.planillaCreadas += RecursosPresentadorModulo14.AbrirTD + plani.Nombre.ToString() + RecursosPresentadorModulo14.CerrarTD;
                    vista.planillaCreadas += RecursosPresentadorModulo14.AbrirTD + plani.TipoPlanilla.ToString() + RecursosPresentadorModulo14.CerrarTD;
                    vista.planillaCreadas += RecursosPresentadorModulo14.AbrirTD + plani.Status.ToString() + RecursosPresentadorModulo14.CerrarTD;
                    vista.planillaCreadas += RecursosPresentadorModulo14.AbrirTD;
                    foreach (string dat in plani.Dato)
                    {
                        vista.planillaCreadas += dat + RecursosPresentadorModulo14.linea;
                    }
                    vista.planillaCreadas += RecursosPresentadorModulo14.CerrarTD;
                    vista.planillaCreadas += RecursosPresentadorModulo14.AbrirTD;
                    vista.planillaCreadas += RecursosPresentadorModulo14.BotonModificar + plani.ID + RecursosPresentadorModulo14.Nombre + plani.Nombre + RecursosPresentadorModulo14.Tipo + plani.TipoPlanilla + RecursosPresentadorModulo14.BotonCerrar;
                    vista.planillaCreadas += RecursosPresentadorModulo14.BotonModificarRegistro + plani.ID + RecursosPresentadorModulo14.Nombre + plani.Nombre + RecursosPresentadorModulo14.Tipo + plani.TipoPlanilla + RecursosPresentadorModulo14.BotonCerrar;
                    if (plani.Status)
                        vista.planillaCreadas += RecursosPresentadorModulo14.BotonActivarPlanilla + plani.ID + RecursosPresentadorModulo14.BotonCerrar;
                    else
                        vista.planillaCreadas += RecursosPresentadorModulo14.BotonDesactivarPlanilla + plani.ID + RecursosPresentadorModulo14.BotonCerrar;
                    vista.planillaCreadas += RecursosPresentadorModulo14.CerrarTD;
                    vista.planillaCreadas += RecursosPresentadorModulo14.CerrarTR;

                }
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public List<Entidad> LlenarTabla()
        {

            try
            {
                Comando<List<Entidad>> command =FabricaComandos.ObtenerComandConsultarPlanillas();
                return command.Ejecutar();
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
                throw ex;
            }
        }
    }
}
