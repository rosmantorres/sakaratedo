﻿using DominioSKD;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";
            LogicaEvento logicaEvento = new LogicaEvento();
            if (!IsPostBack)
            {
                String idEvento = Request.QueryString["modificar"];
                String tipo = Request.QueryString["tipo"];

                Session["M10_IdEvento"] = idEvento;
                Session["M10_tipo"] = tipo;

                if (Session["M10_tipo"].Equals("evento"))
                {
                    evento = logicaEvento.ConsultarEvento(Session["M10_IdEvento"].ToString());
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
                else if (Session["M10_tipo"].Equals("competencia"))
                {

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
            List<Persona> listaA2 = new List<Persona>();
            List<Persona> listaI2 = new List<Persona>();
            listas(listaA2, listaI2);
            foreach (Persona persona in listaA2)
            {
                string asistio = "S";
                LogicaAsistencia.ModificarAsistenciaEvento(persona.IdInscripcion, Convert.ToInt32(Session["M10_IdEvento"]), asistio);
            }

            foreach (Persona persona in listaI2)
            {
                string asistio = "N";
                LogicaAsistencia.ModificarAsistenciaEvento(persona.IdInscripcion, Convert.ToInt32(Session["M10_IdEvento"]), asistio);

            }
            Response.Redirect("M10_ListarAsistenciaEventos.aspx?success=2");
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M10_ListarAsistenciaEventos.aspx");
        }

        private void listas(List<Persona> listaA2, List<Persona> listaI2)
        {
            foreach (Persona persona in listaA)
            {
                foreach (var listBoxItem in listaAsistentes.Items)
                {
                    if (persona.Nombre.Equals(listBoxItem.ToString()))
                    {
                        listaA2.Add(persona);
                    }
                }

                foreach (var listBoxItem in listaNoAsistieron.Items)
                {
                    if (persona.Nombre.Equals(listBoxItem.ToString()))
                    {
                        listaI2.Add(persona);
                    }
                }
            }

            foreach (Persona persona in listaI)
            {
                foreach (var listBoxItem in listaAsistentes.Items)
                {
                    if (persona.Nombre.Equals(listBoxItem.ToString()))
                    {
                        listaA2.Add(persona);
                    }
                }

                foreach (var listBoxItem in listaNoAsistieron.Items)
                {
                    if (persona.Nombre.Equals(listBoxItem.ToString()))
                    {
                        listaI2.Add(persona);
                    }
                }
            }
        }
    }
}