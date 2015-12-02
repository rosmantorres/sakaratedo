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

namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetalleEventoAsistido : System.Web.UI.Page
    {
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
        LogicaEventosAsistidos laLogica = new LogicaEventosAsistidos();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleStringEvento = Request.QueryString["eventoDetalle"];
            String detalleStringCompetencia = Request.QueryString["compDetalle1"];

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
                    if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                    {
                        try
                        {
                            evento = laLogica.detalleEventoID(int.Parse(detalleStringEvento));
                            if (evento != null)
                            {
                                evento = laLogica.detalleEventoID(int.Parse(detalleStringEvento));
                                this.nombre_evento.Text = evento.Nombre;
                                this.descripcion_evento.Text = evento.Descripcion.ToString();
                                this.costo_evento.Text = evento.Costo.ToString();
                                if (evento.Estado.Equals(true))
                                {
                                    this.estado_evento.Text = M7_Recursos.AliasEventoActivo;
                                }
                                else if (evento.Estado.Equals(false))
                                {
                                    this.estado_evento.Text = M7_Recursos.AliasEventoInactivo;
                                }
                                this.horaInicio_evento.Text = evento.Horario.HoraInicio.ToString();
                                this.horaFin_evento.Text = evento.Horario.HoraFin.ToString();
                                this.fechaInicio_evento.Text = evento.Horario.FechaInicio.ToString("MM/dd/yyyy");
                                this.fechaFin_evento.Text = evento.Horario.FechaFin.ToString("MM/dd/yyyy");
                                this.estadoUbicacion_evento.Text = evento.Ubicacion.Estado.ToString();
                                this.ciudad_evento.Text = evento.Ubicacion.Ciudad.ToString();
                                this.direccion_evento.Text = evento.Ubicacion.Direccion;
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