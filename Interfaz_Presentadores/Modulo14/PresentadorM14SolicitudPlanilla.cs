using DominioSKD;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Master;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo14;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14SolicitudPlanilla
    {
            //Variable que contiene la vista respectiva de este presentador a ser manipulada
        private IContratoM14SolicitudPlanilla vista;

        public PresentadorM14SolicitudPlanilla(IContratoM14SolicitudPlanilla vista)
        {
            this.vista = vista;
        }

        public void Alerta(string msj)
        {
            vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
            vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
            vista.alertLocal = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public void LlenarEventosCombo()
        {
            //LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            FabricaComandos fabricaCo = new FabricaComandos();
            Comando<List<Entidad>> comboEvento = fabricaCo.ObtenerComandoEventosSolicitud();
            ((ComandoEventosSolicitud)comboEvento).IDPersona = vista.IDUsuario;
            //List<SolicitudP> listEventos = (Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
            List<Entidad> listEventos = comboEvento.Ejecutar();
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (SolicitudP item in listEventos)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            vista.eventoCombo.DataSource = options;
            vista.eventoCombo.DataTextField = "value";
            vista.eventoCombo.DataValueField = "key";
            vista.eventoCombo.DataBind();
        }

        public void LLenarCompetenciaCombo()
        {
            //LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            //List<SolicitudP> listCompetencias = lP.CompetenciasSolicitud(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
            FabricaComandos fabricaCo = new FabricaComandos();
            Comando<List<Entidad>>comboCompetencia = fabricaCo.ObtenerComandoCompetenciasSolicitud();
            ((ComandoCompetenciasSolicitud)comboCompetencia).IDPersona = vista.IDUsuario;
            List<Entidad> listCompetencias = comboCompetencia.Ejecutar();
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (SolicitudP item in listCompetencias)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            vista.competenciaCombo.DataSource = options;
            vista.competenciaCombo.DataTextField = "value";
            vista.competenciaCombo.DataValueField = "key";
            vista.competenciaCombo.DataBind();
        }

        public bool AgregarSolicitud()
        {
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            FabricaComandos fabricaComandos = new FabricaComandos();
            Entidad planilla = fabricaEntidades.ObtenerPlanilla();
            ((Planilla)planilla).ID = Int32.Parse(vista.planillaId);
            //LogicaSolicitud lS = new LogicaSolicitud();
            Comando<bool> comandoRegistrarSolicitudPlanilla = fabricaComandos.ObtenerComandoRegistrarSolicitudPlanilla();
            Comando<Boolean> comandoRegistrarSolicitudPlanillaID = fabricaComandos.ObtenerComandoRegistrarSolicitudIDPersona();
            Comando<Boolean> comandoRegistrarSolicitudIDPersona = fabricaComandos.ObtenerComandoRegistrarSolicitudIDPersona();
            
            bool resultado = false;
            if (vista.fechaRetiroI != "")
            {
                if(vista.FechaReincorporacion != ""){
                    if (vista.Motivo !=""){
                        if (vista.ComboEventoVisible == true)
                        {
                            //SolicitudP laSolicitud = new SolicitudP(this.idFechaI.Value, this.idFechaF.Value,
                            //                             this.id_motivo.Value, planilla, Int32.Parse(this.comboEvento.SelectedValue));
                            Entidad laSolicitud = fabricaEntidades.ObtenerSolicitudP(vista.fechaRetiroI, vista.FechaReincorporacion,
                                                     vista.Motivo, (Planilla)planilla, Int32.Parse(vista.eventoCombo.SelectedValue));
                            // lS.RegistrarSolicitudPlanilla(laSolicitud);
                            comandoRegistrarSolicitudPlanilla.LaEntidad = laSolicitud;
                            resultado = comandoRegistrarSolicitudPlanilla.Ejecutar();

                        }
                        if (vista.ComboCompetenciaVisible == true)
                        {
                            // SolicitudP laSolicitud = new SolicitudP(this.idFechaI.Value, this.idFechaF.Value,
                            //                              this.id_motivo.Value, planilla, Int32.Parse(this.comboCompetencia.SelectedValue));
                            Entidad laSolicitud = fabricaEntidades.ObtenerSolicitudP(vista.fechaRetiroI, vista.FechaReincorporacion,
                                                     vista.Motivo, (Planilla)planilla, Int32.Parse(vista.competenciaCombo.SelectedValue));
                            comandoRegistrarSolicitudPlanilla.LaEntidad = laSolicitud;
                            resultado = comandoRegistrarSolicitudPlanilla.Ejecutar();
                            // lS.RegistrarSolicitudPlanilla(laSolicitud);
                        }
                        if (vista.ComboEventoVisible == false && vista.ComboCompetenciaVisible == false)
                        {
                            /* SolicitudP laSolicitud = new SolicitudP(this.idFechaI.Value, this.idFechaF.Value,
                                                          this.id_motivo.Value, planilla, Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));*/

                            Entidad laSolicitud = fabricaEntidades.ObtenerSolicitudP(vista.fechaRetiroI, vista.FechaReincorporacion,
                                                     vista.Motivo, (Planilla)planilla, vista.IDUsuario);
                            comandoRegistrarSolicitudIDPersona.LaEntidad = laSolicitud;
                            resultado = comandoRegistrarSolicitudIDPersona.Ejecutar();
                            // lS.RegistrarSolicitudIDPersona(laSolicitud);
                        }
                  
                    }else{
                        vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                        vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                        vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.AlertaMotivoVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal;
                        vista.alerta = true;
                        resultado = false;
                    }
                }else{
                    vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                    vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                    vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.AlertaFechaReincorporacionVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal; 
                    vista.alerta = true;
                    resultado = false;
                }
            }
            else
            {
                                  vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                   vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                   vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.AlertaFechaRetiroVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal; 
                   vista.alerta = true;
                   resultado = false;
            }

            return resultado;
     
        }

        public void PageLoadSolicitud()
        {
            try
            {
               // int idPlanilla = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
                int idPlanilla = vista.IDPlanilla;
                vista.planillaId = idPlanilla.ToString();
                vista.IDPlanillaVisible = false;

               //LogicaSolicitud lP = new LogicaSolicitud();
                FabricaEntidades fabricaEnt = new FabricaEntidades();
                FabricaComandos fabricaCo = new FabricaComandos();
                Comando<List<Boolean>> comandoDatosRequeridosSolicitud = fabricaCo.ObtenerComandoDatosRequeridosSolicitud();
               // List<bool> datosRequeridos = lP.DatosRequeridosSolicitud(idPlanilla);
                ((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).LaEntidad = fabricaEnt.ObtenerPlanilla();
                ((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).LaEntidad.Id = idPlanilla;
                List<Boolean> datosRequeridos = comandoDatosRequeridosSolicitud.Ejecutar();
                if (datosRequeridos[0] == true)
                {
                    vista.fechaRetiroVisible = true;
                }
                else
                {
                    vista.fechaRetiroVisible = false;
                }
                if (datosRequeridos[1] == true)
                {
                    vista.fechaReincorporacionVisible = true;
                }
                else
                {
                    vista.fechaReincorporacionVisible = false;
                }
                if (datosRequeridos[2] == true)
                {
                    vista.divComboEventoVisible = true;
                    vista.labelEventoVisible = true;
                    LlenarEventosCombo();

                }
                else
                {
                    vista.divComboEventoVisible = false;
                    vista.labelEventoVisible = false;

                }
                if (datosRequeridos[3] == true)
                {
                    vista.divComboCompetenciaVisible = true;
                    vista.labelCompetenciaVisible = true;
                    LLenarCompetenciaCombo();

                }
                else
                {
                    vista.divComboCompetenciaVisible = false;
                    vista.labelCompetenciaVisible = false;

                }
                if (datosRequeridos[4] == true)
                {
                    vista.divMotivoVisible = true;

                }
                else
                {
                    vista.divMotivoVisible = false;
                }
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
