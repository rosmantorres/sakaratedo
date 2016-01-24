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
using DominioSKD.Fabrica;



namespace templateApp.GUI.Modulo7
{
    /// <summary>
    /// Clase que maneja la interfaz de asistencia a eventos
    /// </summary>
    public partial class M7_ListarAsistenciaAEventos : System.Web.UI.Page, IContratoListarEventosAsistidos
    {
        #region Atributos
        private PresentadorListarEventosAsistidos presentador;
        private FabricaEntidades fabricaEntidades;
        private Persona idPersona;

        /// <summary>
        /// Implementacion de contrato laTabla
        /// </summary>
        string IContratoListarEventosAsistidos.laTabla
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

        private List<Evento> laListaEventos;
        private List<DominioSKD.Competencia> laListaCompetencias;
        #endregion

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public M7_ListarAsistenciaAEventos()
        {
            presentador = new PresentadorListarEventosAsistidos(this);
        }

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

            #region Llenar Data Table con Eventos
            try
            {
                String rolUsuario = Session[RecursosInterfazMaster.sessionRol].ToString();
                Boolean permitido = false;
                List<String> rolesPermitidos = new List<string>
                    (new string[] { M7_Recursos.RolSistema, M7_Recursos.RolAtleta, M7_Recursos.RolRepresentante, M7_Recursos.RolAtletaMenor });
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
                            fabricaEntidades = new FabricaEntidades();
                            idPersona = new Persona();//cambiar por fabrica
                            idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                            presentador.ConsultarEventosAsistidos(idPersona);
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
