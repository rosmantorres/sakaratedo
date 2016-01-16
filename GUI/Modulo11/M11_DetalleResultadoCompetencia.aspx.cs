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
                String idEvento = Request.QueryString[M11_RecursosInterfaz.Mostrar];
                String tipo = Request.QueryString[M11_RecursosInterfaz.Tipo];
                Session["M11_IdEvento"] = "3";
                Session["M11_tipo"] = "Evento";

                if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Evento))
                {
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
                            this.dataTable.Text += M11_RecursosInterfaz.AbrirTR;
                            this.dataTable.Text += M11_RecursosInterfaz.AbrirTD + inscripcion.Persona.Nombre + " " + inscripcion.Persona.Apellido + M11_RecursosInterfaz.CerrarTD;
                            this.dataTable.Text += M11_RecursosInterfaz.AbrirTD;
                            if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursosInterfaz.valorSi))
                            {
                                this.dataTable.Text += M11_RecursosInterfaz.Aprobado;
                            }
                            else if (inscripcion.ResAscenso.ElementAt(0).Aprobado.Equals(M11_RecursosInterfaz.valorNo))
                            {
                                this.dataTable.Text += M11_RecursosInterfaz.NoAprobado;
                            }
                            this.dataTable.Text += M11_RecursosInterfaz.CerrarTD;
                            this.dataTable.Text += M11_RecursosInterfaz.CerrarTR;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                
                }
                else if (Session["M11_tipo"].Equals(M11_RecursosInterfaz.Competencia))
                {
                    lEspecialidad.Visible = true;
                    especialidadEvento.Visible = true;
                    competencia = LogicaAsistencia.consultarCompetenciasXIDDetalle(Session["M11_IdEvento"].ToString());
                    fechaEvento.Text = competencia.FechaInicio.ToShortDateString();
                    nombreEvento.Text = competencia.Nombre;
                    especialidadEvento.Text = calcularEspecialidad(competencia);
                    categoriaEvento.Text = competencia.Categoria.Edad_inicial.ToString() + " a " + competencia.Categoria.Edad_final.ToString() + " años " + competencia.Categoria.Cinta_inicial + " - " + competencia.Categoria.Cinta_final + " " + competencia.Categoria.Sexo;
                }
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M11_ListarResultadoCompetencia.aspx");
        }

        private string calcularEspecialidad(Competencia competencia)
        {
            string nuevo = "";
             if (competencia.TipoCompetencia.Equals("1"))
                {
                    nuevo = "Kata";
                }
                else if (competencia.TipoCompetencia.Equals("2"))
                {
                    nuevo = "Kumite";
                }
                else if (competencia.TipoCompetencia.Equals("3"))
                {
                    nuevo = "Kata y Kumite";
                }
            return nuevo;
        }
    }
}