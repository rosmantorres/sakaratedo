using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_AgregarAsistenciaEventos : System.Web.UI.Page
    {
        List<Horario> horariosEventos = new List<Horario>();
        List<Persona> atletasIE = new List<Persona>();
        List<Persona> atletasAE = new List<Persona>();
        protected void Page_Load(object sender, EventArgs e)
        {
            horariosEventos = LogicaAsistencia.ListarHorariosEventos();
            ((SKD)Page.Master).IdModulo = "10";
            if (!IsPostBack)
            {
                listaInscritos.Items.Add("atleta1");
                listaInscritos.Items.Add("atleta2");
                listaInscritos.Items.Add("atleta3");
                listaInscritos.Items.Add("atleta4");
                listaAsistentes.Items.Add("atleta5");
                listaAsistentes.Items.Add("atleta6");
                listaAsistentes.Items.Add("atleta7");
                listaAsistentes.Items.Add("atleta8");

            }
        }

        protected void bDerecho_Click(object sender, EventArgs e)
        {
            for (int i = listaInscritos.Items.Count - 1; i >= 0; i--)
            {
                if (listaInscritos.Items[i].Selected == true)
                {
                    listaAsistentes.Items.Add(listaInscritos.Items[i]);
                    ListItem li = listaInscritos.Items[i];
                    listaInscritos.Items.Remove(li);
                }
            }
        }

        protected void bIzquierdo_Click(object sender, EventArgs e)
        {
            for (int i = listaAsistentes.Items.Count - 1; i >= 0; i--)
            {
                if (listaAsistentes.Items[i].Selected == true)
                {
                    listaInscritos.Items.Add(listaAsistentes.Items[i]);
                    ListItem li = listaAsistentes.Items[i];
                    listaAsistentes.Items.Remove(li);
                }
            }
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=1");
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M10_ListarAsistenciaEventos.aspx");
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
            if (e.Day.IsSelected)
                e.Cell.BackColor = Color.Red;
            #region Horarios de Eventos
            foreach (Horario horario in horariosEventos)
            {
                if (e.Day.IsSelected)
                    e.Cell.BackColor = Color.Red;
                else if (e.Day.Date == horario.FechaInicio)
                {
                    e.Cell.BackColor = Color.Blue;
                    if (e.Day.Date >= DateTime.Now)
                    {
                        e.Day.IsSelectable = true;
                    }
                }
            }
            #endregion
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            List<Evento> listaE = LogicaAsistencia.EventosPorFecha(((Calendar)sender).SelectedDate.ToString(), ((Calendar)sender).SelectedDate.ToString());
            Dictionary<int, string> listaNombre = new Dictionary<int, string>();
            foreach (Evento evento in listaE)
            {
                listaNombre.Add(evento.Id_evento, evento.Nombre);
            }
            comboEventos.DataSource = listaNombre;
            comboEventos.DataValueField = "Key";
            comboEventos.DataTextField = "Value";
            comboEventos.DataBind();
        }

        protected void comboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            atletasIE = LogicaAsistencia.inscritosAlEvento(((DropDownList)sender).DataValueField);

            foreach (Persona persona in atletasIE)
            {
                listaInscritos.Items.Add(persona.Nombre);
            }
        }
    }
}