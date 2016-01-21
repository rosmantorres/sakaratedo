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
using templateApp.GUI.Master;
using DominioSKD.Entidades.Modulo6;


namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetalleMatriculaPaga : System.Web.UI.Page
    {
        Matricula matricula = new Matricula();
        LogicaMatriculasPagas Logica = new LogicaMatriculasPagas();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleStringMatricula = Request.QueryString["matriculaDetalle"];

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
                            matricula = Logica.detalleMatriculaID(int.Parse(detalleStringMatricula));
                            if (matricula != null)
                            {
                                this.identificador.Text = matricula.Identificador.ToString();
                                this.fecha_creacion.Text = matricula.FechaCreacion.ToString("MM/dd/yyyy");
                                this.fecha_pago.Text = matricula.UltimaFechaPago.ToString("MM/dd/yyyy");
                                bool estado = Logica.obtenerEstado(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));

                                if (estado)
                                    this.estado_matricula.Text = "Activa";
                                else if (!estado)
                                    this.estado_matricula.Text = "Inactiva";
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
   

