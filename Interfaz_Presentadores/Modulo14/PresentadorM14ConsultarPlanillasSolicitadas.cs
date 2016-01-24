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
using System.Web;

namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14ConsultarPlanillasSolicitadas
    {
        private IContratoM14ConsultarPlanillasSolicitadas vista;
        private List<Entidad> lista;

        public PresentadorM14ConsultarPlanillasSolicitadas(IContratoM14ConsultarPlanillasSolicitadas vista)
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
        /// Agrega los datos requeridos de la tabla de planillas solicitadas
        /// </summary>
        public void LlenarInformacion(List<Entidad> lista)
        {
            try
            {
                this.lista = lista;
                foreach (DominioSKD.Entidades.Modulo14.SolicitudPlanilla solici in lista)
                {
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTR;
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTD + solici.ID + RecursosPresentadorModulo14.CerrarTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTD + solici.Planilla.Nombre + RecursosPresentadorModulo14.CerrarTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTD + solici.Planilla.TipoPlanilla + RecursosPresentadorModulo14.CerrarTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTD + solici.FechaRetiro.ToShortDateString() + RecursosPresentadorModulo14.Espacio + solici.FechaReincorporacion.ToShortDateString() + RecursosPresentadorModulo14.CerrarTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTD + solici.FechaCreacion.ToShortDateString() + RecursosPresentadorModulo14.CerrarTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTD + solici.Evento + RecursosPresentadorModulo14.CerrarTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.AbrirTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.BotonInfoSolicitud + solici.ID + RecursosPresentadorModulo14.idIns + solici.IdInscripcion + RecursosPresentadorModulo14.Nombre + solici.Planilla.Nombre + RecursosPresentadorModulo14.IdPlanilla + solici.Planilla.ID + RecursosPresentadorModulo14.BotonCerrar;
                    vista.tablaplanillas += RecursosPresentadorModulo14.BotonModificarSolicitud + solici.ID + RecursosPresentadorModulo14.BotonCerrar;
                    vista.tablaplanillas += RecursosPresentadorModulo14.BotonEliminarSolicitud + solici.ID + RecursosPresentadorModulo14.BotonCerrar;
                    vista.tablaplanillas += RecursosPresentadorModulo14.CerrarTD;
                    vista.tablaplanillas += RecursosPresentadorModulo14.CerrarTR;
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
        /// <summary>
        /// Llena la tabla con los datos de las planillas solicitadas por usuario
        /// </summary>
        /// <returns>lista de entidad</returns>
        public List<Entidad> LlenarTabla(int idPersona)
        {

            try
            {
                Comando<List<Entidad>> command =
                    FabricaComandos.ObtenerComandoListarPlanillasSolicitadas();
                ((ComandoListarPlanillasSolicitadas)command).IDPersona = idPersona;
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
        /// <summary>
        /// Elimina toda una fila de la tabla
        /// </summary>
        public void EliminarFilaTable(HttpRequest request, int idSol)
        {
            try
            {
                Comando<Boolean> command = FabricaComandos.ObtenerComandoEliminarSolicitud();
                ((ComandoEliminarSolicitud)command).iDSolicitud = idSol;
                Boolean succecs = command.Ejecutar();
                if (succecs)
                {
                    vista.alertaClase = "alert alert-success alert-dismissible";
                    vista.alertaRol = "alert";
                    vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursosPresentadorModulo14.MSJEliminacionSolicitud + "</div>";
                }
                else
                {
                    vista.alertaClase = "alert alert-danger alert-dismissible";
                    vista.alertaRol = "alert";
                    vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursosPresentadorModulo14.MsjErrorEliminacionSolicitud + "</div>";
                }
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
