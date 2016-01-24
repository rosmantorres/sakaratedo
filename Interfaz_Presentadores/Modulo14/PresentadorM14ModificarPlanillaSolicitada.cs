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
        /// <summary>
        /// Llenar el combobox con los eventos
        /// </summary>
        public void LlenarEventosCombo()
        {

            Comando<List<Entidad>> comboEvento = FabricaComandos.ObtenerComandoEventosSolicitud();
            ((ComandoEventosSolicitud)comboEvento).IDPersona = vista.IDUsuario;
            List<Entidad> listEventos = comboEvento.Ejecutar();
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (DominioSKD.Entidades.Modulo14.SolicitudP item in listEventos)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            vista.EventoCombo.DataSource = options;
            vista.EventoCombo.DataTextField = "value";
            vista.EventoCombo.DataValueField = "key";
            vista.EventoCombo.DataBind();
        }
        /// <summary>
        /// Llenar el combox con las competencias .
        /// </summary>
        public void LLenarCompetenciaCombo()
        {
        
            Comando<List<Entidad>> comboCompetencia = FabricaComandos.ObtenerComandoCompetenciasSolicitud();
            ((ComandoCompetenciasSolicitud)comboCompetencia).IDPersona = vista.IDUsuario;
            List<Entidad> listCompetencias = comboCompetencia.Ejecutar();
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (DominioSKD.Entidades.Modulo14.SolicitudP item in listCompetencias)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            vista.CompetenciaCombo.DataSource = options;
            vista.CompetenciaCombo.DataTextField = "value";
            vista.CompetenciaCombo.DataValueField = "key";
            vista.CompetenciaCombo.DataBind();
        }
        /// <summary>
        /// Cargar la pagina de modificar la planilla solicitada.
        /// </summary>
        public void PageLoadModificarPlanillaSolicitada()
        {
            try
            {
         
            Entidad laSolicitud;
            int idSolicitud = vista.IDSolicitud;
            vista.solicitudId = idSolicitud.ToString();
            vista.IDSolicitudVisible = false;
           
           
            Comando<Entidad> comandoObtenerSolicitudID = FabricaComandos.ObtenerComandoObtenerSolicitudID();
            ((ComandoObtenerSolicitudID)comandoObtenerSolicitudID).IDSolicitud = idSolicitud;
            laSolicitud = comandoObtenerSolicitudID.Ejecutar();
            vista.FechaRetiro = ((DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud).FechaRetiro;
            vista.FechaReincorporacion = ((DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud).FechaReincorporacion;
            vista.Motivo = ((DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud).Motivo;
            vista.IDInscripcion = ((DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud).IDInscripcion;
            IDIns = vista.IDInscripcion;

            Comando<List<Boolean>> comandoDatosRequeridosSolicitud = FabricaComandos.ObtenerComandoDatosRequeridosSolicitud();
           
            ((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).LaEntidad =
                FabricaEntidades.ObtenerPlanilla();
            ((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).LaEntidad.Id =
                ((DominioSKD.Entidades.Modulo14.SolicitudP)laSolicitud).ID;

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
        /// <summary>
        /// Modifica la planilla solicitada con los datos modificados.
        /// </summary>
        /// <returns>verdadero si se logro editar exitosamente la planilla solicitada</returns>>
        public bool EditarPlanillaSolicitada()
        {
           
            Entidad solicitud = FabricaEntidades.ObtenerSolicitudP();
            ((DominioSKD.Entidades.Modulo14.SolicitudP)solicitud).ID =
                Int32.Parse(vista.solicitudId);
          
            Comando<Entidad> comandoModificarSolicitudID = FabricaComandos.ObtenerComandoModificarSolicitudID();
         
              bool resultado = false;
         
                      if (vista.ComboEventoVisible == true)
                         {

                             Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP(Int32.Parse(vista.solicitudId), vista.FechaRetiro, vista.FechaReincorporacion,
                                       vista.Motivo, Int32.Parse(vista.EventoCombo.SelectedValue));
                             comandoModificarSolicitudID.LaEntidad = laSolicitud;
                             comandoModificarSolicitudID.Ejecutar();
                             resultado = true;
                           }
                       if (vista.ComboCompetenciaVisible == true)
                        {

                            Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP(Int32.Parse(vista.solicitudId), vista.FechaRetiro, vista.FechaReincorporacion,
                                          vista.Motivo, Int32.Parse(vista.CompetenciaCombo.SelectedValue));
                            comandoModificarSolicitudID.LaEntidad =laSolicitud;
                            comandoModificarSolicitudID.Ejecutar();
                            resultado = true;
                        }
                       if (vista.ComboEventoVisible == false && vista.ComboCompetenciaVisible == false)
                         {
                             Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP(Int32.Parse(vista.solicitudId), vista.FechaRetiro, vista.FechaReincorporacion,
                                            vista.Motivo, IDIns);
                            comandoModificarSolicitudID.LaEntidad =laSolicitud;
                            comandoModificarSolicitudID.Ejecutar();
                            resultado = true;
                           }

            return resultado;

        }
    }
}
