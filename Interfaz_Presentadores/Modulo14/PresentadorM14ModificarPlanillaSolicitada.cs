using DominioSKD;
using DominioSKD.Fabrica;
using Interfaz_Contratos.Modulo14;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo14;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14ModificarPlanillaSolicitada : System.Web.UI.Page
    {
          //Variable que contiene la vista respectiva de este presentador a ser manipulada
        private IContratoM14ModificarPlanillaSolicitada vista;
        static public int IDIns;
        public PresentadorM14ModificarPlanillaSolicitada(IContratoM14ModificarPlanillaSolicitada vista)
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

            vista.EventoCombo.DataSource = options;
            vista.EventoCombo.DataTextField = "value";
            vista.EventoCombo.DataValueField = "key";
            vista.EventoCombo.DataBind();
        }

        public void LLenarCompetenciaCombo()
        {
            //LogicaNegociosSKD.Modulo14.LogicaSolicitud lP = new LogicaNegociosSKD.Modulo14.LogicaSolicitud();
            //List<SolicitudP> listCompetencias = lP.CompetenciasSolicitud(Convert.ToInt32(Session[RecursosInterfazMaster.sessionUsuarioID]));
            FabricaComandos fabricaCo = new FabricaComandos();
            Comando<List<Entidad>> comboCompetencia = fabricaCo.ObtenerComandoCompetenciasSolicitud();
            ((ComandoCompetenciasSolicitud)comboCompetencia).IDPersona = vista.IDUsuario;
            List<Entidad> listCompetencias = comboCompetencia.Ejecutar();
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (SolicitudP item in listCompetencias)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            vista.CompetenciaCombo.DataSource = options;
            vista.CompetenciaCombo.DataTextField = "value";
            vista.CompetenciaCombo.DataValueField = "key";
            vista.CompetenciaCombo.DataBind();
        }
       
        public void PageLoadModificarPlanillaSolicitada()
        {

            //int idSolicitud = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idSol]);
            Entidad laSolicitud;
            int idSolicitud = vista.IDSolicitud;
            vista.solicitudId = idSolicitud.ToString();
            vista.IDSolicitudVisible = false;
            // SolicitudP laSolicitud = new SolicitudP();
            //LogicaSolicitud lP = new LogicaSolicitud();
            // laSolicitud = lP.ObtenerSolicitudID(Int32.Parse(this.id_solicitud.Value));
            FabricaComandos fabricaCo = new FabricaComandos();
            FabricaEntidades fabricaEnt = new FabricaEntidades();
            Comando<Entidad> comandoObtenerSolicitudID = fabricaCo.ObtenerComandoObtenerSolicitudID();
            ((ComandoObtenerSolicitudID)comandoObtenerSolicitudID).IDSolicitud = idSolicitud;
            laSolicitud = comandoObtenerSolicitudID.Ejecutar();
            vista.FechaRetiro = ((SolicitudP)laSolicitud).FechaRetiro;
            vista.FechaReincorporacion = ((SolicitudP)laSolicitud).FechaReincorporacion;
            vista.Motivo = ((SolicitudP)laSolicitud).Motivo;
            vista.IDInscripcion = ((SolicitudP)laSolicitud).IDInscripcion;
            IDIns = vista.IDInscripcion;

        /*    HttpCookie aCookie = new HttpCookie(RecursosPresentadorModulo14.CookieIdIns);
            aCookie.Values[RecursosPresentadorModulo14.CookieIdIns] = ((SolicitudP)laSolicitud).IDInscripcion.ToString();
            aCookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(aCookie);
            HttpContext.Current.Response.Redirect(RecursosPresentadorModulo14.PaginaModificarSolicitud);*/
            //   int idIns = laSolicitud.IDInscripcion;

            //  List<bool> datosRequeridos = lP.DatosRequeridosSolicitud(laSolicitud.ID);
            Comando<List<Boolean>> comandoDatosRequeridosSolicitud = fabricaCo.ObtenerComandoDatosRequeridosSolicitud();
           
            ((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).LaEntidad = fabricaEnt.ObtenerPlanilla();
            ((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).LaEntidad.Id = ((SolicitudP)laSolicitud).ID;
            //((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).IdPlanilla = idSolicitud;

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
        public bool EditarPlanillaSolicitada()
        {
           // LogicaSolicitud lS = new LogicaSolicitud();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            FabricaComandos fabricaComandos = new FabricaComandos();
            Entidad solicitud = fabricaEntidades.ObtenerSolicitudP();
            ((SolicitudP)solicitud).ID = Int32.Parse(vista.solicitudId);
           //Comando<Boolean> comandoTipoPlanilla = fabricaComandos.ObtenerComandoNuevoTipoPlanilla();
           Comando<Entidad> comandoModificarSolicitudID = fabricaComandos.ObtenerComandoModificarSolicitudID();
           //Comando<Entidad> comandoModificarPlanillaIDTipo = fabricaComandos.ObtenerComandoModificarPlanillaIDTipo();
          // int idIns = vista.IDIns; 

              bool resultado = false;
            if (vista.FechaRetiro != "")
            {
                if(vista.FechaReincorporacion != ""){
                    if (vista.Motivo !=""){
                      if (vista.ComboEventoVisible == true)
                         {
               // SolicitudP laSolicitud = new SolicitudP(Int32.Parse(this.id_solicitud.Value), this.idFechaI.Value, this.idFechaF.Value,
                 //                          this.id_motivo.Value, Int32.Parse(this.comboEvento.SelectedValue));
               // lS.ModificarSolicitudID(laSolicitud);

                             Entidad laSolicitud = fabricaEntidades.ObtenerSolicitudP(Int32.Parse(vista.solicitudId),vista.FechaRetiro, vista.FechaReincorporacion,
                                       vista.Motivo, Int32.Parse(vista.EventoCombo.SelectedValue));
                             comandoModificarSolicitudID.LaEntidad = laSolicitud;
                             comandoModificarSolicitudID.Ejecutar();
                             resultado = true;
                           }
                       if (vista.ComboCompetenciaVisible == true)
                        {
               /* SolicitudP laSolicitud = new SolicitudP(Int32.Parse(this.id_solicitud.Value), this.idFechaI.Value, this.idFechaF.Value,
                                             this.id_motivo.Value, Int32.Parse(this.comboCompetencia.SelectedValue));*/
               // lS.ModificarSolicitudID(laSolicitud);
           
                            Entidad laSolicitud = fabricaEntidades.ObtenerSolicitudP(Int32.Parse(vista.solicitudId), vista.FechaRetiro, vista.FechaReincorporacion,
                                          vista.Motivo, Int32.Parse(vista.CompetenciaCombo.SelectedValue));
                            comandoModificarSolicitudID.LaEntidad =laSolicitud;
                            comandoModificarSolicitudID.Ejecutar();
                            resultado = true;
                        }
                       if (vista.ComboEventoVisible == false && vista.ComboCompetenciaVisible == false)
                         {
             //   SolicitudP laSolicitud = new SolicitudP(Int32.Parse(this.id_solicitud.Value), this.idFechaI.Value, this.idFechaF.Value,
             //                                this.id_motivo.Value, idIns);
             //   lS.ModificarSolicitudID(laSolicitud);
            //    vista.IDInscripcion = Int32.Parse(Request.Cookies[RecursosPresentadorModulo14.CookieIdIns].ToString());
                
                            Entidad laSolicitud = fabricaEntidades.ObtenerSolicitudP(Int32.Parse(vista.solicitudId), vista.FechaRetiro, vista.FechaReincorporacion,
                                            vista.Motivo, IDIns);
                            comandoModificarSolicitudID.LaEntidad =laSolicitud;
                            comandoModificarSolicitudID.Ejecutar();
                            resultado = true;
                           }
                    }
                    else
                    {
                        vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                        vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                        vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.AlertaMotivoVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal;
                        vista.alerta = true;
                        resultado = false;
                    }
                }
                else
                {
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

      
    }
}
