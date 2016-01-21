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



namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarAsistenciaAEventos : System.Web.UI.Page
    {
        #region Atributos
        private List<Evento> laListaEventos;
        private List<DominioSKD.Competencia> laListaCompetencias;
        #endregion

        #region Page Load
        /// <summary>
        /// Método que se ejecuta al cargar la página Asistencia a Eventos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";

            String detalleString = Request.QueryString["impDetalle"];
            DateTime fechaInscripcion;

            #region Llenar Data Table con Eventos
            LogicaEventosAsistidos logEvento = new LogicaEventosAsistidos();


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
                            laListaEventos = logEvento.obtenerListaDeEventos(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                            laListaCompetencias = logEvento.obtenerListaDeCompetencias(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                            if (laListaEventos != null && laListaCompetencias != null)
                            {
                                foreach (Evento evento in laListaEventos)
                                {
                                    fechaInscripcion = logEvento.obtenerFechaInscripcion(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()), evento.Id_evento);
                                    this.laTabla.Text += M7_Recursos.AbrirTR;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + evento.Nombre.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + evento.TipoEvento.Nombre.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + evento.Ubicacion.Estado.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD;
                                    this.laTabla.Text += M7_Recursos.BotonInfoAsistenciaAEventos + evento.Id_evento + M7_Recursos.BotonCerrar;
                                    this.laTabla.Text += M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.CerrarTR;
                                }

                                foreach (Competencia competencia in laListaCompetencias)
                                {
                                    fechaInscripcion = logEvento.obtenerFechaInscripcion(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()), competencia.Id_competencia);
                                    this.laTabla.Text += M7_Recursos.AbrirTR;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Nombre.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + competencia.TipoCompetencia.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Ubicacion.Estado.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD;
                                    this.laTabla.Text += M7_Recursos.BotonInfoAsistenciaACompetencias + competencia.Id_competencia + M7_Recursos.BotonCerrar;
                                    this.laTabla.Text += M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.CerrarTR;
                                }
                            }
                            else
                            {
                                throw new ListaNulaException(M7_Recursos.Codigo_Lista_Nula,
                                M7_Recursos.Mensaje_Numero_Parametro_invalido, new Exception());
                            }

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
        }
                
    }
    #endregion

    #endregion

}
