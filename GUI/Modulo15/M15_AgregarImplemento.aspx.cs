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

        public void agregarImplementoInventario() {
            LogicaImplemento lista = new LogicaImplemento();


            try
            {

          /*  lista.agregarImplementoLogica(this.nombre_implemento.Value,
                                          this.tipo_implemento.Value,
                                          this.marca_implemento.Value,
                                          this.color_implemento.Value,
                                          this.talla_implemento.Value,
                                          Convert.ToInt16(this.nombre_dojo.Value),
                                          Convert.ToInt16( this.cantidad_inventario.Value),
                                          Convert.ToInt16(this.stock_implemento.Value),
                                          "Activo",
                                          Convert.ToInt16(this.precio_producto.Value)
                                          );
                */
            }
            catch(Exception ex) {

                alert2.Attributes["class"] = "alert alert-error alert-dismissible";
                alert2.Attributes["role"] = "alert";
                alert2.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se pudo Agregar el Implemento</div>";
 
            
            }
        
        }


        public void agregarImplemento_Click(Object sender, EventArgs e)
        { 
             
            agregarImplementoInventario();   
          
        }
   

        protected void Page_Load(object sender, EventArgs e)
        {

           
            ((SKD)Page.Master).IdModulo = "15";
            String success = Request.QueryString["success"];
            String agregar =Request.QueryString["agregar"];
            String excepcion =Request.QueryString["excepcion"];
            String valor="";
            Boolean estado = false;

            if (agregar!= null) {

                if ((agregar.Equals("fallo"))&&(excepcion.Equals("ErrorInputInterfaz"))) {
                    alert2.Attributes["class"] = "alert alert-error alert-dismissible";
                    alert2.Attributes["role"] = "alert";
                    alert2.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se pudo Agregar el Implemento</div>";  
                
                }
            
            }

            if (success != null)
            {
                if (success.Equals("1"))
                {

                    if (Request.Form["contenidoCentral_nombre_implemento"] == "")
                    {
                        valor = valor + "el nombres del implemento  esta Vacio</br>"; estado = true;
                    
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