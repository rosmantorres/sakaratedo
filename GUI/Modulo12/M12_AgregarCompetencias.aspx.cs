﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_AgregarCompetencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "12";
        }

        protected void btn_agregarComp_Click(object sender, EventArgs e)
        {

        }

        protected void comboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void comboCintaDesde_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}