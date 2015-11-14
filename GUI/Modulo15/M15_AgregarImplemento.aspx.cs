using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo15;


namespace templateApp.GUI.Modulo15
{      
   
    public partial class M15_Prueba : System.Web.UI.Page
    {  
        
        void iniciar() { 
            Implemento implementos = new Implemento();
            implementos.consultarImplemento();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            iniciar();
            ((SKD)Page.Master).IdModulo = "15";
            String success = Request.QueryString["success"];
            String valor="";
            Boolean estado = false;



            if (success != null)
            {
                if (success.Equals("1"))
                {

                    if (Request.Form["contenidoCentral_nombre_articulo"] == "")
                    {
                        valor = valor + "el nombres del articulo  esta Vacio</br>"; estado = true;
                    
                    }
                   

                    if (tipo_articulo.Value == "")
                    {
                        valor = valor + "el tipo articulo  esta Vacio</br>"; estado = true;

                    }


                  
                    
                    if (estado)
                    {
                     //   alert.Attributes["class"] = "alert alert-error alert-dismissible";
                      //  alert.Attributes["role"] = "alert";
                      //  alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button> " + valor + "</div>";
                    }
                 }
            }


        }
    }
}