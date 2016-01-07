using DominioSKD;
using LogicaNegociosSKD.Modulo9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_ModificarResultadoCompetencia : System.Web.UI.Page
    {
        Evento evento = new Evento();
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
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Resultado modificado exitosamente</div>";
                }
            }

            if (!IsPostBack)
            {
                String idEvento = Request.QueryString[M11_RecursosInterfaz.Modificar];
                String tipo = Request.QueryString[M11_RecursosInterfaz.Tipo];
                Session["M11_IdEvento"] = idEvento;
                Session["M11_tipo"] = tipo;

                if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
                {
                    LogicaEvento logicaEvento = new LogicaEvento();
                    evento = logicaEvento.ConsultarEvento(Session["M11_IdEvento"].ToString());
                    fechaEvento.Text = evento.Horario.FechaInicio.ToShortDateString();
                    nombreEvento.Text = evento.Nombre;
                    lEspecialidad.Visible = false;
                    comboEspecialidad.Visible = false;
                }
                else if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
                {
                    lEspecialidad.Visible = true;
                    comboEspecialidad.Visible = true;
                }

            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {

        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M11_ListarResultadoCompetencia.aspx");
        }

        protected void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}