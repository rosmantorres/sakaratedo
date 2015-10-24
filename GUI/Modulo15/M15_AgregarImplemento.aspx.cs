using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo15
{
    public partial class M15_Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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


                    if (cantidad_inventario.Value == "")
                    {
                        valor = valor + "Cantidad del Inventario esta Vacio</br>"; estado = true;

                    }


                    if (precio_producto.Value == "")
                    {
                        valor = valor + "Precio del Articulo esta Vacio</br>"; estado = true;

                    }
                    if (color_implemento.Value == "")
                    {
                        valor = valor + "Color del Articulo esta Vacio</br>"; estado = true;

                    }
                    if (marca_implemento.Value == "")
                    {
                        valor = valor + "Marca del Articulo esta Vacio</br>"; estado = true;

                    }
                    if (talla_implemento.Value == "")
                    {
                        valor = valor + "talla de Articulo esta Vacio</br>"; estado = true;

                    }
                    if (nombre_dojo.Value == "")
                    {
                        valor = valor + "Nombre del dojo esta Vacio</br>"; estado = true;

                    }
                    
                    if (estado)
                    {
                        alert.Attributes["class"] = "alert alert-error alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button> " + valor + "</div>";
                    }
                 }
            }


        }
    }
}