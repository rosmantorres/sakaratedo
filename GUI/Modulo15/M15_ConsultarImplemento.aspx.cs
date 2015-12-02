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
        public String usuario;
        private Dojo dojo;

        
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
            try
            {
                String rolUsuario = Session[RecursosInterfazMaster.sessionRol].ToString();
                Boolean permitido = false;
                List<String> rolesPermitidos = new List<string>
                    (new string[] { "Sistema", "Dojo", "Organización", "Atleta", "Representante", "Atleta(Menor)" });
                foreach (String rol in rolesPermitidos)
                {
                    if (rol == rolUsuario)
                        permitido = true;
                }
                if (permitido)
                {
                    //Aqui va su codigo
           
            InterfazImplemento implementoInterfaz=null;
            implementoInterfaz = new InterfazImplemento();


            int id_implemento;
            String nombre_implemento;
            String tipo_implemento;
            String marca_implemento;
            String color_implemento;
            String talla_implemento;
            int cantidad;
            int stock_minimo;
            String estatus_implemento;
            String descripcion_implemento;
            double precio_implemento;

            // imagen////////////
            HttpPostedFile archivo = Request.Files["imagen_implemento"];
            string TargetLocation ;
            string imagen_implemento =null;
           /////////////
 
            //////////// variables de  get 
            String eliminar = Request.QueryString["eliminar"];
            String consultar = Request.QueryString["consultar"];     
            String agregar = Request.Form["agregar"];
            String modificar = Request.Form["modificar"];
            ////////////////////////////////


            ////////////////////usuario y rol para manejar
            String rol = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
            String usuario = Session[templateApp.GUI.Master.RecursosInterfazMaster.sessionUsuarioNombre].ToString();
            Dojo dojo = implementoInterfaz.usuarioImplementoInterfaz(usuario);

            this.usuario = usuario;
            this.dojo = dojo;
            this.nombre_dojo.InnerText=dojo.Nombre_dojo;
            ///////////////////////////////////


            if (agregar != null){
                if (agregar.Equals("agregar")) {

                    try
                    {

                        #region datosAgregar
                        id_implemento = Convert.ToInt16(Request.Form["id_implemento"]);
                        nombre_implemento = Request.Form["nombre_implemento"];
                        tipo_implemento = Request.Form["tipo_implemento"];
                        marca_implemento = Request.Form["marca_implemento"];
                        color_implemento = Request.Form["color_implemento"];
                        talla_implemento = Request.Form["talla_implemento"];
                        cantidad = Convert.ToInt32(Request.Form["cantidad_implemento"]);
                        stock_minimo = Convert.ToInt32(Request.Form["stock_implemento"]);
                        estatus_implemento = Request.Form["estatus_implemento"];
                        descripcion_implemento = Request.Form["descripcion_implemento"];
                        precio_implemento = Convert.ToDouble(Request.Form["precio_implemento"]);
                        #endregion


                        archivo = Request.Files["imagen_implemento"];
                        TargetLocation = Server.MapPath("~/GUI/Modulo15/Imagen/");
                        imagen_implemento = archivo.FileName;
                        archivo.SaveAs(TargetLocation + imagen_implemento);


                        Implemento implemento = new Implemento(id_implemento, nombre_implemento, tipo_implemento, marca_implemento, color_implemento, talla_implemento, imagen_implemento, cantidad, stock_minimo, estatus_implemento, precio_implemento, descripcion_implemento, dojo);
                        agregarImplementoInterfaz(implemento);


                    }
                    catch (ErrorInputInterfaz ex2)
                    {

                        ErrorInputInterfaz ex = new ExcepcionesSKD.Modulo15.ErrorInputInterfaz(ex2.Codigo, "Error en Interfaz con valores de input", new Exception());
                        Logger.EscribirError("M15_ConsultarImplemento", ex);
                        Response.Redirect("~/GUI/Modulo15/M15_AgregarImplemento.aspx?agregar=fallo&excepcion=ErrorInputInterfaz");

                    }
                    catch (ExceptionSKD ex2)
                    {
                        ErrorInputInterfaz ex = new ExcepcionesSKD.Modulo15.ErrorInputInterfaz(ex2.Codigo, "Error en Interfaz con valores de input", new Exception());
                        Logger.EscribirError("M15_ConsultarImplemento", ex);
                        Response.Redirect("~/GUI/Modulo15/M15_AgregarImplemento.aspx?agregar=fallo&excepcion=ErrorInputInterfaz");

                    
                    }
                    catch (Exception ex2)
                    {
                        Response.Redirect("~/GUI/Modulo15/M15_AgregarImplemento.aspx?agregar=fallo&excepcion=ErrorInputInterfaz");
                    

                    }
                    
                }
            
            }


            if (modificar != null)
            {

                if (modificar.Equals("modificar"))
                {
                    try
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

                    #endregion 


                    Implemento implemento = new Implemento(id_implemento, nombre_implemento, tipo_implemento, marca_implemento, color_implemento, talla_implemento, imagen_implemento, cantidad, stock_minimo, estatus_implemento, precio_implemento, descripcion_implemento, dojo);
                    modificarImplementoInterfaz(implemento);
                    
                    }
                    catch (ErrorInputInterfaz ex2)
                    {

                        ErrorInputInterfaz ex = new ExcepcionesSKD.Modulo15.ErrorInputInterfaz(ex2.Codigo, "Error en Interfaz con valores de input", new Exception());
                        Logger.EscribirError("M15_ConsultarImplemento", ex);
                        Response.Redirect("~/GUI/Modulo15/M15_ModificarImplemento.aspx?modificar=fallo&excepcion=ErrorInputInterfaz");

                    }
                    catch (ExceptionSKD ex2)
                    {
                        ErrorInputInterfaz ex = new ExcepcionesSKD.Modulo15.ErrorInputInterfaz(ex2.Codigo, "Error en Interfaz con valores de input", new Exception());
                        Logger.EscribirError("M15_ConsultarImplemento", ex);
                        Response.Redirect("~/GUI/Modulo15/M15_ModificarImplemento.aspx?modificar=fallo&excepcion=ErrorInputInterfaz");


                    }
                    catch (Exception ex2)
                    {
                        Response.Redirect("~/GUI/Modulo15/M15_ModificarImplemento.aspx?modificar=fallo&excepcion=ErrorInputInterfaz");


                    }
                    
                    

                }

            }

            if (eliminar != null)
            {

                if (eliminar.Equals("true"))
                {
                   

                    int idInventario = Convert.ToInt16(Request.QueryString["idImplemento"]);
                    try {
            
                        eliminarEvento(idInventario, dojo);
                        

                    }
                    catch(ExceptionSKD ex){

                        Response.Redirect("~/GUI/Modulo15/M15_ConsultarImplemento.aspx?eliminar=fallo");

                    }
                }
                else {
                    if (eliminar.Equals("fallo")) {


                        alert2.Attributes["class"] = "alert alert-error alert-dismissible";
                        alert2.Attributes["role"] = "alert";
                        alert2.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se pudo Eliminar el Implemento</div>";
 
                    }
                
                
                
                }

            }


                }
                else
                {
                    Response.Redirect(RecursosInterfazMaster.direccionMaster_Inicio);
                }

            }
            catch (NullReferenceException ex)
            {


            }

        }
    }
}