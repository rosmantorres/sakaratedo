using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo9;

namespace templateApp.GUI.Modulo9
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private List<Evento> eventoLista = new List<Evento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                ((SKD)Page.Master).IdModulo = "9";

                String success = Request.QueryString["eliminacionSuccess"];

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
            #region Carga de tabla de Eventos

            LogicaEvento logicaEvento = new LogicaEvento();
            if (!IsPostBack)
            {
                try
                {
                    eventoLista = logicaEvento.ListarEventos(33);
                    foreach (Evento evento in eventoLista)
                    {
                        this.tabla.Text += M9_RecursoInterfaz.AbrirTR;
                        this.tabla.Text += M9_RecursoInterfaz.AbrirTD + evento.Nombre.ToString() + M9_RecursoInterfaz.CerrarTD;
                        this.tabla.Text += M9_RecursoInterfaz.AbrirTD + evento.TipoEvento.Nombre.ToString() + M9_RecursoInterfaz.CerrarTD;
                        this.tabla.Text += M9_RecursoInterfaz.AbrirTD + String.Format("{0:dd/MM/yyyy}", evento.Horario.FechaInicio) + M9_RecursoInterfaz.CerrarTD;
                        this.tabla.Text += M9_RecursoInterfaz.AbrirTD + String.Format("{0:dd/MM/yyyy}", evento.Horario.FechaFin) + M9_RecursoInterfaz.CerrarTD;
                        this.tabla.Text += M9_RecursoInterfaz.AbrirTD + evento.Horario.HoraInicio.ToString()+":00"+ M9_RecursoInterfaz.CerrarTD;
                        this.tabla.Text += M9_RecursoInterfaz.AbrirTD + evento.Horario.HoraFin.ToString()+":00"+ M9_RecursoInterfaz.CerrarTD;
                        if (evento.Estado)
                        {
                            this.tabla.Text += M9_RecursoInterfaz.AbrirTD + "Activo" + M9_RecursoInterfaz.CerrarTD;
                        }
                        else {
                            this.tabla.Text += M9_RecursoInterfaz.AbrirTD + "Inactivo" + M9_RecursoInterfaz.CerrarTD;
                        }

                        this.tabla.Text += M9_RecursoInterfaz.AbrirTD;
                        this.tabla.Text += M9_RecursoInterfaz.BotonInfo + evento.Id_evento + M9_RecursoInterfaz.BotonCerrar;
                        this.tabla.Text += M9_RecursoInterfaz.BotonModificar + evento.Id_evento + M9_RecursoInterfaz.BotonCerrar;
                        this.tabla.Text += M9_RecursoInterfaz.CerrarTD;
                        this.tabla.Text += M9_RecursoInterfaz.CerrarTR;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion


            }

        }
}