using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo13;
using System.Data.SqlClient;
//using System.Data;

namespace templateApp.GUI.Modulo13
{
    public partial class M13_Info_Producto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "13";

            try
            {
                TableRow fila = new TableRow();
                TableCell celda = new TableCell();
                celda.Controls.Add(new LiteralControl("valor"));
                fila.Cells.Add(celda);
                example.Rows.Add(fila);
                
               SqlDataReader resultado;
              // resultado = LogicaNegociosSKD.Modulo13.LogicaInfo_Producto.L_Info_Producto(DropDownList1.SelectedItem.Value);
               
               /*
               List<Persona> laLista;
               LogicaAtletaCinta logCinta = new LogicaAtletaCinta();
               laLista = logCinta.obtenerListaPersona();
                */
            /*    while (resultado.Read())
               {

                //Response.Write("<tr>");
                //Response.Write("<td>" + valor.Nombre + "</td>");
                celda.Controls.Add(new LiteralControl(resultado[0].ToString()));
                fila.Cells.Add(celda);
                celda.Controls.Add(new LiteralControl(resultado[1].ToString()));
                fila.Cells.Add(celda);
                celda.Controls.Add(new LiteralControl(resultado[2].ToString()));
                fila.Cells.Add(celda);
                /*
                    celda.Controls.Add(new LiteralControl(String.Format("{0:0,0.0000000}", valor.Estatura)));
                fila.Cells.Add(celda);
                celda.Controls.Add(new LiteralControl(String.Format("{0:0,0.0000000}",valor.Estatura)));
                fila.Cells.Add(celda);
                //celda.Controls.Add(new LiteralControl(valor.Nombre));
                //fila.Cells.Add(celda);
                //Response.Write("<td>" + valor.Apellido + "</td>");
                //Response.Write("<td>" + valor.Edad + "</td>");
                //Response.Write("<td>" + valor.Peso + "</td>");
                //Response.Write("<td>" + valor.Estatura + "</td>");
                    

                 example.Rows.Add(fila);
               } */
            }
            catch (Exception ex)
            {
                throw ex;
            }



            }




        

         protected void Button1_Click(object sender, EventArgs e) 
         {
             if (DropDownList1.SelectedValue == "-1")
             {
                 Response.Write("Porvafor Selecciona un Continente");

             }
             else
             {   
                  Response.Write(DropDownList1.SelectedItem.Text+"<br/>");
                  Response.Write(DropDownList1.SelectedItem.Value + "<br/>");
                  Response.Write(DropDownList1.SelectedIndex + "<br/>");
             }

             
         }


    }
}



  