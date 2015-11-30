using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo13;




namespace templateApp.GUI.Modulo13
{
    public partial class M13_Kyu_atletas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "13";


            try
            {
                
                List<Persona> laLista;
                LogicaAtletaCinta logCinta = new LogicaAtletaCinta();
                laLista = logCinta.obtenerListaPersona();
                 
                foreach (DominioSKD.Persona valor in laLista  )
                {
                    Response.Write("<tr>");
                    Response.Write("<td>" + valor.Nombre + "</td>");
                    Response.Write("<td>" + valor.Apellido + "</td>");
                    Response.Write("<td>" + valor.Edad + "</td>");
                    Response.Write("<td>" + valor.Peso + "</td>");
                    Response.Write("<td>" + valor.Estatura + "</td>");

                }

            }
             catch(Exception ex)
             {
                 throw ex;
             }


        }
    }
}