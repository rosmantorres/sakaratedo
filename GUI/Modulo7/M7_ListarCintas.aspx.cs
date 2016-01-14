using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo7;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo7;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo7;
using Interfaz_Presentadores.Modulo7;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarCintas : System.Web.UI.Page, IContratoListarCintasObtenidas
    {
        #region Atributos
        private List<Cinta> laLista = new List<Cinta>();

        #region Contrato
        string IContratoListarCintasObtenidas.laTabla
        {
            get
            {
                return laTabla.Text;
            }

            set
            {
                laTabla.Text = value;
            }
        }
        #endregion

        #endregion

        #region Page_Load
        /// <summary>
        /// Método que se ejecuta al cargar la página Listar Cintas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";

            String detalleString = Request.QueryString["compDetalle"];
            DateTime fechaInscripcion;

            #region Llenar DataTable con Cintas

            LogicaCintas logEvento = new LogicaCintas();

            try
            {
                String rolUsuario = Session[RecursosInterfazMaster.sessionRol].ToString();
                Boolean permitido = false;
                List<String> rolesPermitidos = new List<string>
                    (new string[] { "Sistema", "Atleta", "Representante", "Atleta(Menor)" });
                foreach (String rol in rolesPermitidos)
                {
                    if (rol == rolUsuario)
                        permitido = true;
                }
                if (permitido)
                {
                    if (!IsPostBack)
                    {
                        try
                        {

 


                            //laLista = logEvento.obtenerListaDeCintas(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                            /*if (laLista != null)
                            {
                                foreach (Cinta cinta in laLista)
                                {
                                    fechaInscripcion = logEvento.obtenerFechaCinta(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()), cinta.Id_cinta);
                                    this.laTabla.Text += M7_Recursos.AbrirTR;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + cinta.Color_nombre.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + cinta.Rango.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + cinta.Clasificacion.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD;
                                    this.laTabla.Text += M7_Recursos.BotonInfoCintas + cinta.Id_cinta + M7_Recursos.BotonCerrar;
                                    this.laTabla.Text += M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.CerrarTR;
                                }
                            }
                            else
                            {
                                throw new ListaNulaException(M7_Recursos.Codigo_Lista_Nula,
                                M7_Recursos.Mensaje_Numero_Parametro_invalido, new Exception());
                            }*/

                        }
                        catch (ListaNulaException)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M7_Recursos.MensajeListaNulaLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                        catch (NumeroEnteroInvalidoException)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M7_Recursos.Mensaje_Numero_Parametro_invalido, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                        catch (Exception ex)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            #endregion
        }
    }

        #endregion
}