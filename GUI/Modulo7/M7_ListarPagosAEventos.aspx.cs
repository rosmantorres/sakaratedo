using System;
using System.Collections.Generic;
using System.Web.UI;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo7;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo7;
using Interfaz_Presentadores.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo7;




namespace templateApp.GUI.Modulo7
{
    /// <summary>
    /// Clase que maneja la interfaz de listar eventos pagos
    /// </summary>
    public partial class M7_ListarPagosAEventos : System.Web.UI.Page, IContratoListarEventosPagos
    {
        #region Atributos

        private PresentadorListarEventosPagos presentador;
        private FabricaEntidades fabricaEntidades;
        private PersonaM7 idPersona;

        string IContratoListarEventosPagos.laTabla
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
         public M7_ListarPagosAEventos()
        {
            presentador = new PresentadorListarEventosPagos(this);
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

            #region Llenar Data Table con Eventos

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
                    if (!IsPostBack)
                    {
                        try
                        {

                              fabricaEntidades = new FabricaEntidades();
                              idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                              idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                              presentador.ConsultarListaEventosPagos(idPersona);
                          
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
