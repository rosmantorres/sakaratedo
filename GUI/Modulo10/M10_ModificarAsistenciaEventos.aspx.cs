using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_ModificarAsistenciaEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";

            if (!IsPostBack)
            {
                listaAsistentes.Items.Add("atleta1");
                listaAsistentes.Items.Add("atleta2");
                listaAsistentes.Items.Add("atleta3");
                listaAsistentes.Items.Add("atleta4");
                listaNoAsistieron.Items.Add("atleta5");
                listaNoAsistieron.Items.Add("atleta6");
                listaNoAsistieron.Items.Add("atleta7");
                listaNoAsistieron.Items.Add("atleta8");
                calendar.VisibleDate = new DateTime(2014, 4, 1);
            }
        }

        protected void bIzquierdo_Click(object sender, EventArgs e)
        {
            for (int i = listaAsistentes.Items.Count - 1; i >= 0; i--)
            {
                if (listaAsistentes.Items[i].Selected == true)
                {
                    listaNoAsistieron.Items.Add(listaAsistentes.Items[i]);
                    ListItem li = listaAsistentes.Items[i];
                    listaAsistentes.Items.Remove(li);
                }
            }
        }

        protected void bDerecho_Click(object sender, EventArgs e)
        {
            for (int i = listaNoAsistieron.Items.Count - 1; i >= 0; i--)
            {
                if (listaNoAsistieron.Items[i].Selected == true)
                {
                    listaAsistentes.Items.Add(listaNoAsistieron.Items[i]);
                    ListItem li = listaNoAsistieron.Items[i];
                    listaNoAsistieron.Items.Remove(li);
                }
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M10_ListarAsistenciaEventos.aspx?eliminacionSuccess=2");
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M10_ListarAsistenciaEventos.aspx");
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime fecha = DateTime.Parse("2014-04-01");
            if (e.Day.IsSelected)
                e.Cell.BackColor = Color.Red;
            else if (e.Day.Date == fecha)
                e.Cell.BackColor = Color.Blue;
        }
    }
}