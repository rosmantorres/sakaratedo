﻿using System;
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


namespace Interfaz_Presentadores.Modulo9
{
    public class PresentadorAgregarEvento
    {
        private IContratoAgregarEvento vista;

        public PresentadorAgregarEvento(IContratoAgregarEvento laVista)
        {
            this.vista = laVista;
        }

        public void ObtenerVariablesURL()
        {
            String errorMalicioso = HttpContext.Current.Request.QueryString[M9_RecursoInterfazPresentador.errorGet];

            if (errorMalicioso != null)
            {
                if (errorMalicioso.Equals(M9_RecursoInterfazPresentador.strErrorMalicioso))
                {
                //    vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                  //  vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                   // vista.alerta = M9_RecursoInterfazPresentador.alertaHtml +
                     //   M9_RecursoInterfazPresentador.inputMalicioso +
                   //     M9_RecursoInterfazPresentador.alertaHtmlFinal;
                }
            }
        }
        public void LlenarCombos()
        {
            try
            {
                LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos comandoListarTipoEvento = (LogicaNegociosSKD.Comandos.Modulo9.ComandoConsultarListaTipoEventos)FabricaComandos.ObtenerComandoConsultarTipoEventos();

                Dictionary<string, string> options = new Dictionary<string, string>();
            //    options.Add("-1", M9_RecursoInterfazPresentador.selecccionarEvento);
                

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
     //           vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
       //         vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
         //       vista.alerta = M9_RecursoInterfazPresentador.alertaHtml
           //         + ex.Mensaje + M9_RecursoInterfazPresentador.alertaHtmlFinal; 
            }

        }
        public void AgregarEvento()
        {
            List<String> laListaDeInputs = new List<String>();
            laListaDeInputs.Add(vista.iNombreEvento);
            laListaDeInputs.Add(vista.iCostoEvento);
            laListaDeInputs.Add(vista.iFechaInicio);
            laListaDeInputs.Add(vista.iFechaFin);
            laListaDeInputs.Add(vista.iHoraInicio);
            laListaDeInputs.Add(vista.iHoraFin);
            laListaDeInputs.Add(vista.iStatusActivo);
            laListaDeInputs.Add(vista.iDescripcionEvento);



            if (Validaciones.ValidarCamposVacios(laListaDeInputs))
            {
                try
                {
                    int size = vista.iComboTipoEvento.Items.Count;
                    int index = vista.iComboTipoEvento.SelectedIndex + 1;
                    Comando<bool> comandoAgregarEvento;
                    FabricaEntidades laFabrica = new FabricaEntidades();
                    DominioSKD.Entidades.Modulo9.Evento elEvento = (DominioSKD.Entidades.Modulo9.Evento)laFabrica.ObtenerEvento();
                    DominioSKD.Entidades.Modulo9.TipoEvento elTipoEvento = (DominioSKD.Entidades.Modulo9.TipoEvento)laFabrica.ObtenerTipoEvento();
                    DominioSKD.Entidades.Modulo9.Horario elHorario = (DominioSKD.Entidades.Modulo9.Horario)laFabrica.ObtenerHorario();


                    elEvento.Nombre = vista.iNombreEvento;
                    elEvento.Costo = float.Parse(vista.iCostoEvento);
                    elTipoEvento.Nombre = vista.iComboTipoEvento.SelectedItem.Text;
                    elTipoEvento.Id = vista.iComboTipoEvento.SelectedIndex;
                    elEvento.TipoEvento = elTipoEvento;
                    elHorario.FechaInicio = Convert.ToDateTime(vista.iHoraInicio);
                    elHorario.FechaFin = Convert.ToDateTime(vista.iHoraFin);
                    String inicio = vista.iHoraInicio;
                    String fin = vista.iHoraFin;
                    string[] cadena = inicio.Split(':');
                    elHorario.HoraInicio = int.Parse(cadena[0]);
                    cadena = fin.Split(':');
                    elHorario.HoraFin = int.Parse(cadena[0]);
                    elEvento.Horario = elHorario;
                    Persona persona = new Persona();
                    //    String idPersona = Session[RecursosInterfazMaster.sessionUsuarioID].ToString();
                    persona.ID = int.Parse("36");
                    elEvento.Persona = persona;
                    elEvento.Descripcion = vista.iDescripcionEvento;
                    if (vista.iStatusActivoBool == true)
                        elEvento.Estado = true;
                    else
                        elEvento.Estado = false;
                    comandoAgregarEvento = FabricaComandos.ObtenerComandoAgregarEvento(elEvento);
                    if (comandoAgregarEvento.Ejecutar() == true)
                        HttpContext.Current.Response.Redirect(M9_RecursoInterfazPresentador.agregarExito);
                }
                catch (ExcepcionesSKD.ExceptionSKD ex)
                {
                    vista.alertaClase = M9_RecursoInterfazPresentador.alertaError;
                    vista.alertaRol = M9_RecursoInterfazPresentador.tipoAlerta;
                    vista.alerta = M9_RecursoInterfazPresentador.alertaHtml
                        + ex.Mensaje + M9_RecursoInterfazPresentador.alertaHtmlFinal;
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
