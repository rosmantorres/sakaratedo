using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo13;
using DominioSKD;

namespace templateApp.GUI.Modulo13
{
    public partial class WebForm1 : System.Web.UI.Page
    {
              
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "13";
            

            //try
            //{
               

            //    TableRow fila = new TableRow();
            //    TableCell celda = new TableCell();
            //   // fila.Cells
            //    celda.Controls.Add(new LiteralControl("valor"));
            //    fila.Cells.Add(celda);
                
            //   //example.Rows.Add(fila);
            //    //TABLA.Rows.Add();

            //   List<Persona> laLista;
            //   LogicaAtletaCinta logCinta = new LogicaAtletaCinta();
            //   laLista = logCinta.obtenerListaPersona();

            //   foreach (DominioSKD.Persona valor in laLista)
            //   {


            //       //Response.Write("<tr>");
            //       //Response.Write("<td>" + valor.Nombre + "</td>");
            //       celda.Controls.Add(new LiteralControl(valor.Nombre));
            //       fila.Cells.Add(celda);
            //       celda.Controls.Add(new LiteralControl(valor.Apellido));
            //       fila.Cells.Add(celda);
            //       celda.Controls.Add(new LiteralControl((valor.Edad).ToString()));
            //       fila.Cells.Add(celda);
            //       celda.Controls.Add(new LiteralControl(String.Format("{0:0,0.0000000}", valor.Estatura)));
            //       fila.Cells.Add(celda);
            //       celda.Controls.Add(new LiteralControl(String.Format("{0:0,0.0000000}", valor.Peso)));
            //       fila.Cells.Add(celda);
            //       //Response.Write("<td>" + valor.Apellido + "</td>");
            //       //Response.Write("<td>" + valor.Edad + "</td>");
            //       //Response.Write("<td>" + valor.Peso + "</td>");
            //       //Response.Write("<td>" + valor.Estatura + "</td>");


            //       example.Rows.Add(fila);
            //   }


            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}



        }
    }
}