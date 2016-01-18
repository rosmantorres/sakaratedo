using DominioSKD;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_DetalleAsistenciaEvento : System.Web.UI.Page
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
                String idEvento = Request.QueryString["compDetalle"];
                String tipo = Request.QueryString["tipo"];

                if (tipo.Equals(M10_RecursosInterfaz.Evento))
                {
                    evento = LogicaAsistencia.ConsultarEvento(idEvento);
                    fechaEvento.Text = evento.Horario.FechaInicio.ToShortDateString();
                    nombreEvento.Text = evento.Nombre;

                    listaA = LogicaAsistencia.listaAsistentes(idEvento);
                    listaI = LogicaAsistencia.listaNoAsistentes(idEvento);

                    foreach (Persona persona in listaA)
                    {
                        listaAsistentes.Items.Add(persona.Nombre);
                    }

                    foreach (Persona persona in listaI)
                    {
                        listaNoAsistieron.Items.Add(persona.Nombre);
                    }
                }
                else if (tipo.Equals(M10_RecursosInterfaz.Competencia))
                {
                    competencia = LogicaAsistencia.consultarCompetenciasXID(idEvento);
                    fechaEvento.Text = competencia.FechaInicio.ToShortDateString();
                    nombreEvento.Text = competencia.Nombre;

                    listaAC = LogicaAsistencia.listaAsistentesCompetencia(idEvento);
                    listaIC = LogicaAsistencia.listaNoAsistentesCompetencia(idEvento);
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


    }
}