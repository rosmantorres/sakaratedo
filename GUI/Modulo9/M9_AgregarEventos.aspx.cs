﻿using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo9
{
    public partial class M9_AgregarEventos : System.Web.UI.Page
    {
        private List<TipoEvento> listEvento = new List<TipoEvento>();
        private LogicaNegociosSKD.Modulo9.LogicaEvento logicaEvento = new LogicaNegociosSKD.Modulo9.LogicaEvento();
        private Evento evento = new Evento();

        protected void Page_Load(object sender, EventArgs e)
        {
            {
                ((SKD)Page.Master).IdModulo = "9";

                String success = Request.QueryString["eliminacionSuccess"];
                otroEvento.Visible = false;

                if (success != null)
                {
                    if (success.Equals("1"))
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Evento agregado exitosamente</div>";
                    }

                    if (success.Equals("2"))
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Evento eliminado exitosamente</div>";
                    }

                    if (success.Equals("3"))
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Evento modificado exitosamente</div>";
                    }

                }
            }
            #region LLENAR COMBO TIPO DE EVENTOS
            if (!IsPostBack)
            {
                try
                {
                    Dictionary<string, string> options = new Dictionary<string, string>();
                    options.Add("-2", "Seleccione Tipo De Evento");
                    listEvento = logicaEvento.ConsultarTiposEventos();

                    foreach (TipoEvento o in listEvento)
                    {
                        options.Add(o.Id.ToString(), o.Nombre);
                    }
                    options.Add("-1", "Otro");
                    comboTipoEvento.DataSource = options;
                    comboTipoEvento.DataTextField = "value";
                    comboTipoEvento.DataValueField = "key";
                    comboTipoEvento.DataBind();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion

        }
        //Muestra o esconde el textbox de otro una vez seleccionado en el combobox
        protected void comboTipoEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboTipoEvento.SelectedIndex + 1;
            int size = comboTipoEvento.Items.Count;
            if (index.Equals(size))
            {
                otroEvento.Visible = true;
            }
            else
            {
                otroEvento.Visible = false;
            }
        }
        protected void btn_agregarEventoClick(object sender, EventArgs e)
        {
            int size = comboTipoEvento.Items.Count;
            int index = comboTipoEvento.SelectedIndex + 1;
            try
            {
                Horario horario = new Horario();
                Persona persona = new Persona();
                String idPersona = Session[RecursosInterfazMaster.sessionUsuarioID].ToString();
                persona.ID = int.Parse(idPersona);
                evento.Persona = persona;
                if (!nombreEvento.Text.Equals(""))
                {
                    evento.Nombre = nombreEvento.Text;
                }
                else
                {
                    //error
                }
                if (!descripcionEvento.Text.Equals(""))
                {
                    evento.Descripcion = descripcionEvento.Text;
                }
                else
                {
                    //error
                }




                if (!costoEvento.Text.Equals(""))
                {
                    String costo = costoEvento.Text;
                    //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError","alert('" +"es:"+costoEvento.Text + "');", true);
                    evento.Costo = float.Parse(costo);
                }
                else
                {
                    //error
                }
                String inicio = horaInicio.Text.ToString();
                String fin = horaFin.Text.ToString();
                string[] cadena = inicio.Split(':');
                horario.HoraInicio = int.Parse(cadena[0]);
                cadena = fin.Split(':');
                horario.HoraFin = int.Parse(cadena[0]);
                horario.FechaInicio = Convert.ToDateTime(fechaInicio.Value);
                horario.FechaFin = Convert.ToDateTime(fechaFin.Value);
                evento.Horario = horario;
                if (inputEstadoActivo.Checked == true)
                    evento.Estado = true;
                else
                    evento.Estado = false;

                if (index.Equals(0))
                {
                    //error seleccione un tipo de evento
                }
                else if (index.Equals(size))
                {
                    if (!otroEvento.Text.Equals(""))
                    {
                        TipoEvento tipoEvento = new TipoEvento();
                        tipoEvento.Nombre = otroEvento.Text;
                        evento.TipoEvento = tipoEvento;
                        bool resultado = logicaEvento.CrearEventoConTipo(evento);
                        if (resultado)
                        {
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Evento agregado exitosamente</div>";

                        }
                        else
                        {
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Campos Invalidos</div>";

                        }
                    }
                }

                else
                {
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Id = comboTipoEvento.SelectedIndex;
                    evento.TipoEvento = tipoEvento;
                    bool resultado = logicaEvento.CrearEvento(evento);
                    if (resultado)
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Evento agregado exitosamente</div>";

                    }
                    else
                    {
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Campos Invalidos</div>";

                    }
                }


            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error de Conxeion con BD</div>";

            }
            catch (ExcepcionesSKD.Modulo12.FormatoIncorrectoException ex)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Formato de Atributos Incorrecto</div>";

            }
            catch (ExcepcionesSKD.ExceptionSKD ex)
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Message + "</div>";

            }
            catch (NullReferenceException ex)
            {

                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>"+ex.Message+"</div>";

            }
            catch (Exception ex)
            {

                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + ex.Message + "</div>";

            }
        }
    }
}