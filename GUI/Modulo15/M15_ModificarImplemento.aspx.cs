using System;
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
                this.nombre_implemento.Value = implemento.Nombre_Implemento;
                this.tipo_implemento.Value = implemento.Tipo_Implemento;
                this.marca_implemento.Value = implemento.Marca_Implemento;
                this.talla_implemento.Value = implemento.Talla_Implemento;
                this.precio_implemento.Value = implemento.Precio_Implemento.ToString();
                this.stock_implemento.Value = implemento.Stock_Minimo_Implemento.ToString();
                this.color_implemento.Value = implemento.Color_Implemento;
                this.cantidad_inventario.Value = implemento.Cantida_implemento.ToString();

                 

            }
            catch (Exception ex)
            {
                throw ex;
            }


        
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";
            int idImplemento =Convert.ToInt16(Request.QueryString["idImplemento"]);
            cargarDatosModificar(idImplemento);


        }
    }
}