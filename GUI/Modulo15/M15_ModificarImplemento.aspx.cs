﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
namespace templateApp.GUI.Modulo15
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        public void cargarDatosModificar(int idImplemento) {
            InterfazImplemento implementoInterfaz=null;
            Implemento implemento=null;
            try
            {
                implementoInterfaz = new InterfazImplemento();
                implemento=implementoInterfaz.implementoInventarioInterfaz(idImplemento);
                this.id_implemento.Value = idImplemento.ToString();
                this.nombre_implemento.Value = implemento.Nombre_Implemento;
                this.tipo_implemento.Value = implemento.Tipo_Implemento;
                this.marca_implemento.Value = implemento.Marca_Implemento;
                this.talla_implemento.Value = implemento.Talla_Implemento;
                this.precio_implemento.Value = implemento.Precio_Implemento.ToString();
                this.stock_implemento.Value = implemento.Stock_Minimo_Implemento.ToString();
                this.color_implemento.Value = implemento.Color_Implemento;
                this.descripcion_implemento.Value = implemento.Descripcion_Implemento;
                this.cantidad_implemento.Value = implemento.Cantida_implemento.ToString();

                 

            }
            catch (Exception ex)
            {
                throw ex;
            }


        
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";
          //  this.btnmodificarImplemento.Click+= new EventHandler(this.evento_modificar);
            int idImplemento =Convert.ToInt16(Request.QueryString["idImplemento"]);
            if (idImplemento != 0) {
                cargarDatosModificar(idImplemento);
            
            }
            String modificar = Request.QueryString["modificar"];
            if (modificar != null)
            {

                if (modificar.Equals("fallo"))
                {
                    alert2.Attributes["class"] = "alert alert-error alert-dismissible";
                    alert2.Attributes["role"] = "alert";
                    alert2.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se pudo Modificar el Implemento</div>";

                }

            }

        }
    }
}