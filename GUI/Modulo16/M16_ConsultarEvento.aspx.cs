using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo16;
using DominioSKD;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarEvento : System.Web.UI.Page
    {
        private List<Evento> laLista = new List<Evento>();

        public static int usuario = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            try
            {
            
                M16_ConsultarEvento.usuario = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                String detalleString = Request.QueryString["impDetalle"];

                if (detalleString != null)
                {
                    llenarModalInfo(int.Parse(detalleString));
                }           

        #region Llenar Data Table Con Evento

                Logicaevento logComp = new Logicaevento();
                if (!IsPostBack)
                {            
                    laLista = logComp.obtenerListaDeEvento();

                    foreach (Evento c in laLista)
                    {
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Id_evento.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Nombre.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Descripcion.ToString() + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Costo.ToString() + M16_Recursointerfaz.CERRAR_TD;

                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.COMBOCANTIDAD + c.Id_evento.ToString() + "_combo" + M16_Recursointerfaz.CERRAR_COMBO;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_INFO_EVENTO + c.Id_evento + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_AGREGAR_EVENTO_CARRITO + c.Id_evento + "_" + c.Costo + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TR;
                    }
                }  
            }
            catch(System.Web.HttpException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";
                
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                    "al buscar alguno de los items de su carrito </div>";
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";
               
            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
                
            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
              
            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
                
            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
               
            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
               
            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
               
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
                
            }       
            #endregion
        }


        #region Llamada para el Detalle del Evento por id
        protected void llenarModalInfo(int Id_evento)
        {
            try
            {
                Evento elEvento = new Evento();
                Logicaevento logica = new Logicaevento();
                elEvento = logica.detalleEventoXId(Id_evento);
            }
            catch (System.Web.HttpException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";

            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }  
        }
        #endregion

        #region Llenado del Modal de Informacion del evento
        [System.Web.Services.WebMethod]
        public static string prueba(string id)
        {
            try{        
    
                Evento elEvento = new Evento();
                Logicaevento logica = new Logicaevento();
                elEvento = logica.detalleEventoXId(int.Parse(id));
                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(elEvento);
                return json;

            }
            catch (InvalidOperationException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";
            }
            catch (System.Web.HttpException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
            }

            return null;
          
        }
        #endregion

        #region Llenado del Modal para agregar el producto al carrito
        [System.Web.Services.WebMethod]

        public static string agregarEventoaCarrito(int idEvento, int cantidad, int precio)
        {
            try
            {
                Logicacarrito logica = new Logicacarrito();

                bool agregar = false;

                agregar = logica.agregarEventoaCarrito(usuario, idEvento, cantidad, precio);

                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(agregar);

                return json;
            }
            catch (InvalidOperationException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha producido una" +
                    "operacion invalida</div>";
            }
            
            catch (System.Web.HttpException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";
            }

            return null;
           
        }
        #endregion

    }
}