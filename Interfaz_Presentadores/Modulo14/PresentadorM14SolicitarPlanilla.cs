using DominioSKD;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Fabrica;
using DominioSKD.Fabrica;
using LogicaNegociosSKD;

namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14SolicitarPlanilla
    {
                 //Variable que contiene la vista respectiva de este presentador a ser manipulada
        private IContratoM14SolicitarPlanilla vista;
        List<Entidad> lista;
        FabricaComandos fabricaComando = new FabricaComandos();
        public PresentadorM14SolicitarPlanilla(IContratoM14SolicitarPlanilla vista)
        {
            this.vista = vista;
        }

        public void Alerta(string msj)
        {
            vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
            vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
            vista.alertLocal = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public void LlenarLaInformacion(List<Entidad>lista)
        {
            this.lista = lista;
            try
            {
                foreach (Planilla plani in lista)
                {
                   vista.tablaSolicitarP += RecursosPresentadorModulo14.AbrirTR;
                   vista.tablaSolicitarP += RecursosPresentadorModulo14.AbrirTD + plani.Nombre.ToString() + RecursosPresentadorModulo14.CerrarTD;
                   vista.tablaSolicitarP += RecursosPresentadorModulo14.AbrirTD + plani.TipoPlanilla.ToString() + RecursosPresentadorModulo14.CerrarTD;
                   vista.tablaSolicitarP += RecursosPresentadorModulo14.AbrirTD;
                   vista.tablaSolicitarP += RecursosPresentadorModulo14.BotonSolicitarPlanilla + plani.ID + RecursosPresentadorModulo14.IdDis + plani.Diseño.ID + RecursosPresentadorModulo14.CerrarSolicitud;
                   vista.tablaSolicitarP += RecursosPresentadorModulo14.CerrarTD;
                   vista.tablaSolicitarP += RecursosPresentadorModulo14.CerrarTR;
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

        public List<Entidad> LlenarLaTabla()
        {
            try
            {
                Comando<List<Entidad>> planillas = fabricaComando.ObtenerComandoConsultarPlanillasASolicitar();
                return planillas.Ejecutar();
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

        public void PageLoadSolicitarPlanilla()
        {
            try
            {
                List<Entidad> listaPlanilla = LlenarLaTabla();
                LlenarLaInformacion(listaPlanilla);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
        }
    }
}
