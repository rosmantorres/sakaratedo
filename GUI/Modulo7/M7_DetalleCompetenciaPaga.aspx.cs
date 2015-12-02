using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo7;
using ExcepcionesSKD.Modulo7;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetalleCompetenciaPaga : System.Web.UI.Page
    {
        Competencia competencia = new Competencia();
        LogicaEventosPagos laLogica = new LogicaEventosPagos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String rolUsuario = Session[GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
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
                    ((SKD)Page.Master).IdModulo = "7";
                    String detalleStringCompetencia = Request.QueryString["compDetalle"];

                    if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                    {
                        try
                        {
                            competencia = laLogica.detalleCompetenciaPagaID(int.Parse(detalleStringCompetencia));
                            if (competencia != null)
                            {
                                this.nombre_evento.Text = competencia.Nombre;
                                this.costo_evento.Text = competencia.Costo.ToString();
                                this.tipo_evento.Text = M7_Recursos.AliasTipoEventoCompetencia;
                                this.fechaInicio_evento.Text = competencia.FechaInicio.ToString("MM/dd/yyyy");
                                this.fechaFin_evento.Text = competencia.FechaFin.ToString("MM/dd/yyyy");
                                this.estadoUbicacion_evento.Text = competencia.Ubicacion.Estado.ToString();
                                this.ciudad_evento.Text = competencia.Ubicacion.Ciudad.ToString();
                                this.direccion_evento.Text = competencia.Ubicacion.Direccion;
                            }
                            else
                            {
                                throw new ObjetoNuloException(M7_Recursos.Codigo_Numero_Parametro_Invalido,
                                M7_Recursos.MensajeObjetoNuloLogger, new Exception());
                            }
                        }
                        catch (ObjetoNuloException ex)
                        {
                            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M7_Recursos.MensajeObjetoNuloLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        }
                        catch (NumeroEnteroInvalidoException ex)
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
                    Response.Redirect(GUI.Master.RecursosInterfazMaster.direccionMaster_Inicio);
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