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
using DominioSKD.Entidades.Modulo6;


namespace templateApp.GUI.Modulo7
{   /// <summary>
    /// Clase que maneja la interfaz de listar matriculas pagas
    /// </summary>
    public partial class M7_ListarPagosDeMatricula : System.Web.UI.Page, IContratoListarMatriculasPagas
    {
        #region Atributos
        private List<Matricula> laLista = new List<Matricula>();
        private PresentadorListarMatriculasPagas presentador;

        string IContratoListarMatriculasPagas.laTabla
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

        public M7_ListarPagosDeMatricula()
        {
            presentador = new PresentadorListarMatriculasPagas(this);
        }
    
        #region Page Load
        /// <summary>
        /// Método que se ejecuta al cargar la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
     
            String detalleString = Request.QueryString["eventDetalle"];

            #region Llenar Data Table con Matriculas
            LogicaMatriculasPagas logMatricula = new LogicaMatriculasPagas();

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
                            presentador.ConsultarListaMatriculasPagas();
                            /*laLista = logMatricula.obtenerListaDeMatriculas(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                            if (laLista != null)
                            {
                                foreach (Matricula matricula in laLista)
                                {
                                    String estadoFinal;
                                    id = logMatricula.obtenerIdMatricula(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                                    monto = logMatricula.obtenerMontoMatricula(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()), id);
                                    estado = logMatricula.obtenerEstado(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                                    if (estado == true)
                                    {
                                        estadoFinal = "Activa";
                                    }
                                    else
                                    {
                                        estadoFinal = "No Activa";
                                    }
                                    this.laTabla.Text += M7_Recursos.AbrirTR;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + matricula.Identificador.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + estadoFinal + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + matricula.FechaCreacion.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + matricula.UltimaFechaPago.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD + monto.ToString() + M7_Recursos.CerrarTD;
                                    this.laTabla.Text += M7_Recursos.AbrirTD;
                                    this.laTabla.Text += M7_Recursos.BotonInfoPagosDeMatricula + matricula.Id + M7_Recursos.BotonCerrar;
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
        }
    }
            #endregion
        #endregion
}