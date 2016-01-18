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
        struct valores
        {
            public int id;
            public string nombre;
            public string tipo;

            public valores(int s, string x, string y)
            {
                id = s;
                nombre = x;
                tipo = y;
            }
        }

        List<Horario> horariosEventos = new List<Horario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            horariosEventos = horarioEventos(LogicaAsistencia.ListarHorariosEventos(), LogicaAsistencia.ListarHorariosCompetencias());
            ((SKD)Page.Master).IdModulo = "10";
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
            List<Asistencia> listaA = new List<Asistencia>();
            if (Session["M10_tipo"].ToString().Equals(M10_RecursosInterfaz.Evento))
            {
                #region Agregar Evento

                List<Persona> atletasIE = LogicaAsistencia.inscritosAlEvento(Session["M10_IdEvento"].ToString());
                foreach (Persona persona in atletasIE)
                {
                    foreach (var listBoxItem in listaAsistentes.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "S";
                            asistencia.Evento.Id_evento = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaA.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in listaInscritos.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "N";
                            asistencia.Evento.Id_evento = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaA.Add(asistencia);
                        }
                    }
                }

                if (LogicaAsistencia.agregarAsistenciaEvento(listaA))
                {
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=1");
                }
                else
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=3");

                #endregion
            }
            else if (Session["M10_tipo"].ToString().Equals(M10_RecursosInterfaz.Competencia))
            {
                #region Agregar Competencia

                List<Persona> atletasIC = LogicaAsistencia.inscritosCompetencias(Session["M10_IdEvento"].ToString());
                foreach (Persona persona in atletasIC)
                {
                    foreach (var listBoxItem in listaAsistentes.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "S";
                            asistencia.Competencia.Id_competencia = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaA.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in listaInscritos.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "N";
                            asistencia.Competencia.Id_competencia = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaA.Add(asistencia);
                        }
                    }
                }

                if (LogicaAsistencia.agregarAsistenciaCompetencia(listaA))
                {
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=4");
                }
                else
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=5");
                #endregion
            }
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

            #region Horarios de Eventos y Competencias
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
            Session["M10_fecha"] = ((Calendar)sender).SelectedDate.ToString();
            List<Evento> listaE = LogicaAsistencia.EventosPorFecha(((Calendar)sender).SelectedDate.ToString(), ((Calendar)sender).SelectedDate.ToString());
            List<Competencia> listaC = LogicaAsistencia.competenciasPorFecha(((Calendar)sender).SelectedDate.ToString());

            Dictionary<int, string> listaEventos = new Dictionary<int, string>();
            foreach (Evento evento in listaE)
            {
                listaEventos.Add(evento.Id_evento, evento.Nombre);
            }
            foreach (Competencia competencia in listaC)
            {
                listaEventos.Add(competencia.Id_competencia, competencia.Nombre);
            }
            comboEventos.DataSource = listaEventos;
            comboEventos.DataTextField = M10_RecursosInterfaz.Value;
            comboEventos.DataValueField = M10_RecursosInterfaz.Key;
            comboEventos.DataBind();
        }

        protected void comboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioDeEvento();
            List<valores> listaEventos = diccionarioEventos();
            string tipo = "";

            foreach (valores valores in listaEventos)
            {
                if ((Convert.ToInt32(((DropDownList)sender).SelectedItem.Value).Equals(valores.id)) && (((DropDownList)sender).SelectedItem.Text.Equals(valores.nombre)))
                {
                    tipo = valores.tipo;
                }
            }

            Session["M10_tipo"] = tipo;

            if (tipo.Equals(M10_RecursosInterfaz.Evento))
            {
                List<Persona> atletasIE = LogicaAsistencia.inscritosAlEvento(((DropDownList)sender).SelectedItem.Value);
                Session["M10_IdEvento"] = ((DropDownList)sender).SelectedItem.Value;
                foreach (Persona persona in atletasIE)
                {
                    listaInscritos.Items.Add(persona.Nombre);
                }
            }
            else if (tipo.Equals(M10_RecursosInterfaz.Competencia))
            {
                List<Persona> atletasIC = LogicaAsistencia.inscritosCompetencias(((DropDownList)sender).SelectedItem.Value);
                Session["M10_IdEvento"] = ((DropDownList)sender).SelectedItem.Value;
                foreach (Persona persona in atletasIC)
                {
                    listaInscritos.Items.Add(persona.Nombre);
                }
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

            #region Carga de tabla de Atletas inasistentes a dicha competencia
            try
            {
                List<Inscripcion> inscripciones = LogicaAsistencia.listaAtletasInasistentesPlanillaCompetencia(((DropDownList)sender).SelectedItem.Value);
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
            dataTable.Text = " ";
        }

        private List<Horario> horarioEventos(List<Horario> eventos, List<Horario> competencias)
        {
            List<Horario> listaEventos = new List<Horario>();
            foreach (Horario horario in eventos)
            {
                listaEventos.Add(horario);
            }
            foreach (Horario horario in competencias)
            {
                if (!listaEventos.Contains(horario))
                {
                    listaEventos.Add(horario);
                }
            }
            return listaEventos;
        }

        private List<valores> diccionarioEventos()
        {
            List<Evento> listaE = LogicaAsistencia.EventosPorFecha(Session["M10_fecha"].ToString(), Session["M10_fecha"].ToString());
            List<Competencia> listaC = LogicaAsistencia.competenciasPorFecha(Session["M10_fecha"].ToString());

            List<valores> listaEventos = new List<valores>();
            foreach (Evento evento in listaE)
            {
                listaEventos.Add(new valores(evento.Id_evento, evento.Nombre, M10_RecursosInterfaz.Evento));
            }
            foreach (Competencia competencia in listaC)
            {
                listaEventos.Add(new valores(competencia.Id_competencia, competencia.Nombre, M10_RecursosInterfaz.Competencia));
            }
            return listaEventos;
        }
    }
}