using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo11;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
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
    public partial class M11_AgregarResultadoCompetencia : System.Web.UI.Page
    {
        List<Horario> horariosEventos = new List<Horario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            horariosEventos = horarioEventos(LogicaResultado.ListarHorariosEventosAscensos(), LogicaAsistencia.ListarHorariosCompetencias());
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
            comboEventos.Items.Clear();
            comboEspecialidad.Items.Clear();
            comboCategoria.Items.Clear();
            Session["M11_fecha"] = ((Calendar)sender).SelectedDate.ToString();
            List<Evento> listaE = LogicaResultado.EventosPorFechaAscenso(((Calendar)sender).SelectedDate.ToString(), ((Calendar)sender).SelectedDate.ToString());
            List<Competencia> listaC = LogicaAsistencia.competenciasPorFecha(((Calendar)sender).SelectedDate.ToString());
            llenarComboEventoCompetencia(listaE, listaC);
        }

        protected void comboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Text = " ";
            comboEspecialidad.Items.Clear();
            comboCategoria.Items.Clear();
            //dataTable2.Text = " ";
            //dataTable3.Text = " ";
            List<valores> listaEventos = diccionarioEventos();
            string tipo = "";

            foreach (valores valores in listaEventos)
            {
                if ((Convert.ToInt32(((DropDownList)sender).SelectedItem.Value).Equals(valores.id)) && (((DropDownList)sender).SelectedItem.Text.Equals(valores.nombre)))
                {
                    tipo = valores.tipo;
                }
            }
            Session["M11_tipo"] = tipo;
            Session["M11_IdEvento"] = ((DropDownList)sender).SelectedItem.Value;
            if (tipo.Equals(M11_RecursosInterfaz.Evento))
            {
                lEspecialidad.Visible = false;
                comboEspecialidad.Visible = false;
                llenarComboCategoria(LogicaResultado.listaCategoriasEvento(Session["M11_IdEvento"].ToString()));
            }
            else if (tipo.Equals(M11_RecursosInterfaz.Competencia))
            {
                lEspecialidad.Visible = true;
                comboEspecialidad.Visible = true;
                llenarComboEspecialidad(LogicaResultado.listaEspecialidadesCompetencia(Session["M11_IdEvento"].ToString()));
            }
        }

        protected void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Text = " ";
            comboCategoria.Items.Clear();
            //dataTable2.Text = " ";
            //dataTable3.Text = " ";
            Session["M11_especialidad"] = ((DropDownList)sender).SelectedItem.Value;
            Competencia competencia = new Competencia();
            competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
            competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
            llenarComboCategoria(LogicaResultado.listaCategoriasCompetencia(competencia));
        }

        protected void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Text = " ";
            //dataTable2.Text = " ";
            //dataTable3.Text = " ";
            Session["M11_categoria"] = ((DropDownList)sender).SelectedItem.Value;

            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
            {
                #region Carga de tabla de Atletas que compiten en un Evento Ascenso
                Evento evento = new Evento();
                evento.Id_evento = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                Categoria categoria = new Categoria();
                categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                evento.Categoria = categoria;

                try
                {
                    List<Inscripcion> inscripciones = LogicaResultado.listaInscritosExamenAscenso(evento);
                    foreach (Inscripcion inscripcion in inscripciones)
                    {
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTR;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD;
                        this.dataTable.Text += M11_RecursosInterfaz.Seleccionar;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.CerrarTR;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion

            }
            else if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                Competencia competencia = new Competencia();
                competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                Categoria categoria = new Categoria();
                categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                competencia.Categoria = categoria;

                if (Session["M11_especialidad"].ToString().Equals("1"))
                {
                    //bModificar.Visible = false;
                    //bModificarKata.Visible = true;
                }
                else if (Session["M11_especialidad"].ToString().Equals("2"))
                {
                    //bModificar.Visible = false;
                    //bModificarKumite.Visible = true;
                }
                else if (Session["M11_especialidad"].ToString().Equals("3"))
                {
                    //bModificar.Visible = false;
                    //bModificarAmbas.Visible = true;
                }
            }
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M11_ListarResultadoCompetencia.aspx");
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
            List<Evento> listaE = LogicaAsistencia.EventosPorFecha(Session["M11_fecha"].ToString(), Session["M11_fecha"].ToString());
            List<Competencia> listaC = LogicaAsistencia.competenciasPorFecha(Session["M11_fecha"].ToString());

            List<valores> listaEventos = new List<valores>();
            foreach (Evento evento in listaE)
            {
                listaEventos.Add(new valores(evento.Id_evento, evento.Nombre, M11_RecursosInterfaz.Evento));
            }
            foreach (Competencia competencia in listaC)
            {
                listaEventos.Add(new valores(competencia.Id_competencia, competencia.Nombre, M11_RecursosInterfaz.Competencia));
            }
            return listaEventos;
        }

        private void llenarComboCategoria(List<Categoria> lista)
        {
            Dictionary<int, string> listaCategoria = new Dictionary<int, string>();
            foreach (Categoria categoria in lista)
            {
                string nombre = " ";
                if (categoria.Id_categoria.Equals(0))
                {
                    nombre = M11_RecursosInterfaz.SeleccionarCategoria;
                }
                else
                {
                    nombre = categoria.Edad_inicial.ToString() + " a " + categoria.Edad_final.ToString() + " años " + categoria.Cinta_inicial + " - " + categoria.Cinta_final + " " + categoria.Sexo;
                }
                listaCategoria.Add(categoria.Id_categoria, nombre);
            }
            comboCategoria.DataSource = listaCategoria;
            comboCategoria.DataTextField = M11_RecursosInterfaz.Value;
            comboCategoria.DataValueField = M11_RecursosInterfaz.Key;
            comboCategoria.DataBind();
        }

        private void llenarComboEventoCompetencia(List<Evento> eventos, List<Competencia> competencias)
        {
            Dictionary<int, string> listaEventos = new Dictionary<int, string>();
            foreach (Evento evento in eventos)
            {
                listaEventos.Add(evento.Id_evento, evento.Nombre);
            }
            foreach (Competencia competencia in competencias)
            {
                listaEventos.Add(competencia.Id_competencia, competencia.Nombre);
            }
            comboEventos.DataSource = listaEventos;
            comboEventos.DataTextField = M11_RecursosInterfaz.Value;
            comboEventos.DataValueField = M11_RecursosInterfaz.Key;
            comboEventos.DataBind();
        }

        private void llenarComboEspecialidad(List<string> lista)
        {
            Dictionary<int, string> listaEspecialidad = new Dictionary<int, string>();
            foreach (string especialidad in lista)
            {
                string nuevo = "";
                if (especialidad.Equals("0"))
                {
                    nuevo = M11_RecursosInterfaz.SeleccionarEspecialidad;
                }
                else if (especialidad.Equals("1"))
                {
                    nuevo = "Kata";
                }
                else if (especialidad.Equals("2"))
                {
                    nuevo = "Kumite";
                }
                else if (especialidad.Equals("3"))
                {
                    nuevo = "Kata y Kumite";
                }
                listaEspecialidad.Add(Convert.ToInt32(especialidad), nuevo);
            }
            comboEspecialidad.DataSource = listaEspecialidad;
            comboEspecialidad.DataTextField = M11_RecursosInterfaz.Value;
            comboEspecialidad.DataValueField = M11_RecursosInterfaz.Key;
            comboEspecialidad.DataBind();
        }
    }
}