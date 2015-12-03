using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo16;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarMensualidad : System.Web.UI.Page
    {
        private List<Matricula> laListaDeMatriculas = new List<Matricula>();
        public static int usuario = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            try
            {

                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name); 

                M16_ConsultarMensualidad.usuario = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                String success = Request.QueryString["success"];
                String usuario = Request.QueryString["compAgregar"];
                String matricula = Request.QueryString["compAgregar"];



                if (success != null)
                {
                    if (success.Equals("1"))
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Matricula agregada exitosamente</div>";
                    }
                    if (usuario != null && matricula != null)
                    {
                        // agregarMatriculaAcarrito(1, 1);
                    }

                }



                #region Llenar Data Table Con Matriculas

                Logicamatricula logComp = new Logicamatricula();
                if (!IsPostBack)
                {
                    
                        laListaDeMatriculas = logComp.mostrarMensualidadesmorosas();

                        foreach (Matricula m in laListaDeMatriculas)
                        {


                            this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;
                            this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                            // this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.Id.ToString() + M16_Recursointerfaz.CERRAR_TD;
                            this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.Identificador.ToString() + M16_Recursointerfaz.CERRAR_TD;
                            this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.FechaCreacion.ToString() + M16_Recursointerfaz.CERRAR_TD;
                            this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + m.UltimaFechaPago.ToString() + M16_Recursointerfaz.CERRAR_TD;

                            this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                            this.laTabla.Text += M16_Recursointerfaz.BOTON_AGREGAR_MATRICULA_CARRITO + m.ID + "_" + m.Costo + M16_Recursointerfaz.BOTON_CERRAR;
                            this.laTabla.Text += M16_Recursointerfaz.CERRAR_TD;
                            this.laTabla.Text += M16_Recursointerfaz.CERRAR_TR;




                        }

                    
                }
                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
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

        #region Llamada para Agregar Matricula al Carrito

        [System.Web.Services.WebMethod]
        public static string agregarMatriculaAcarrito(int idMatricula, int precio)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                Logicacarrito logica = new Logicacarrito();

                bool agregar = false;

                agregar = logica.agregarMatriculaaCarrito(usuario, idMatricula, 1, precio);

                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(agregar);

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return json;
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
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                    "al buscar alguno de los items de su carrito </div>";
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
