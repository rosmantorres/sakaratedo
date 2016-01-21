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
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetalleCinta : System.Web.UI.Page
    {
        Cinta cinta = new Cinta();
        LogicaCintas laLogica = new LogicaCintas();

        /// <summary>
        /// Método que se ejecuta al cargar la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleString = Request.QueryString["cintaDetalle"];

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
                    if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                    {
                        try
                        {
                            cinta = laLogica.detalleCintaID(int.Parse(detalleString));
                            if (cinta != null)
                            {
                                this.colorCinta.Text = cinta.Color_nombre;
                                this.rangoCinta.Text = cinta.Rango;
                                this.clasificacionCinta.Text = cinta.Clasificacion;
                                this.significadoCinta.Text = cinta.Significado;
                                this.ordenCinta.Text = cinta.Orden.ToString();
                                this.fechaObtencionCinta.Text = laLogica.obtenerFechaCinta(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()),
                                                                                            int.Parse(detalleString)).ToString("MM/dd/yyyy");
                            }
                            else
                            {
                                throw new ObjetoNuloException(M7_Recursos.Codigo_Numero_Parametro_Invalido,
                                M7_Recursos.MensajeObjetoNuloLogger, new Exception());
                            }
                        }
                        catch (ObjetoNuloException)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M7_Recursos.MensajeObjetoNuloLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
        }
    }
}