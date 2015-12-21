using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                    DateTime date1 = e.Day.Date.Date;
                    DateTime date2 = DateTime.Now.Date;
                    if (date1 >= date2)
                    {
                        e.Day.IsSelectable = true;
                    }
                }
            }
            #endregion
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            cambioDeEvento();
            comboEventos.SelectedItem.Value = "0";
            List<Evento> listaE = LogicaAsistencia.EventosPorFecha(((Calendar)sender).SelectedDate.ToString(), ((Calendar)sender).SelectedDate.ToString());
            Dictionary<int, string> listaEventos = new Dictionary<int, string>();
            foreach (Evento evento in listaE)
            {
                listaEventos.Add(evento.Id_evento, evento.Nombre);
            }
            comboEventos.DataSource = listaEventos;
            comboEventos.DataTextField = "Value";
            comboEventos.DataValueField = "Key";
            comboEventos.DataBind();
        }

        protected void comboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioDeEvento();

            atletasIE = LogicaAsistencia.inscritosAlEvento(((DropDownList)sender).SelectedItem.Value);

            foreach (Persona persona in atletasIE)
            {
                listaInscritos.Items.Add(persona.Nombre);
            }

            #region Carga de tabla de Atletas inasistentes a dicho evento
            try
            {
                List<Inscripcion> inscripciones = LogicaAsistencia.listaAtletasInasistentesPlanilla(((DropDownList)sender).SelectedItem.Value);
                foreach (Inscripcion inscripcion in inscripciones)
                {
                    this.dataTable.Text += M10_RecursosInterfaz.AbrirTR;
                    this.dataTable.Text += M10_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M10_RecursosInterfaz.CerrarTD;
                    this.dataTable.Text += M10_RecursosInterfaz.AbrirTD + inscripcion.Solicitud.Planilla.Nombre + M10_RecursosInterfaz.CerrarTD;
                    this.dataTable.Text += M10_RecursosInterfaz.CerrarTR;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        private void cambioDeEvento()
        {
            listaInscritos.Items.Clear();
            listaAsistentes.Items.Clear();
        }
    }
}