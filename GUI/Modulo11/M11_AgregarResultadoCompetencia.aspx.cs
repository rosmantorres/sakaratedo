using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo11;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
    struct valorEvento
    {
        public string nombre;
        public string resultado;
    }
    struct valorKataKumite
    {
        public string nombre;
        public string resultado1;
        public string resultado2;
        public string resultado3;
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
            dataTable2.Text = " ";
            dataTable3.Text = " ";
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
                lPosicion.Visible = true;
                listaGanadores.Visible = true;
                llenarComboEspecialidad(LogicaResultado.listaEspecialidadesCompetencia(Session["M11_IdEvento"].ToString()));
            }
        }

        protected void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Text = " ";
            comboCategoria.Items.Clear();
            dataTable2.Text = " ";
            dataTable3.Text = " ";
            Session["M11_especialidad"] = ((DropDownList)sender).SelectedItem.Value;
            Competencia competencia = new Competencia();
            competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
            competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
            llenarComboCategoria(LogicaResultado.listaCategoriasCompetencia(competencia));
        }

        protected void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Text = " ";
            dataTable2.Text = " ";
            dataTable3.Text = " ";
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
                    bAgregar.Visible = false;
                    bAgregarKata.Visible = true;
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kata
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                        foreach (Inscripcion inscripcion in inscripciones)
                        {
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTR;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.SeleccionarCombo1;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.SeleccionarCombo2;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.SeleccionarCombo3;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else if (Session["M11_especialidad"].ToString().Equals("2"))
                {
                    bAgregar.Visible = false;
                    bAgregarKumite.Visible = true;
                    bAgregarKumite.Enabled = false;
                    bSiguiente.Visible = true;
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                        if ((inscripciones.Count != 1) && (inscripciones.Count != 0))
                        {
                            int rango = buscarNumeroPermitido(inscripciones) / 2;
                            Session["M11_Rango"] = rango;
                            List<ResultadoKumite> listaKumite = crearRandomPeleas(inscripciones, rango);
                            foreach (ResultadoKumite resultado in listaKumite)
                            {
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTR;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre1 + resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.SeleccionarCombo1;
                                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre2 + resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.SeleccionarCombo2;
                                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTR;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else if (Session["M11_especialidad"].ToString().Equals("3"))
                {
                    bAgregar.Visible = false;
                    bAgregarAmbos.Visible = true;
                    bAgregarAmbos.Enabled = false;
                    bSiguienteAmbos.Visible = true;
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kata
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                        foreach (Inscripcion inscripcion in inscripciones)
                        {
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTR;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.SeleccionarCombo1;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.SeleccionarCombo2;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.SeleccionarCombo3;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                        if ((inscripciones.Count != 1) && (inscripciones.Count != 0))
                        {
                            int rango = buscarNumeroPermitido(inscripciones) / 2;
                            Session["M11_Rango"] = rango;
                            List<ResultadoKumite> listaKumite = crearRandomPeleas(inscripciones, rango);
                            foreach (ResultadoKumite resultado in listaKumite)
                            {
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTR;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre1 + resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.SeleccionarCombo1;
                                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre2 + resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.SeleccionarCombo2;
                                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTR;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
            }
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
            {
                #region Agregar Examen de Ascenso
                Evento evento = new Evento();
                evento.Id_evento = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                Categoria categoria = new Categoria();
                categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                evento.Categoria = categoria;

                try
                {
                    List<Inscripcion> inscripciones = LogicaResultado.listaInscritosExamenAscenso(evento);
                    List<valorEvento> valores = JsonConvert.DeserializeObject<List<valorEvento>>(rvalue.Value);
                    List<ResultadoAscenso> listaResultado = new List<ResultadoAscenso>();

                    foreach (Inscripcion inscripcion in inscripciones)
                    {
                        foreach (valorEvento valor in valores)
                        {
                            string aprobado = buscarAprobado(valor);
                            if ((inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido).Equals(valor.nombre))
                            {
                                ResultadoAscenso resultado = new ResultadoAscenso();
                                resultado.Inscripcion = inscripcion;
                                resultado.Inscripcion.Evento.Id_evento = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                resultado.Aprobado = aprobado;
                                listaResultado.Add(resultado);
                            }
                        }
                    }

                    if (LogicaResultado.agregarResultadoAscenso(listaResultado))
                    {
                        Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=1");
                    }
                    else
                        Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=3");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M11_ListarResultadoCompetencia.aspx");
        }

        protected void bAgregarKata_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                if (Session["M11_especialidad"].ToString().Equals("1"))
                {
                    #region Agregar Competencia tipo kata
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                    competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                    competencia.Categoria = categoria;
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                        List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue.Value);
                        List<ResultadoKata> listaResultado = new List<ResultadoKata>();

                        foreach (Inscripcion inscripcion in inscripciones)
                        {
                            foreach (valorKataKumite valor in valores)
                            {
                                if (((inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido).Equals(valor.nombre)))
                                {
                                    ResultadoKata resultado = new ResultadoKata();
                                    resultado.Inscripcion = inscripcion;
                                    resultado.Inscripcion.Competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                    resultado.Jurado1 = Convert.ToInt32(valor.resultado1);
                                    resultado.Jurado2 = Convert.ToInt32(valor.resultado2);
                                    resultado.Jurado3 = Convert.ToInt32(valor.resultado3);
                                    listaResultado.Add(resultado);
                                }
                            }
                        }
                        if (LogicaResultado.agregarResultadoKata(listaResultado))
                        {
                            Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=5");
                        }
                        else
                            Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=6");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
            }
        }

        protected void bAgregarKumite_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                if (Session["M11_especialidad"].ToString().Equals("2"))
                {
                    if (Convert.ToInt32(Session["M11_Rango"].ToString()) < 1)
                    {
                        #region Agregar Competencia tipo kumite
                        Competencia competencia = new Competencia();
                        competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                        competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                        Categoria categoria = new Categoria();
                        categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                        competencia.Categoria = categoria;
                        try
                        {
                            List<Inscripcion> inscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                            List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                            List<ResultadoKumite> listaKumite = new List<ResultadoKumite>();

                            foreach (valorKataKumite valor in valores)
                            {
                                ResultadoKumite resultadok = new ResultadoKumite();
                                foreach (Inscripcion inscripcion in inscripciones)
                                {
                                    if ((valor.nombre.Equals(inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido)))
                                    {
                                        resultadok.Puntaje1 = Convert.ToInt32(valor.resultado1);
                                        resultadok.Inscripcion1 = inscripcion;
                                    }
                                    if ((valor.resultado2.Equals(inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido)))
                                    {
                                        resultadok.Puntaje2 = Convert.ToInt32(valor.resultado3);
                                        resultadok.Inscripcion2 = inscripcion;
                                    }
                                }
                                listaKumite.Add(resultadok);
                            }
                            if (LogicaResultado.agregarResultadoKumite(listaKumite))
                            {
                                Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=13");
                            }
                            else
                                Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=14");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        #endregion
                    }
                }
            }
        }

        protected void bAgregarAmbos_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                if (Session["M11_especialidad"].ToString().Equals("3"))
                {
                    if (Convert.ToInt32(Session["M11_Rango"].ToString()) < 1)
                    {
                        #region Agregar Competencia tipo Kata y kumite
                        Competencia competencia = new Competencia();
                        competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                        competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                        Categoria categoria = new Categoria();
                        categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                        competencia.Categoria = categoria;
                        try
                        {
                            List<Inscripcion> inscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                            List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                            List<ResultadoKumite> listaKumite = new List<ResultadoKumite>();

                            foreach (valorKataKumite valor in valores)
                            {
                                ResultadoKumite resultadok = new ResultadoKumite();
                                foreach (Inscripcion inscripcion in inscripciones)
                                {
                                    if ((valor.nombre.Equals(inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido)))
                                    {
                                        resultadok.Puntaje1 = Convert.ToInt32(valor.resultado1);
                                        resultadok.Inscripcion1 = inscripcion;
                                    }
                                    if ((valor.resultado2.Equals(inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido)))
                                    {
                                        resultadok.Puntaje2 = Convert.ToInt32(valor.resultado3);
                                        resultadok.Inscripcion2 = inscripcion;
                                    }
                                }
                                listaKumite.Add(resultadok);
                            }
                            if (LogicaResultado.agregarResultadoKumite(listaKumite))
                            {
                                Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=15");
                            }
                            else
                                Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=16");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        #endregion
                    }
                }
            }
        }

        protected void bSiguiente_Click(object sender, EventArgs e)
        {
            alert.Visible = false;
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                Session["M11_Rango"] = Convert.ToInt32(Session["M11_Rango"].ToString()) / 2;
                Competencia competencia = new Competencia();
                competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                Categoria categoria = new Categoria();
                categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                competencia.Categoria = categoria;

                if (Session["M11_especialidad"].ToString().Equals("2"))
                {
                    #region Carga de tabla de Atletas compitiendo
                    try
                    {
                        if (Convert.ToInt32(Session["M11_Rango"].ToString()) >= 1)
                        {
                            List<Inscripcion> listaInscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                            List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                            List<Inscripcion> inscripciones = new List<Inscripcion>();
                            List<ResultadoKumite> listaKumite = new List<ResultadoKumite>();

                            bool bleh = listaAtletasCompitiendo_AgregandoAnteriores(listaInscripciones, valores, inscripciones, listaKumite);
                            if (bleh.Equals(false))
                            {
                                listaKumite = crearRandomPeleas(inscripciones, Convert.ToInt32(Session["M11_Rango"].ToString()));
                                pintarTabla(listaKumite);
                            }
                            else if (bleh.Equals(true))
                            {
                                Session["M11_Rango"] = Convert.ToInt32(Session["M11_Rango"].ToString()) * 2;
                                ListaEmpate(listaKumite);
                                alert.Visible = true;
                                alert.Attributes["class"] = "alert alert-warning alert-dismissible";
                                alert.Attributes["role"] = "alert";
                                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los EMPATES en las Competencias de tipo Kumite no estan permitidos.</div>";
                            }
                        }
                        else if (Convert.ToInt32(Session["M11_Rango"].ToString()) < 1)
                        {
                            List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                            if (!verificandoEmpate(valores))
                            {
                                ListaFinal(valores);
                                primeroSegundo(valores);
                                bSiguiente.Visible = false;
                                bAgregarKumite.Enabled = true;
                            }
                            else if (verificandoEmpate(valores))
                            {
                                ListaFinal(valores);
                                bSiguiente.Visible = true;
                                bAgregarKumite.Enabled = false;
                                Session["M11_Rango"] = Convert.ToInt32(Session["M11_Rango"].ToString()) + 1;
                                alert.Visible = true;
                                alert.Attributes["class"] = "alert alert-warning alert-dismissible";
                                alert.Attributes["role"] = "alert";
                                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los EMPATES en las Competencias de tipo Kumite no estan permitidos.</div>";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else if (Session["M11_especialidad"].ToString().Equals("3"))
                {
                    #region Carga de tabla de Atletas compitiendo ambos
                    try
                    {
                        if (Convert.ToInt32(Session["M11_Rango"].ToString()) >= 1)
                        {
                            List<Inscripcion> listaInscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                            List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                            List<Inscripcion> inscripciones = new List<Inscripcion>();
                            List<ResultadoKumite> listaKumite = new List<ResultadoKumite>();

                            bool bleh = listaAtletasCompitiendo_AgregandoAnteriores(listaInscripciones, valores, inscripciones, listaKumite);
                            if (bleh.Equals(false))
                            {
                                listaKumite = crearRandomPeleas(inscripciones, Convert.ToInt32(Session["M11_Rango"].ToString()));
                                pintarTabla(listaKumite);
                            }
                            else if (bleh.Equals(true))
                            {
                                Session["M11_Rango"] = Convert.ToInt32(Session["M11_Rango"].ToString()) * 2;
                                ListaEmpate(listaKumite);
                                alert.Visible = true;
                                alert.Attributes["class"] = "alert alert-warning alert-dismissible";
                                alert.Attributes["role"] = "alert";
                                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los EMPATES en las Competencias de tipo Kumite no estan permitidos.</div>";
                            }
                        }
                        else if (Convert.ToInt32(Session["M11_Rango"].ToString()) < 1)
                        {
                            List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                            if (!verificandoEmpate(valores))
                            {
                                ListaFinal(valores);
                                primeroSegundo(valores);
                                bSiguiente.Visible = false;
                                bAgregarAmbos.Enabled = true;
                            }
                            else if (verificandoEmpate(valores))
                            {
                                ListaFinal(valores);
                                bSiguiente.Visible = true;
                                bAgregarAmbos.Enabled = false;
                                Session["M11_Rango"] = Convert.ToInt32(Session["M11_Rango"].ToString()) + 1;
                                alert.Visible = true;
                                alert.Attributes["class"] = "alert alert-warning alert-dismissible";
                                alert.Attributes["role"] = "alert";
                                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los EMPATES en las Competencias de tipo Kumite no estan permitidos.</div>";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
            }
        }

        protected void bSiguienteAmbos_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                Session["M11_Rango"] = Convert.ToInt32(Session["M11_Rango"].ToString()) / 2;
                Competencia competencia = new Competencia();
                competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                Categoria categoria = new Categoria();
                categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                competencia.Categoria = categoria;

                if (Session["M11_especialidad"].ToString().Equals("3"))
                {
                    #region Carga de tabla de Atletas compitiendo ambos
                    try
                    {
                        if (Convert.ToInt32(Session["M11_Rango"].ToString()) >= 1)
                        {
                            List<Inscripcion> listaInscripciones = LogicaResultado.listaInscritosCompetencia(competencia);
                            List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                            List<Inscripcion> inscripciones = new List<Inscripcion>();
                            List<ResultadoKumite> listaKumite = new List<ResultadoKumite>();

                            bool bleh = listaAtletasCompitiendo_AgregandoAnteriores(listaInscripciones, valores, inscripciones, listaKumite);
                            if (bleh.Equals(false))
                            {
                                listaKumite = crearRandomPeleas(inscripciones, Convert.ToInt32(Session["M11_Rango"].ToString()));
                                pintarTabla(listaKumite);
                            }
                            else if (bleh.Equals(true))
                            {
                                Session["M11_Rango"] = Convert.ToInt32(Session["M11_Rango"].ToString()) * 2;
                                ListaEmpate(listaKumite);
                                alert.Attributes["class"] = "alert alert-warning alert-dismissible";
                                alert.Attributes["role"] = "alert";
                                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los EMPATES en las Competencias de tipo Kumite no estan permitidos.</div>";
                            }
                        }

                        #region Agregar Competencia tipo kata
                        List<Inscripcion> inscripciones2 = LogicaResultado.listaInscritosCompetencia(competencia);
                        List<valorKataKumite> valores2 = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue.Value);
                        List<ResultadoKata> listaResultado = new List<ResultadoKata>();

                        foreach (Inscripcion inscripcion in inscripciones2)
                        {
                            foreach (valorKataKumite valor in valores2)
                            {
                                if (((inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido).Equals(valor.nombre)))
                                {
                                    ResultadoKata resultado = new ResultadoKata();
                                    resultado.Inscripcion = inscripcion;
                                    resultado.Inscripcion.Competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                    resultado.Jurado1 = Convert.ToInt32(valor.resultado1);
                                    resultado.Jurado2 = Convert.ToInt32(valor.resultado2);
                                    resultado.Jurado3 = Convert.ToInt32(valor.resultado3);
                                    listaResultado.Add(resultado);
                                }
                            }
                        }
                        LogicaResultado.agregarResultadoKata(listaResultado);
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
            }
            bSiguienteAmbos.Visible = false;
            bSiguiente.Visible = true;
            this.dataTable2.Text = " ";
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

        private string buscarAprobado(valorEvento valor)
        {
            string aprobado = "";
            if (valor.resultado.Equals(M11_RecursosInterfaz.Aprobado))
            {
                aprobado = M11_RecursosInterfaz.valorSi;
            }
            else if (valor.resultado.Equals(M11_RecursosInterfaz.NoAprobado))
            {
                aprobado = M11_RecursosInterfaz.valorNo;
            }
            return aprobado;
        }

        private int buscarNumeroPermitido(List<Inscripcion> lista)
        {
            int n = lista.Count();
            if (n >= 16)
            {
                n = 16;
            }
            else if ((n >= 8) && (n <= 16))
            {
                n = 8;
            }
            else if ((n >= 4) && (n <= 8))
            {
                n = 4;
            }
            else if ((n >= 2) && (n <= 4))
            {
                n = 2;
            }
            return n;
        }

        private List<ResultadoKumite> crearRandomPeleas(List<Inscripcion> inscripciones, int rango)
        {
            List<ResultadoKumite> listaKumite = new List<ResultadoKumite>();
            while (rango != 0)
            {
                ResultadoKumite resultado = new ResultadoKumite();
                Random rnd = new Random();
                int r = rnd.Next(inscripciones.Count);
                resultado.Inscripcion1 = inscripciones.ElementAt(r);
                inscripciones.RemoveAt(r);
                r = rnd.Next(inscripciones.Count);
                resultado.Inscripcion2 = inscripciones.ElementAt(r);
                inscripciones.RemoveAt(r);
                listaKumite.Add(resultado);
                rango--;
            }
            return listaKumite;
        }

        private bool listaAtletasCompitiendo_AgregandoAnteriores(List<Inscripcion> inscripciones, List<valorKataKumite> valores, List<Inscripcion> lista, List<ResultadoKumite> listaKumite)
        {
            bool empate = false;
            try
            {
                foreach (valorKataKumite valor in valores)
                {
                    ResultadoKumite resultadok = new ResultadoKumite();
                    foreach (Inscripcion inscripcion in inscripciones)
                    {
                        if ((valor.nombre.Equals(inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido)))
                        {
                            resultadok.Puntaje1 = Convert.ToInt32(valor.resultado1);
                            resultadok.Inscripcion1 = inscripcion;
                        }
                        if ((valor.resultado2.Equals(inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido)))
                        {
                            resultadok.Puntaje2 = Convert.ToInt32(valor.resultado3);
                            resultadok.Inscripcion2 = inscripcion;
                        }
                    }
                    listaKumite.Add(resultadok);
                }
                empate = inscripcionesEnCurso(listaKumite, lista);
                if (empate.Equals(false))
                {
                    LogicaResultado.agregarResultadoKumite(listaKumite);
                }
                dataTable3.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empate;
        }

        private void pintarTabla(List<ResultadoKumite> listaKumite)
        {
            foreach (ResultadoKumite resultado in listaKumite)
            {
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTR;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre1 + resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                this.dataTable3.Text += M11_RecursosInterfaz.SeleccionarCombo1;
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre2 + resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                this.dataTable3.Text += M11_RecursosInterfaz.SeleccionarCombo2;
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTR;
            }
        }

        private bool inscripcionesEnCurso(List<ResultadoKumite> listaKumite, List<Inscripcion> lista)
        {
            bool aprobado = false;
            foreach (ResultadoKumite resultado in listaKumite)
            {
                Inscripcion enCurso = new Inscripcion();
                if (resultado.Puntaje1 > resultado.Puntaje2)
                {
                    enCurso = resultado.Inscripcion1;
                }
                else if (resultado.Puntaje2 > resultado.Puntaje1)
                {
                    enCurso = resultado.Inscripcion2;
                }
                if (resultado.Puntaje1 == resultado.Puntaje2)
                {
                    aprobado = true;
                    break;
                }
                else if (resultado.Puntaje2 == resultado.Puntaje1)
                {
                    aprobado = true;
                    break;
                }
                lista.Add(enCurso);
            }
            return aprobado;
        }

        private void primeroSegundo(List<valorKataKumite> valores)
        {
            if (Convert.ToInt32(valores.ElementAt(0).resultado1) > Convert.ToInt32(valores.ElementAt(0).resultado3))
            {
                listaGanadores.Items.Add("1er Lugar -----------" + valores.ElementAt(0).nombre);
                listaGanadores.Items.Add("2do Lugar -----------" + valores.ElementAt(0).resultado2);
            }
            else if (Convert.ToInt32(valores.ElementAt(0).resultado3) > Convert.ToInt32(valores.ElementAt(0).resultado1))
            {
                listaGanadores.Items.Add("1er Lugar -----------" + valores.ElementAt(0).resultado2);
                listaGanadores.Items.Add("2do Lugar -----------" + valores.ElementAt(0).nombre);
            }
        }

        private string resultadosComboTablas(int valor, int combo)
        {
            string resultado = "";
            switch (valor)
            {
                case 1:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo1;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo1;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo1;
                    break;
                case 2:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo2;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo2;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo2;
                    break;
                case 3:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo3;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo3;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo3;
                    break;
                case 4:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo4;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo4;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo4;
                    break;
                case 5:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo5;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo5;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo5;
                    break;
                case 6:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo6;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo6;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo6;
                    break;
                case 7:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo7;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo7;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo7;
                    break;
                case 8:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo8;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo8;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo8;
                    break;
                case 9:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo9;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo9;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo9;
                    break;
                case 10:
                    if (combo.Equals(1))
                        resultado = M11_RecursosInterfaz.r1Combo10;
                    else if (combo.Equals(2))
                        resultado = M11_RecursosInterfaz.r2Combo10;
                    else if (combo.Equals(3))
                        resultado = M11_RecursosInterfaz.r3Combo10;
                    break;
            }
            return resultado;
        }

        private void ListaFinal(List<valorKataKumite> valores)
        {
            this.dataTable3.Text = " ";
            foreach (valorKataKumite resultado in valores)
            {
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTR;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre1 + resultado.nombre + M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                this.dataTable3.Text += resultadosComboTablas(Convert.ToInt32(resultado.resultado1), 1);
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre2 + resultado.resultado2 + M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                this.dataTable3.Text += resultadosComboTablas(Convert.ToInt32(resultado.resultado3), 2);
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTR;
            }
        }

        private void ListaEmpate(List<ResultadoKumite> valores)
        {
            this.dataTable3.Text = " ";
            foreach (ResultadoKumite resultado in valores)
            {
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTR;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre1 + resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                this.dataTable3.Text += resultadosComboTablas(resultado.Puntaje1, 1);
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTDNombre2 + resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD;
                this.dataTable3.Text += resultadosComboTablas(resultado.Puntaje2, 2);
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTD;
                this.dataTable3.Text += M11_RecursosInterfaz.CerrarTR;
            }
        }

        private bool verificandoEmpate(List<valorKataKumite> lista)
        {
            bool aprobado = false;
            foreach (valorKataKumite resultado in lista)
            {
                if ((Convert.ToInt32(resultado.resultado1) > Convert.ToInt32(resultado.resultado3)) || (Convert.ToInt32(resultado.resultado3) > Convert.ToInt32(resultado.resultado1)))
                {
                    aprobado = false;
                }
                else if ((Convert.ToInt32(resultado.resultado1) == Convert.ToInt32(resultado.resultado3)) || (Convert.ToInt32(resultado.resultado3) == Convert.ToInt32(resultado.resultado1)))
                {
                    aprobado = true;
                }
            }
            return aprobado;
        }
    }
}