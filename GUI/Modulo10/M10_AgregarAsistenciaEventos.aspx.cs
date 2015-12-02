﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_AgregarAsistenciaEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";
            if (!IsPostBack)
            {
                listaInscritos.Items.Add("atleta1");
                listaInscritos.Items.Add("atleta2");
                listaInscritos.Items.Add("atleta3");
                listaInscritos.Items.Add("atleta4");
                listaAsistentes.Items.Add("atleta5");
                listaAsistentes.Items.Add("atleta6");
                listaAsistentes.Items.Add("atleta7");
                listaAsistentes.Items.Add("atleta8");
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
            Response.Redirect("M10_ListarAsistenciaEventos.aspx?eliminacionSuccess=1");
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("M10_ListarAsistenciaEventos.aspx");
        }
    }
}