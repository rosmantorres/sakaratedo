using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo15;
using DominioSKD;
namespace templateApp.GUI.Modulo15
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        #region listaImplementosInterfaz
        public List<Implemento> listaImplementosInterfaz() {

            InterfazImplemento listaInterfaz = new InterfazImplemento();
            List<Implemento> listaImplementos=null;
            try
            {

               listaImplementos = listaInterfaz.listarInventarioInterfaz();
            
            }
            catch (Exception ex) {

                alert2.Attributes["class"] = "alert alert-error alert-dismissible";
                alert2.Attributes["role"] = "alert";
                alert2.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se Pudo consultar los implementos</div>";
 
            }
            return listaImplementos;
        
        } 
#endregion 

        #region  listaImplementosInterfaz2
        public List<Implemento> listaImplementosInterfaz2()
        {

            InterfazImplemento listaInterfaz = new InterfazImplemento();
            List<Implemento> listaImplementos = null;
            try
            {

                listaImplementos = listaInterfaz.listarInventarioInterfaz2();

            }
            catch (Exception ex)
            {

                alert2.Attributes["class"] = "alert alert-error alert-dismissible";
                alert2.Attributes["role"] = "alert";
                alert2.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se Pudo consultar los implementos</div>";

            }
            return listaImplementos;

        } 

        #endregion


        #region eliminarInterfazImplemento
        public void eliminarInterfazImplemento(int idImplemento) {
            InterfazImplemento interfazImplemento;

            try {
                interfazImplemento = new InterfazImplemento();
                interfazImplemento.implementoInventarioInterfaz(idImplemento);
               

            } catch (Exception ex){
            
            
            }

        
        
        }
        
        #endregion 
        
        #region eliminarEvento
        public void eliminarEvento(int idInventario) {
            InterfazImplemento interfazImplemento = null;
              
            try {
                interfazImplemento = new InterfazImplemento();
                interfazImplemento.eliminarInventarioInterfaz(idInventario);
            
            }
            catch(Exception ex){

                throw ex;
            }
        
        }

        #endregion 

        
        #region agregarImplementoInterfaz
        public void agregarImplementoInterfaz( 
                                             String nombre_implemento,
                                             String tipo_implemento,
                                             String marca_implemento,
                                             String color_implemento,
                                             String talla_implemento,
                                             int dojo, int cantidad,
                                             int stock_minimo,
                                             String estatus_implemento,
                                             double precio_implemento)
        {
            InterfazImplemento implementoInterfaz=null;

            try {

                implementoInterfaz = new InterfazImplemento();
                implementoInterfaz.agregarInventarioInterfaz( nombre_implemento,
                                              tipo_implemento,
                                              marca_implemento,
                                              color_implemento,
                                              talla_implemento,
                                              dojo,  cantidad,
                                              stock_minimo,
                                              estatus_implemento,
                                              precio_implemento);
            
            }
            catch(Exception ex){
                
                throw ex;
            
            }
        }
        #endregion 

        
        #region modificarImplementoInterfaz
        public void modificarImplementoInterfaz(
                                             int id_implemento,  
                                             String nombre_implemento,
                                             String tipo_implemento,
                                             String marca_implemento,
                                             String color_implemento,
                                             String talla_implemento,
                                             int dojo, int cantidad,
                                             int stock_minimo,
                                             String estatus_implemento,
                                             double precio_implemento)
        {
            InterfazImplemento implementoInterfaz = null;

            try
            {

                implementoInterfaz = new InterfazImplemento();
                implementoInterfaz.modificarInventarioInterfaz(id_implemento, nombre_implemento,
                                              tipo_implemento,
                                              marca_implemento,
                                              color_implemento,
                                              talla_implemento,
                                              dojo, cantidad,
                                              stock_minimo,
                                              estatus_implemento,
                                              precio_implemento);

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        #endregion 

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";
            //variables agregar
            
            int id_implemento = Convert.ToInt16(Request.Form["id_implemento"]);
            String nombre_implemento = Request.Form["nombre_implemento"];
            String tipo_implemento = Request.Form["tipo_implemento"];
            String marca_implemento=Request.Form["marca_implemento"];
            String color_implemento=Request.Form["color_implemento"];
            String talla_implemento=Request.Form["talla_implemento"];
            int dojo =1;
            int cantidad=Convert.ToInt16(Request.Form["cantidad_implemento"]);
            int stock_minimo=Convert.ToInt16(Request.Form["stock_implemento"]);
            String estatus_implemento=Request.Form["estatus_implemento"];
            double precio_implemento = Convert.ToDouble(Request.Form["precio_implemento"]);
         
           /* int id_implemento = 53;
            String nombre_implemento ="prueba";
            String tipo_implemento = "df";
            String marca_implemento = "df";
            String color_implemento = "df";
            String talla_implemento = "df";
            int dojo = 1;
            int cantidad =1;
            int stock_minimo =1;
            String estatus_implemento = "Activo";
            double precio_implemento = 1;
         */
        
            String eliminar = Request.QueryString["eliminar"];
            String consultar = Request.QueryString["consultar"];
         
            
            String agregar = Request.Form["agregar"];
            String modificar = Request.Form["modificar"];
            


            if (agregar != null){

                

                if (agregar.Equals("agregar")) {

                    agregarImplementoInterfaz(nombre_implemento,
                                              tipo_implemento,
                                              marca_implemento,
                                              color_implemento,
                                              talla_implemento,
                                              dojo,  cantidad,
                                              stock_minimo,
                                              estatus_implemento,
                                              precio_implemento);
                
                }
            
            }


            if (modificar != null)
            {

    

                if (modificar.Equals("modificar"))
                {
                    id_implemento = Convert.ToInt16(Request.Form["ctl00$contenidoCentral$id_implemento"]);
                    nombre_implemento = Request.Form["ctl00$contenidoCentral$nombre_implemento"];
                    tipo_implemento = Request.Form["ctl00$contenidoCentral$tipo_implemento"];
                    marca_implemento = Request.Form["ctl00$contenidoCentral$marca_implemento"];
                    color_implemento = Request.Form["ctl00$contenidoCentral$color_implemento"];
                    talla_implemento = Request.Form["ctl00$contenidoCentral$talla_implemento"];
                    dojo = 1;
                    cantidad = Convert.ToInt16(Request.Form["ctl00$contenidoCentral$cantidad_implemento"]);
                    stock_minimo = Convert.ToInt16(Request.Form["ctl00$contenidoCentral$stock_implemento"]);
                    estatus_implemento = Request.Form["ctl00$contenidoCentral$estatus_implemento"];
                    precio_implemento = Convert.ToDouble(Request.Form["ctl00$contenidoCentral$precio_implemento"]);
         

                

                    modificarImplementoInterfaz(id_implemento,
                                              nombre_implemento,
                                              tipo_implemento,
                                              marca_implemento,
                                              color_implemento,
                                              talla_implemento,
                                              dojo, cantidad,
                                              stock_minimo,
                                              estatus_implemento,
                                              precio_implemento);

                }

            }

            if (eliminar != null)
            {
                if (eliminar.Equals("true"))
                {

                    int idInventario =Convert.ToInt16(Request.QueryString["idImplemento"]);
                    eliminarEvento(idInventario);

          //          alert.Attributes["class"] = "alert alert-success alert-dismissible";
            //        alert.Attributes["role"] = "alert";
              //      alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Implemento deportivo eliminado exitosamente</div>";
                }

            }

          

        }
    }
}