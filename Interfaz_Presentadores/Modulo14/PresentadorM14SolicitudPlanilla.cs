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

        /// <summary>
        /// Llena el combobox de los eventos
        /// </summary>
        public void LlenarEventosCombo()
        {
            try{
            Comando<List<Entidad>> comboEvento = FabricaComandos.ObtenerComandoEventosSolicitud();
            ((ComandoEventosSolicitud)comboEvento).IDPersona = vista.IDUsuario;
            List<Entidad> listEventos = comboEvento.Ejecutar();
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (DominioSKD.Entidades.Modulo14.SolicitudP item in listEventos)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            vista.eventoCombo.DataSource = options;
            vista.eventoCombo.DataTextField = "value";
            vista.eventoCombo.DataValueField = "key";
            vista.eventoCombo.DataBind();
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
        /// Llena el combobox de las competencias
        /// </summary>
        public void LLenarCompetenciaCombo()
        {
            try{
            Comando<List<Entidad>> comboCompetencia = FabricaComandos.ObtenerComandoCompetenciasSolicitud();
            ((ComandoCompetenciasSolicitud)comboCompetencia).IDPersona = vista.IDUsuario;
            List<Entidad> listCompetencias = comboCompetencia.Ejecutar();
            Dictionary<string, string> options = new Dictionary<string, string>();

            foreach (DominioSKD.Entidades.Modulo14.SolicitudP item in listCompetencias)
            {
                options.Add(item.ID.ToString(), item.NombreEvento);
            }

            vista.competenciaCombo.DataSource = options;
            vista.competenciaCombo.DataTextField = "value";
            vista.competenciaCombo.DataValueField = "key";
            vista.competenciaCombo.DataBind();
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
        /// Agrega los datos de la solicitud
        /// </summary>
        /// <returns>verdadero si se logro agregar correctamente la solicitud </returns>
        public bool AgregarSolicitud()
        {
            Entidad planilla = FabricaEntidades.ObtenerPlanilla();
            ((DominioSKD.Entidades.Modulo14.Planilla)planilla).ID = Int32.Parse(vista.planillaId);
            bool resultado = false;

            try
            {
                Comando<bool> comandoRegistrarSolicitudPlanilla = FabricaComandos.ObtenerComandoRegistrarSolicitudPlanilla();
                Comando<Boolean> comandoRegistrarSolicitudPlanillaID = FabricaComandos.ObtenerComandoRegistrarSolicitudIDPersona();
                Comando<Boolean> comandoRegistrarSolicitudIDPersona = FabricaComandos.ObtenerComandoRegistrarSolicitudIDPersona();



                if (vista.ComboEventoVisible == true)
                {

                    Entidad laSolicitud =
                        FabricaEntidades.ObtenerSolicitudP(vista.fechaRetiroI,
                        vista.FechaReincorporacion,
                                             vista.Motivo,
                                             (DominioSKD.Entidades.Modulo14.Planilla
                                             )planilla, Int32.Parse(
                                             vista.eventoCombo.SelectedValue));

                    comandoRegistrarSolicitudPlanilla.LaEntidad = laSolicitud;
                    resultado = comandoRegistrarSolicitudPlanilla.Ejecutar();

                }
                if (vista.ComboCompetenciaVisible == true)
                {
                    Entidad laSolicitud = FabricaEntidades.ObtenerSolicitudP(
                       vista.fechaRetiroI, vista.FechaReincorporacion,
                                            vista.Motivo,
                                            (DominioSKD.Entidades.Modulo14.Planilla
                                            )planilla, Int32.Parse
                                            (vista.competenciaCombo.SelectedValue));
                    comandoRegistrarSolicitudPlanilla.LaEntidad = laSolicitud;
                    resultado = comandoRegistrarSolicitudPlanilla.Ejecutar();

                }
                if (vista.ComboEventoVisible == false && vista.ComboCompetenciaVisible == false)
                {

                    Entidad laSolicitud =
                        FabricaEntidades.ObtenerSolicitudP(
                        vista.fechaRetiroI, vista.FechaReincorporacion,
                                             vista.Motivo,
                                             (DominioSKD.Entidades.Modulo14.Planilla
                                             )planilla, vista.IDUsuario);
                    comandoRegistrarSolicitudIDPersona.LaEntidad = laSolicitud;
                    resultado = comandoRegistrarSolicitudIDPersona.Ejecutar();

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


            return resultado;
     
        }

        /// <summary>
        /// Inicio de la pagina, validaciones de los datos que se mostraran 
        /// </summary>
        public void PageLoadSolicitud()
        {
            try
            {
               
                int idPlanilla = vista.IDPlanilla;
                vista.planillaId = idPlanilla.ToString();
                vista.IDPlanillaVisible = false;

                Comando<List<Boolean>> comandoDatosRequeridosSolicitud = FabricaComandos.ObtenerComandoDatosRequeridosSolicitud();
               
                ((ComandoDatosRequeridosSolicitud)comandoDatosRequeridosSolicitud).LaEntidad = FabricaEntidades.ObtenerPlanilla();
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
                if ((datosRequeridos[0] == false) && (datosRequeridos[1] == false) && (datosRequeridos[2] == false) &&
                    (datosRequeridos[3] == false) && (datosRequeridos[4] == false))
                {
                    vista.alertLocalClase = RecursosPresentadorModulo14.Alert_Clase_Success;
                    vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                    vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.Alerta_Pregunta + RecursosPresentadorModulo14.Alerta_HtmlFinal; ;
                    vista.alerta = true;
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
