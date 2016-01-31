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
{   /// <summary>
    /// Clase que maneja la interfaz de listar matriculas pagas
    /// </summary>
    public partial class M7_ListarPagosDeMatricula : System.Web.UI.Page, IContratoListarMatriculasPagas
    {
        #region Atributos
        private PresentadorListarMatriculasPagas presentador;
        private PersonaM7 idPersona;
        #endregion
        #region Contrato
        /// <summary>
        /// Implementacion de contrato laTabla
        /// </summary>
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

                            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                            idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                            presentador.ConsultarListaMatriculasPagas(idPersona);

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