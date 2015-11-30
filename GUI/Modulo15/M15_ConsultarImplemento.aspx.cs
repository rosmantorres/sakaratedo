using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo15;
using DominioSKD;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo15;
using templateApp.GUI.Modulo1;
using templateApp.GUI.Master;
using System.Web.SessionState;


namespace templateApp.GUI.Modulo15
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        
        #region listaImplementosInterfaz
        public List<Implemento> listaImplementosInterfaz(Dojo dojo) {

            InterfazImplemento listaInterfaz = new InterfazImplemento();
            List<Implemento> listaImplementos=null;
            try
            {

               listaImplementos = listaInterfaz.listarInventarioInterfaz(dojo);
            
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
        public List<Implemento> listaImplementosInterfaz2(Dojo dojo)
        {

            InterfazImplemento listaInterfaz = new InterfazImplemento();
            List<Implemento> listaImplementos = null;
            try
            {

                listaImplementos = listaInterfaz.listarInventarioInterfaz2(dojo);

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
        public void eliminarEvento(int idInventario,Dojo dojo) {
            InterfazImplemento interfazImplemento = null;
              
            try {
                interfazImplemento = new InterfazImplemento();
                interfazImplemento.eliminarInventarioInterfaz(idInventario,dojo);
            
            }
            catch(Exception ex){

                throw ex;
            }
        
        }

        #endregion 

        
        #region agregarImplementoInterfaz
        public void agregarImplementoInterfaz( Implemento implemento)
        {
            InterfazImplemento implementoInterfaz=null;

            try {

                implementoInterfaz = new InterfazImplemento();
                implementoInterfaz.agregarInventarioInterfaz(implemento);
            
            }
            catch(Exception ex){
                
                throw ex;
            
            }
        }
        #endregion 

        
        #region modificarImplementoInterfaz
        public void modificarImplementoInterfaz(Implemento implemento)
        {
            InterfazImplemento implementoInterfaz = null;

            try
            {

                implementoInterfaz = new InterfazImplemento();
                implementoInterfaz.modificarInventarioInterfaz(implemento);

            }
            catch (ExceptionSKD ex)
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
            int id_dojo =1;
            int cantidad=Convert.ToInt16(Request.Form["cantidad_implemento"]);
            int stock_minimo=Convert.ToInt16(Request.Form["stock_implemento"]);
            String estatus_implemento=Request.Form["estatus_implemento"];
            String descripcion_implemento = Request.Form["descripcion_implemento"];
            double precio_implemento = Convert.ToDouble(Request.Form["precio_implemento"]);

            HttpPostedFile archivo = Request.Files["imagen_implemento"];
            string TargetLocation ;
            string imagen_implemento =null;
            
        
            String eliminar = Request.QueryString["eliminar"];
            String consultar = Request.QueryString["consultar"];
         
            
            String agregar = Request.Form["agregar"];
            String modificar = Request.Form["modificar"];


            //usuario y rol para manejar
            String rol = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
            String usuario = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionUsuarioNombre].ToString();
          


            if (agregar != null){

                if (agregar.Equals("agregar")) {
                    
                    archivo = Request.Files["imagen_implemento"];
                    TargetLocation = Server.MapPath("~/GUI/Modulo15/Imagen/");
                    imagen_implemento = archivo.FileName;
                    archivo.SaveAs(TargetLocation + imagen_implemento);
                    //pasar dado el usuario a que dojo pertenece
                    Dojo dojo = new Dojo(id_dojo);
                    Implemento implemento = new Implemento(id_implemento, nombre_implemento, tipo_implemento, marca_implemento, color_implemento, talla_implemento, imagen_implemento, cantidad, stock_minimo, estatus_implemento, precio_implemento, descripcion_implemento, dojo);
                    try
                    {
                        agregarImplementoInterfaz(implemento);
                        

                    }
                    catch (ExceptionSKD ex) {

                        Response.Redirect("~/GUI/Modulo15/M15_AgregarImplemento.aspx?agregar=fallo");

                    }

                    
                }
            
            }


            if (modificar != null)
            {

                if (modificar.Equals("modificar"))
                {
                   
                    #region datos_modificar
                    id_implemento = Convert.ToInt16(Request.Form["ctl00$contenidoCentral$id_implemento"]);
                    nombre_implemento = Request.Form["ctl00$contenidoCentral$nombre_implemento"];
                    tipo_implemento = Request.Form["ctl00$contenidoCentral$tipo_implemento"];
                    marca_implemento = Request.Form["ctl00$contenidoCentral$marca_implemento"];
                    color_implemento = Request.Form["ctl00$contenidoCentral$color_implemento"];
                    talla_implemento = Request.Form["ctl00$contenidoCentral$talla_implemento"];
                    cantidad = Convert.ToInt16(Request.Form["ctl00$contenidoCentral$cantidad_implemento"]);
                    stock_minimo = Convert.ToInt16(Request.Form["ctl00$contenidoCentral$stock_implemento"]);
                    estatus_implemento = Request.Form["ctl00$contenidoCentral$estatus_implemento"];
                    precio_implemento = Convert.ToDouble(Request.Form["ctl00$contenidoCentral$precio_implemento"]);
                    descripcion_implemento = Request.Form["ctl00$contenidoCentral$descripcion_implemento"];
                    archivo = Request.Files["ctl00$contenidoCentral$imagen_implemento"];
                    TargetLocation = Server.MapPath("~/GUI/Modulo15/Imagen/");
                    imagen_implemento = archivo.FileName;
                    archivo.SaveAs(TargetLocation + imagen_implemento);

                    id_dojo = 1;
                    #endregion 

                    //con el usuario usar para para obtener el dojo 
                    Dojo dojo=new Dojo(id_dojo);
                    Implemento implemento = new Implemento(id_implemento, nombre_implemento, tipo_implemento, marca_implemento, color_implemento, talla_implemento, imagen_implemento, cantidad, stock_minimo, estatus_implemento, precio_implemento, descripcion_implemento, dojo);
                    try {

                        modificarImplementoInterfaz(implemento);
                    
                    }
                    catch(ExceptionSKD ex){

                        Response.Redirect("~/GUI/Modulo15/M15_ModificarImplemento.aspx?modificar=fallo");

                    }
                    

                }

            }

            if (eliminar != null)
            {
                if (eliminar.Equals("true"))
                {
                    Dojo dojo = new Dojo(id_dojo);
                    int idInventario =Convert.ToInt16(Request.QueryString["idImplemento"]);
                    eliminarEvento(idInventario,dojo);

          //          alert.Attributes["class"] = "alert alert-success alert-dismissible";
            //        alert.Attributes["role"] = "alert";
              //      alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Implemento deportivo eliminado exitosamente</div>";
                }

            }

          

        }
    }
}