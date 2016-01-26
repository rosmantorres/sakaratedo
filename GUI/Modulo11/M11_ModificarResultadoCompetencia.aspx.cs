using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo11;
using LogicaNegociosSKD.Modulo9;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_ModificarResultadoCompetencia : System.Web.UI.Page
    {
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            if (!IsPostBack)
            {
                String idEvento = Request.QueryString[M11_RecursosInterfaz.Modificar];
                String tipo = Request.QueryString[M11_RecursosInterfaz.Tipo];
                Session["M11_IdEvento"] = idEvento;
                Session["M11_tipo"] = tipo;

                if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
                {
                    evento = LogicaAsistencia.ConsultarEvento(Session["M11_IdEvento"].ToString());
                    fechaEvento.Text = evento.Horario.FechaInicio.ToShortDateString();
                    nombreEvento.Text = evento.Nombre;
                    lEspecialidad.Visible = false;
                    comboEspecialidad.Visible = false;
                    llenarComboCategoria(LogicaResultado.listaCategoriasEvento(Session["M11_IdEvento"].ToString()));
                }
                else if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
                {
                    lEspecialidad.Visible = true;
                    comboEspecialidad.Visible = true;
                    competencia = LogicaAsistencia.consultarCompetenciasXID(Session["M11_IdEvento"].ToString());
                    fechaEvento.Text = competencia.FechaInicio.ToShortDateString();
                    nombreEvento.Text = competencia.Nombre;
                    llenarComboEspecialidad(LogicaResultado.listaEspecialidadesCompetencia(Session["M11_IdEvento"].ToString()));
                }
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
            {
                #region Modificar Examen de Ascenso
                Evento evento = new Evento();
                evento.Id_evento = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                Categoria categoria = new Categoria();
                categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                evento.Categoria = categoria;

                try
                {
                    List<Inscripcion> inscripciones = LogicaResultado.listaAtletasEnCategoriaYAscenso(evento);
                    List<valorEvento> valores = JsonConvert.DeserializeObject<List<valorEvento>>(rvalue.Value);
                    List<ResultadoAscenso> listaResultado = new List<ResultadoAscenso>();

                    foreach (Inscripcion inscripcion in inscripciones)
                    {
                        string aprobar = buscarValorSiNo(inscripcion);
                        foreach (valorEvento valor in valores)
                        {
                            string aprobado = buscarAprobado(valor);
                            if (((inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido).Equals(valor.nombre)) && (!inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(aprobado)))
                            {
                                ResultadoAscenso resultado = new ResultadoAscenso();
                                resultado.Inscripcion = inscripcion;
                                resultado.Inscripcion.Evento.Id_evento = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                resultado.Aprobado = aprobado;
                                listaResultado.Add(resultado);
                            }
                        }
                    }

                    if (LogicaResultado.ModificarResultadoAscenso(listaResultado))
                    {
                        Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=2");
                    }
                    else
                        Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=4");
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

        protected void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable.Text = " ";
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
                    List<Inscripcion> inscripciones = LogicaResultado.listaAtletasEnCategoriaYAscenso(evento);
                    foreach (Inscripcion inscripcion in inscripciones)
                    {
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTR;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                        this.dataTable.Text += M11_RecursosInterfaz.AbrirTD;
                        if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursosInterfaz.valorSi))
                        {
                            this.dataTable.Text += M11_RecursosInterfaz.selectAprobado;
                        }
                        else if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursosInterfaz.valorNo))
                        {
                            this.dataTable.Text += M11_RecursosInterfaz.selectNoAprobado;
                        }
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
                    bModificar.Visible = false;
                    bModificarKata.Visible = true;
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kata
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaAtletasParticipanCompetenciaKata(competencia);
                        foreach (Inscripcion inscripcion in inscripciones)
                        {
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTR;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += resultadosComboTablas(inscripcion.ResKata.ElementAt(0).Jurado1, 1);
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += resultadosComboTablas(inscripcion.ResKata.ElementAt(0).Jurado2, 2);
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += resultadosComboTablas(inscripcion.ResKata.ElementAt(0).Jurado3, 3);
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
                    bModificar.Visible = false;
                    bModificarKumite.Visible = true;
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite
                    try
                    {
                        List<ResultadoKumite> listaKumite = LogicaResultado.listaAtletasParticipanCompetenciaKumite(competencia);
                        foreach (ResultadoKumite resultado in listaKumite)
                        {
                            this.dataTable3.Text += M11_RecursosInterfaz.AbrirTR;
                            this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD + resultado.Id_ResKumite + M11_RecursosInterfaz.CerrarTD;
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
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else if (Session["M11_especialidad"].ToString().Equals("3"))
                {
                    bModificar.Visible = false;
                    bModificarAmbas.Visible = true;
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kata Ambos
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaAtletasParticipanCompetenciaKataAmbas(competencia);
                        foreach (Inscripcion inscripcion in inscripciones)
                        {
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTR;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += resultadosComboTablas(inscripcion.ResKata.ElementAt(0).Jurado1, 1);
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += resultadosComboTablas(inscripcion.ResKata.ElementAt(0).Jurado2, 2);
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.AbrirTD;
                            this.dataTable2.Text += resultadosComboTablas(inscripcion.ResKata.ElementAt(0).Jurado3, 3);
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable2.Text += M11_RecursosInterfaz.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                    #region Carga de tabla de Atletas que compiten en una competencia de tipo kumite Ambos
                    try
                    {
                        competencia.TipoCompetencia = "4";
                        List<ResultadoKumite> listaKumite = LogicaResultado.listaAtletasParticipanCompetenciaKumiteAmbas(competencia);
                        foreach (ResultadoKumite resultado in listaKumite)
                        {
                            this.dataTable3.Text += M11_RecursosInterfaz.AbrirTR;
                            this.dataTable3.Text += M11_RecursosInterfaz.AbrirTD + resultado.Id_ResKumite + M11_RecursosInterfaz.CerrarTD;
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
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion

                }
            }
        }

        protected void bModificarKata_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                if (Session["M11_especialidad"].ToString().Equals("1"))
                {
                    #region Modificar Competencia tipo kata
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                    competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                    competencia.Categoria = categoria;
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaAtletasParticipanCompetenciaKata(competencia);
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
                        if (LogicaResultado.ModificarResultadoKata(listaResultado))
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

        protected void bModificarKumite_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                if (Session["M11_especialidad"].ToString().Equals("2"))
                {
                    #region Modificar Competencia tipo kumite
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                    competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                    competencia.Categoria = categoria;
                    try
                    {
                        List<ResultadoKumite> listaKumite = LogicaResultado.listaAtletasParticipanCompetenciaKumite(competencia);
                        List<valorKataKumite> valores = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                        List<ResultadoKumite> listaResultado = new List<ResultadoKumite>();

                        foreach (ResultadoKumite resultado in listaKumite)
                        {
                            foreach (valorKataKumite valor in valores)
                            {
                                if (((resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido).Equals(valor.nombre)) && ((resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido).Equals(valor.resultado2)))
                                {
                                    ResultadoKumite resultadok = new ResultadoKumite();
                                    resultadok.Puntaje1 = Convert.ToInt32(valor.resultado1);
                                    resultadok.Puntaje2 = Convert.ToInt32(valor.resultado3);
                                    Inscripcion inscripcion1 = resultado.Inscripcion1;
                                    Inscripcion inscripcion2 = resultado.Inscripcion2;
                                    inscripcion1.Competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                    inscripcion2.Competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                    resultadok.Inscripcion1 = inscripcion1;
                                    resultadok.Inscripcion2 = inscripcion2;
                                    listaResultado.Add(resultadok);
                                }
                            }
                        }
                        if (LogicaResultado.ModificarResultadoKumite(listaResultado))
                        {
                            Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=7");
                        }
                        else
                            Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=8");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
            }
        }

        protected void bModificarAmbas_Click(object sender, EventArgs e)
        {
            if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
            {
                if (Session["M11_especialidad"].ToString().Equals("3"))
                {
                    #region Modificar Competencia tipo Kata y Kumite (Ambos)
                    Competencia competencia = new Competencia();
                    competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                    competencia.TipoCompetencia = Session["M11_especialidad"].ToString();
                    Categoria categoria = new Categoria();
                    categoria.Id_categoria = Convert.ToInt32(Session["M11_categoria"].ToString());
                    competencia.Categoria = categoria;
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaAtletasParticipanCompetenciaKataAmbas(competencia);
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

                        competencia.TipoCompetencia = "4";
                        List<ResultadoKumite> listaKumite = LogicaResultado.listaAtletasParticipanCompetenciaKumiteAmbas(competencia);
                        JavaScriptSerializer json_serializer2 = new JavaScriptSerializer();
                        List<valorKataKumite> valores2 = JsonConvert.DeserializeObject<List<valorKataKumite>>(rvalue2.Value);
                        List<ResultadoKumite> listaResultado2 = new List<ResultadoKumite>();

                        foreach (ResultadoKumite resultado in listaKumite)
                        {
                            foreach (valorKataKumite valor in valores2)
                            {
                                if (((resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido).Equals(valor.nombre)) && ((resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido).Equals(valor.resultado2)))
                                {
                                    ResultadoKumite resultadok = new ResultadoKumite();
                                    resultadok.Puntaje1 = Convert.ToInt32(valor.resultado1);
                                    resultadok.Puntaje2 = Convert.ToInt32(valor.resultado3);
                                    Inscripcion inscripcion1 = resultado.Inscripcion1;
                                    Inscripcion inscripcion2 = resultado.Inscripcion2;
                                    inscripcion1.Competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                    inscripcion2.Competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                                    resultadok.Inscripcion1 = inscripcion1;
                                    resultadok.Inscripcion2 = inscripcion2;
                                    listaResultado2.Add(resultadok);
                                }
                            }
                        }

                        if ((LogicaResultado.ModificarResultadoKata(listaResultado)) && LogicaResultado.ModificarResultadoKumite(listaResultado2))
                        {
                            Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=9");
                        }
                        else
                            Response.Redirect("M11_ListarResultadoCompetencia.aspx?success=10");

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
            }
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

        private string buscarValorSiNo(Inscripcion inscripcion)
        {
            string aprobado = "";
            if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursosInterfaz.valorSi))
            {
                aprobado = M11_RecursosInterfaz.Aprobado;
            }
            else if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursosInterfaz.valorNo))
            {
                aprobado = M11_RecursosInterfaz.NoAprobado;
            }
            return aprobado;
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
    }
}