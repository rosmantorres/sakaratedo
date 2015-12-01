using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_ListarAsistenciaEventos : System.Web.UI.Page
    {
        List<Evento> eventos = new List<Evento>();
        List<Competencia> competencias = new List<Competencia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";

            String success = Request.QueryString["eliminacionSuccess"];

            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Asistencia agregada exitosamente</div>";
                }

                if (success.Equals("2"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Asistencia modificada exitosamente</div>";
                }
            }

            #region Carga de tabla de Eventos y Competencias
            if (!IsPostBack)
            {
                try
                {
                    eventos = LogicaAsistencia.ListarEventosAsistidos();
                    foreach (Evento evento in eventos)
                    {
                        this.dataTable.Text += M10_RecursosInterfaz.AbrirTR;
                        this.dataTable.Text += M10_RecursosInterfaz.AbrirTD + evento.Id_evento.ToString() + M10_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M10_RecursosInterfaz.AbrirTD + evento.Nombre.ToString() + M10_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M10_RecursosInterfaz.AbrirTD + String.Format("{0:dd/MM/yyyy}", evento.Horario.FechaInicio) + M10_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M10_RecursosInterfaz.AbrirTD + evento.TipoEvento.Nombre.ToString() + M10_RecursosInterfaz.CerrarTD;

                        this.dataTable.Text += M10_RecursosInterfaz.AbrirTD;
                        this.dataTable.Text += M10_RecursosInterfaz.BotonInfo + evento.Id_evento + M10_RecursosInterfaz.BotonCerrar;
                        this.dataTable.Text += M10_RecursosInterfaz.BotonModificar + evento.Id_evento + M10_RecursosInterfaz.BotonCerrar;
                        this.dataTable.Text += M10_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M10_RecursosInterfaz.CerrarTR;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            #endregion
        }


    }
}