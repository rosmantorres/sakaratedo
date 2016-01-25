using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo11;
using LogicaNegociosSKD.Modulo9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_DetalleResultadoCompetencia : System.Web.UI.Page
    {
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            if (!IsPostBack)
            {
                String idEvento = Request.QueryString[M11_RecursoInterfaz.Mostrar];
                String tipo = Request.QueryString[M11_RecursoInterfaz.Tipo];
                Session["M11_IdEvento"] = idEvento;
                Session["M11_tipo"] = tipo;

                if (Session["M11_tipo"].Equals(M11_RecursoInterfaz.Evento))
                {
                    #region Detalle de Eventos Examen de Ascenso
                    evento = LogicaResultado.ConsultarEventoDetalle(Session["M11_IdEvento"].ToString());
                    fechaEvento.Text = evento.Horario.FechaInicio.ToShortDateString();
                    nombreEvento.Text = evento.Nombre;
                    evento.Id_evento = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                    categoriaEvento.Text = evento.Categoria.Edad_inicial.ToString() + " a " + evento.Categoria.Edad_final.ToString() + " años " + evento.Categoria.Cinta_inicial + " - " + evento.Categoria.Cinta_final + " " + evento.Categoria.Sexo;
                    try
                    {
                        List<Inscripcion> inscripciones = LogicaResultado.listaAtletasEnCategoriaYAscenso(evento);
                        foreach (Inscripcion inscripcion in inscripciones)
                        {
                            this.dataTable.Text += M11_RecursoInterfaz.AbrirTR;
                            this.dataTable.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursoInterfaz.CerrarTD;
                            this.dataTable.Text += M11_RecursoInterfaz.AbrirTD;
                            if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursoInterfaz.valorSi))
                            {
                                this.dataTable.Text += M11_RecursoInterfaz.Aprobado;
                            }
                            else if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursoInterfaz.valorNo))
                            {
                                this.dataTable.Text += M11_RecursoInterfaz.NoAprobado;
                            }
                            this.dataTable.Text += M11_RecursoInterfaz.CerrarTD;
                            this.dataTable.Text += M11_RecursoInterfaz.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion
                }
                else if (Session["M11_tipo"].Equals(M11_RecursoInterfaz.Competencia))
                {
                    lEspecialidad.Visible = true;
                    especialidadEvento.Visible = true;
                    competencia = LogicaAsistencia.consultarCompetenciasXIDDetalle(Session["M11_IdEvento"].ToString());
                    fechaEvento.Text = competencia.FechaInicio.ToShortDateString();
                    nombreEvento.Text = competencia.Nombre;
                    especialidadEvento.Text = calcularEspecialidad(competencia);
                    competencia.Id_competencia = Convert.ToInt32(Session["M11_IdEvento"].ToString());
                    categoriaEvento.Text = competencia.Categoria.Edad_inicial.ToString() + " a " + competencia.Categoria.Edad_final.ToString() + " años " + competencia.Categoria.Cinta_inicial + " - " + competencia.Categoria.Cinta_final + " " + competencia.Categoria.Sexo;

                    if (especialidadEvento.Text.Equals(M11_RecursoInterfaz.Kata))
                    {
                        #region Detalle de Competencia tipo Kata
                        try
                        {
                            List<Inscripcion> inscripciones = LogicaResultado.listaAtletasParticipanCompetenciaKata(competencia);
                            foreach (Inscripcion inscripcion in inscripciones)
                            {
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTR;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.ResKata.ElementAt(0).Jurado1 + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.ResKata.ElementAt(0).Jurado2 + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.ResKata.ElementAt(0).Jurado3 + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.CerrarTR;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        #endregion
                    }
                    else if (especialidadEvento.Text.Equals(M11_RecursoInterfaz.Kumite))
                    {
                        #region Detalle de Competencia tipo Kumite
                        try
                        {
                            List<ResultadoKumite> listaKumite = LogicaResultado.listaAtletasParticipanCompetenciaKumite(competencia);
                            foreach (ResultadoKumite resultado in listaKumite)
                            {
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTR;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTD + resultado.Id_ResKumite + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTDNombre1 + resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTD;
                                this.dataTable3.Text += resultado.Puntaje1;
                                this.dataTable3.Text += M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTDNombre2 + resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTD;
                                this.dataTable3.Text += resultado.Puntaje2;
                                this.dataTable3.Text += M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.CerrarTR;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        #endregion
                    }
                    else if (especialidadEvento.Text.Equals(M11_RecursoInterfaz.Kata_Kumite))
                    {
                        #region Detalle de Competencia tipo Kata Ambos
                        try
                        {
                            List<Inscripcion> inscripciones = LogicaResultado.listaAtletasParticipanCompetenciaKataAmbas(competencia);
                            foreach (Inscripcion inscripcion in inscripciones)
                            {
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTR;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.ResKata.ElementAt(0).Jurado1 + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.ResKata.ElementAt(0).Jurado2 + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.AbrirTD + inscripcion.ResKata.ElementAt(0).Jurado3 + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable2.Text += M11_RecursoInterfaz.CerrarTR;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        #endregion
                        #region Detalle de Competencia tipo Kumite Ambos
                        try
                        {
                            competencia.TipoCompetencia = "4";
                            List<ResultadoKumite> listaKumite = LogicaResultado.listaAtletasParticipanCompetenciaKumiteAmbas(competencia);
                            foreach (ResultadoKumite resultado in listaKumite)
                            {
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTR;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTD + resultado.Id_ResKumite + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTDNombre1 + resultado.Inscripcion1.Persona.Nombre + " " + resultado.Inscripcion1.Persona.Apellido + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTD;
                                this.dataTable3.Text += resultado.Puntaje1;
                                this.dataTable3.Text += M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTDNombre2 + resultado.Inscripcion2.Persona.Nombre + " " + resultado.Inscripcion2.Persona.Apellido + M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.AbrirTD;
                                this.dataTable3.Text += resultado.Puntaje2;
                                this.dataTable3.Text += M11_RecursoInterfaz.CerrarTD;
                                this.dataTable3.Text += M11_RecursoInterfaz.CerrarTR;
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
        }

        private string calcularEspecialidad(Competencia competencia)
        {
            string nuevo = "";
            if (competencia.TipoCompetencia.Equals("1"))
            {
                nuevo = M11_RecursoInterfaz.Kata;
            }
            else if (competencia.TipoCompetencia.Equals("2"))
            {
                nuevo = M11_RecursoInterfaz.Kumite;
            }
            else if (competencia.TipoCompetencia.Equals("3"))
            {
                nuevo = M11_RecursoInterfaz.Kata_Kumite;
            }
            return nuevo;
        }
    }
}