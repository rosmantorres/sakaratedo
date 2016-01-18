using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo9;
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
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
        List<Persona> listaA = new List<Persona>();
        List<Persona> listaI = new List<Persona>();

        List<Persona> listaAC = new List<Persona>();
        List<Persona> listaIC = new List<Persona>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";
            if (!IsPostBack)
            {
                String idEvento = Request.QueryString[M10_RecursosInterfaz.Modificar];
                String tipo = Request.QueryString[M10_RecursosInterfaz.Tipo];

                Session["M10_IdEvento"] = idEvento;
                Session["M10_tipo"] = tipo;

                if (Session["M10_tipo"].Equals(M10_RecursosInterfaz.Evento))
                {
                    evento = LogicaAsistencia.ConsultarEvento(Session["M10_IdEvento"].ToString());
                    fechaEvento.Text = evento.Horario.FechaInicio.ToShortDateString();
                    nombreEvento.Text = evento.Nombre;

                    listaA = LogicaAsistencia.listaAsistentes(Session["M10_IdEvento"].ToString());
                    listaI = LogicaAsistencia.listaNoAsistentes(Session["M10_IdEvento"].ToString());

                    foreach (Persona persona in listaA)
                    {
                        listaAsistentes.Items.Add(persona.Nombre);
                    }

                    foreach (Persona persona in listaI)
                    {
                        listaNoAsistieron.Items.Add(persona.Nombre);
                    }
                }
                else if (Session["M10_tipo"].Equals(M10_RecursosInterfaz.Competencia))
                {
                    competencia = LogicaAsistencia.consultarCompetenciasXID(Session["M10_IdEvento"].ToString());
                    fechaEvento.Text = competencia.FechaInicio.ToShortDateString();
                    nombreEvento.Text = competencia.Nombre;

                    listaAC = LogicaAsistencia.listaAsistentesCompetencia(Session["M10_IdEvento"].ToString());
                    listaIC = LogicaAsistencia.listaNoAsistentesCompetencia(Session["M10_IdEvento"].ToString());
                    foreach (Persona persona in listaAC)
                    {
                        listaAsistentes.Items.Add(persona.Nombre);
                    }

                    foreach (Persona persona in listaIC)
                    {
                        listaNoAsistieron.Items.Add(persona.Nombre);
                    }
                }
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
            if (Session["M10_tipo"].ToString().Equals(M10_RecursosInterfaz.Evento))
            {
                #region modificarEvento
                List<Persona> listaA = LogicaAsistencia.listaAsistentes(Session["M10_IdEvento"].ToString());
                List<Persona> listaI = LogicaAsistencia.listaNoAsistentes(Session["M10_IdEvento"].ToString());
                List<Asistencia> listaA2 = new List<Asistencia>();
                foreach (Persona persona in listaA)
                {
                    foreach (var listBoxItem in listaAsistentes.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "S";
                            asistencia.Evento.Id_evento = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaA2.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in listaNoAsistieron.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "N";
                            asistencia.Evento.Id_evento = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaA2.Add(asistencia);
                        }
                    }
                }

                foreach (Persona persona in listaI)
                {
                    foreach (var listBoxItem in listaAsistentes.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            if (persona.Nombre.Equals(listBoxItem.ToString()))
                            {
                                Asistencia asistencia = new Asistencia();
                                asistencia.Asistio = "S";
                                asistencia.Evento.Id_evento = Convert.ToInt32(Session["M10_IdEvento"]);
                                asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                                listaA2.Add(asistencia);
                            }
                        }
                    }

                    foreach (var listBoxItem in listaNoAsistieron.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            if (persona.Nombre.Equals(listBoxItem.ToString()))
                            {
                                Asistencia asistencia = new Asistencia();
                                asistencia.Asistio = "N";
                                asistencia.Evento.Id_evento = Convert.ToInt32(Session["M10_IdEvento"]);
                                asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                                listaA2.Add(asistencia);
                            }
                        }
                    }
                }

                if (LogicaAsistencia.ModificarAsistenciaEvento(listaA2))
                {
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=2");
                }
                else
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=3");

                #endregion
            }
            else if (Session["M10_tipo"].ToString().Equals(M10_RecursosInterfaz.Competencia))
            {
                #region modificarCompetencia
                listaAC = LogicaAsistencia.listaAsistentesCompetencia(Session["M10_IdEvento"].ToString());
                listaIC = LogicaAsistencia.listaNoAsistentesCompetencia(Session["M10_IdEvento"].ToString());
                List<Asistencia> listaAC2 = new List<Asistencia>();

                foreach (Persona persona in listaAC)
                {
                    foreach (var listBoxItem in listaAsistentes.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "S";
                            asistencia.Competencia.Id_competencia = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in listaNoAsistieron.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "N";
                            asistencia.Competencia.Id_competencia = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }
                }

                foreach (Persona persona in listaIC)
                {
                    foreach (var listBoxItem in listaAsistentes.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "S";
                            asistencia.Competencia.Id_competencia = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }

                    foreach (var listBoxItem in listaNoAsistieron.Items)
                    {
                        if (persona.Nombre.Equals(listBoxItem.ToString()))
                        {
                            Asistencia asistencia = new Asistencia();
                            asistencia.Asistio = "N";
                            asistencia.Competencia.Id_competencia = Convert.ToInt32(Session["M10_IdEvento"]);
                            asistencia.Inscripcion.Id_Inscripcion = persona.IdInscripcion;
                            listaAC2.Add(asistencia);
                        }
                    }
                }

                if (LogicaAsistencia.ModificarAsistenciaCompetencia(listaAC2))
                {
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=2");
                }
                else
                    Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=3");
                #endregion
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M10_ListarAsistenciaEventos.aspx");
        }
    }
}