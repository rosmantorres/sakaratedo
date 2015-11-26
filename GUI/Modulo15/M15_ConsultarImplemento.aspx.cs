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

        
  


        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "15";
            String eliminar = Request.QueryString["eliminar"];
            String consultar = Request.QueryString["consultar"];
            String modificar = Request.QueryString["modificar"];



            if (consultar != null) {

                if (consultar.Equals("Activo")) { 
                  
                  
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