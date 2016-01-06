using DominioSKD;
using LogicaNegociosSKD.Modulo11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class ListarResultadoCompetencia : System.Web.UI.Page
    {
        List<Evento> eventos = new List<Evento>();
        List<Competencia> competencias = new List<Competencia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";

            String success = Request.QueryString["eliminacionSuccess"];

            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado agregado exitosamente</div>";
                }

                if (success.Equals("2"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado modificado exitosamente</div>";
                }

                if (success.Equals("3"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al agregar el Resultado Competencia</div>";
                }
            }
            #region Carga de tabla de Eventos y Competencias
            if (!IsPostBack)
            {
                try
                {
                    eventos = LogicaResultado.ListarResultadosEventosPasados();
                    foreach (Evento evento in eventos)
                    {
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTR;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + evento.Id_evento.ToString() + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + evento.Nombre.ToString() + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + String.Format("{0:dd/MM/yyyy}", evento.Horario.FechaInicio) + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + evento.TipoEvento.Nombre.ToString() + M11_RecursosInterfaz.CerrarTD;

                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD;
                        this.dataTable.Text += M11_RecursosInterfaz.BotonInfoEvento + evento.Id_evento + M11_RecursosInterfaz.BotonCerrar;
                        this.dataTable.Text += M11_RecursosInterfaz.BotonModificarEvento + evento.Id_evento + M11_RecursosInterfaz.BotonCerrar;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTR;
                    }

                    competencias = LogicaResultado.ListarCompetenciasAsistidas();
                    foreach (Competencia competencia in competencias)
                    {
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTR;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + competencia.Id_competencia.ToString() + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + competencia.Nombre.ToString() + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + String.Format("{0:dd/MM/yyyy}", competencia.FechaInicio) + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + M11_RecursosInterfaz.Competencia + M11_RecursosInterfaz.CerrarTD;

                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD;
                        this.dataTable.Text += M11_RecursosInterfaz.BotonInfoCompetencia + competencia.Id_competencia + M11_RecursosInterfaz.BotonCerrar;
                        this.dataTable.Text += M11_RecursosInterfaz.BotonModificarCompetencia + competencia.Id_competencia + M11_RecursosInterfaz.BotonCerrar;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTR;
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