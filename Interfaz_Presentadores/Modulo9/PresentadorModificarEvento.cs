using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaz_Contratos.Modulo9;
using System.Web;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD;
using DominioSKD.Fabrica;
using LogicaNegociosSKD.Fabrica;
using System.Web.UI;

namespace Interfaz_Presentadores.Modulo9
{
    public class PresentadorModificarEvento
    {
        private IContratoModificarEvento vista;
        private String modificarString;
        public PresentadorModificarEvento(IContratoModificarEvento laVista)
        {
            this.vista = laVista;
        }
        /// <summary>
        /// Metodo para consultar las variables del url
        /// </summary>
        public void ObtenerVariablesURL()
        {
            {
                modificarString = HttpContext.Current.Request.QueryString[M9_RecursoInterfazPresentador.strEventoMod];
                String errorMalicioso = HttpContext.Current.Request.QueryString[M9_RecursoInterfazPresentador.errorGet];

                if (modificarString != null && !(HttpContext.Current.Handler as Page).IsPostBack)
                    ObtenerEvento(int.Parse(modificarString));

                if (errorMalicioso != null)
                {
                    if (errorMalicioso.Equals(M9_RecursoInterfazPresentador.strErrorMalicioso))
                    {
                        vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                        vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                        vista.alerta = M9_RecursoInterfazPresentador.alertaHtml +
                            M9_RecursoInterfazPresentador.inputMalicioso +
                            M9_RecursoInterfazPresentador.alertaHtmlFinal;
                    }
                }
            }

        }
        public void LlenarCombos()
        {
            try
            {
                LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos comandoListarTipoEvento = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos)FabricaComandos.ObtenerComandoConsultarTipoEventos();

                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("0", M9_RecursoInterfazPresentador.selecccionarEvento);


                List<Entidad> listaTipoEvento = comandoListarTipoEvento.Ejecutar();
                foreach (Entidad row in listaTipoEvento)
                {
                    DominioSKD.Entidades.Modulo9.TipoEvento tipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)row;

                    options.Add(tipoEvento.Id.ToString(), tipoEvento.Nombre);

                }
                vista.iComboTipoEvento.DataSource = options;
                vista.iComboTipoEvento.DataTextField = M9_RecursoInterfazPresentador.valueCombo;
                vista.iComboTipoEvento.DataValueField = M9_RecursoInterfazPresentador.keyCombo;
                vista.iComboTipoEvento.DataBind();
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M9_RecursoInterfazPresentador.alertaHtml
                    + ex.Mensaje + M9_RecursoInterfazPresentador.alertaHtmlFinal;
            }

        }
        public void ObtenerEvento(int idEvento)
        {

            try
            {
                //FabricaEntidades fabricaEntidades = new FabricaEntidades();
                DominioSKD.Entidades.Modulo9.Evento entidad = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
                entidad.Id = idEvento;
                Comando<Entidad> comandoDetallarEvento = FabricaComandos.ObtenerComandoConsultarEvento(entidad);
                DominioSKD.Entidades.Modulo9.Evento evento = (DominioSKD.Entidades.Modulo9.Evento)comandoDetallarEvento.Ejecutar();
                vista.iNombreEvento = evento.Nombre;
      //          vista.iTipoEvento = evento.TipoEvento.Nombre;
                vista.iCostoEvento = evento.Costo.ToString();
                vista.iDescripcionEvento = evento.Descripcion;
                vista.iFechaInicio = evento.Horario.FechaInicio.ToShortDateString();
                vista.iFechaFin = evento.Horario.FechaFin.ToShortDateString();
                vista.iHoraInicio = evento.Horario.HoraInicioS;
                vista.iHoraFin = evento.Horario.HoraFinS;
                if (evento.Estado)
                {
                    vista.iStatusActivoBool = true;
                }
                else
                {
                    vista.iStatusInactivoBool = true;
                }
            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M9_RecursoInterfazPresentador.alertaHtml + ex.Mensaje
                    + M9_RecursoInterfazPresentador.alertaHtmlFinal;

            }
        }
        public void ModificarEvento()
        {
           
            string fechavista=vista.iFechaInicio;
            List<String> laListaDeInputs = new List<String>();
            laListaDeInputs.Add(vista.iNombreEvento);
            laListaDeInputs.Add(vista.iCostoEvento);
            laListaDeInputs.Add(vista.iDescripcionEvento);
            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
            {
                if (vista.iComboTipoEvento.SelectedIndex != 0)
                {
                    try
                    {
                        int size = vista.iComboTipoEvento.Items.Count;
                        int index = vista.iComboTipoEvento.SelectedIndex + 1;
                        Comando<bool> comandoModificarEvento;
                        FabricaEntidades laFabrica = new FabricaEntidades();
                        DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)FabricaEntidades.ObtenerEvento();
                        DominioSKD.Entidades.Modulo9.TipoEvento elTipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)FabricaEntidades.ObtenerTipoEvento();
                        DominioSKD.Entidades.Modulo9.Horario elHorario = (DominioSKD.Entidades.Modulo9.Horario)FabricaEntidades.ObtenerHorario();
                        elEvento.Nombre = vista.iNombreEvento;
                        elEvento.Costo = float.Parse(vista.iCostoEvento);
                        elTipoEvento.Nombre = vista.iComboTipoEvento.SelectedItem.Text;
                        elTipoEvento.Id = vista.iComboTipoEvento.SelectedIndex;
                        elEvento.TipoEvento = elTipoEvento;
                        elHorario.FechaInicio = Convert.ToDateTime(vista.iFechaInicio);
                        elHorario.FechaFin = Convert.ToDateTime(vista.iFechaFin);
                        elHorario.HoraInicioS = vista.iHoraInicio;
                        elHorario.HoraFinS = vista.iHoraFin;
                        elEvento.Horario = elHorario;
                        elEvento.Id = int.Parse(modificarString);
 
                        elEvento.Descripcion = vista.iDescripcionEvento;
                        if (vista.iStatusActivoBool == true)
                            elEvento.Estado = true;
                        else
                            elEvento.Estado = false;
                        comandoModificarEvento = FabricaComandos.ObtenerComandoModificarEvento(elEvento);
                        if (comandoModificarEvento.Ejecutar() == true)
                            HttpContext.Current.Response.Redirect(M9_RecursoInterfazPresentador.modificarExito);
                    }
                    catch (ExcepcionesSKD.ExceptionSKD ex)
                    {
                        vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                        vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                        vista.alerta = M9_RecursoInterfazPresentador.alertaHtml
                            + ex.Mensaje + M9_RecursoInterfazPresentador.alertaHtmlFinal;
                    }


                }
                else {
                    vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                    vista.alerta = M9_RecursoInterfazPresentador.alertaHtml
                        + M9_RecursoInterfazPresentador.comboVacio
                        + M9_RecursoInterfazPresentador.alertaHtmlFinal;
                }
            }
            else
            {
                vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                vista.alerta = M9_RecursoInterfazPresentador.alertaHtml
                    + M9_RecursoInterfazPresentador.camposVacios
                    + M9_RecursoInterfazPresentador.alertaHtmlFinal;
            }
        }
    }
}

