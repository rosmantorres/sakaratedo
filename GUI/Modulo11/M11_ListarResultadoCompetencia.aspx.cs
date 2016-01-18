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

            String success = Request.QueryString["success"];

            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado del Examen de Ascenso agregado exitosamente</div>";
                }

                if (success.Equals("2"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultados del Examen de Ascenso modificado exitosamente</div>";
                }

                if (success.Equals("3"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al agregar el Resultado del Examen de Ascenso</div>";
                }

                if (success.Equals("4"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al modificar los resultados del Examen de Ascenso</div>";
                }

                if (success.Equals("5"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultados de la Competencia Especialidad Kata modificado exitosamente</div>";
                }

                if (success.Equals("6"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al modificar los resultados de la Competencia Especialidad Kata</div>";
                }

                if (success.Equals("7"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultados de la Competencia Especialidad Kumite modificado exitosamente</div>";
                }

                if (success.Equals("8"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al modificar los resultados de la Competencia Especialidad Kumite</div>";
                }

                if (success.Equals("9"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultados de la Competencia Especialidad Kata y Kumite modificado exitosamente</div>";
                }

                if (success.Equals("10"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al modificar los resultados de la Competencia Especialidad Kata y Kumite</div>";
                }

                if (success.Equals("11"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado de la Competencia Kata agregado exitosamente</div>";
                }

                if (success.Equals("12"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al agregar el Resultado de la Competencia Kata</div>";
                }

                if (success.Equals("13"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado de la Competencia Kumite agregado exitosamente</div>";
                }

                if (success.Equals("14"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al agregar el Resultado de la Competencia Kumite</div>";
                }

                if (success.Equals("15"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado de las Competencias Kata y Kumite agregado exitosamente</div>";
                }

                if (success.Equals("16"))
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error al agregar el Resultado de las Competencias Kata y Kumite</div>";
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