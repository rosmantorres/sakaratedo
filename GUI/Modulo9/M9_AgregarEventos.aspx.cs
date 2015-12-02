using DominioSKD;
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
             //   String idPersona = Session[RecursosInterfazMaster.sessionUsuarioID];
                if (!nombreEvento.Text.Equals(""))
                {
                    evento.Nombre = nombreEvento.Text;
                }
                else
                {
                    //error
                }
                if (!costoEvento.Text.Equals(""))
                {
                    String costo=costoEvento.Text;
                    evento.Costo = float.Parse(costo);
                }
                else
                {
                    //error
                }

               
                horario.FechaInicio = Convert.ToDateTime(input_fecha_ini.Value);
                horario.FechaFin = Convert.ToDateTime(input_fecha_fin.Value);
                evento.Horario = horario;
                if (inputEstadoActivo.Checked == true)
                    evento.Estado = inputEstadoActivo.Checked;
                if (inputEstadoInactivo.Checked == true)
                    evento.Estado = inputEstadoInactivo.Checked;
                evento.Descripcion = descripcionEvento.Text;
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
                        logicaEvento.CrearEventoConTipo(evento);
                    }
                }

                else
                {
                    TipoEvento tipoEvento = new TipoEvento();
                    tipoEvento.Nombre = comboTipoEvento.SelectedItem.Text;
                    evento.TipoEvento = tipoEvento;
                    logicaEvento.CrearEvento(evento);
                }


            }
            catch (Exception ex)
            {

            }

        }
    }
}