using DominioSKD;
using DominioSKD.Entidades.Modulo7;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using Interfaz_Presentadores.Modulo7;
using LogicaNegociosSKD.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;



namespace templateApp.GUI.Modulo7
{
    /// <summary>
    /// Clase que maneja la interfaz de horario de pracica
    /// </summary>
    public partial class M7_ListarHorariodePractica : System.Web.UI.Page, IContratoListarHorarioPractica
    {
        #region Atributos
        private PresentadorListarHorarioPractica presentador;
        private FabricaEntidades fabricaEntidades;
        private PersonaM7 idPersona;

        /// <summary>
        /// Implementacion de contrato laTabla
        /// </summary>
        string IContratoListarHorarioPractica.laTabla
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
        public M7_ListarHorariodePractica ()
        {
            presentador = new PresentadorListarHorarioPractica(this);
        }
        #endregion

        #region Page Load
        /// <summary>
        /// Método que se ejecuta al cargar la página horario practica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
              ((SKD)Page.Master).IdModulo = M7_Recursos.Modulo;
              String detalleString = Request.QueryString[M7_Recursos.DetalleStringHorarioPractica];

           #region Llenar Data Table con Horarios
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
                            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                            idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                            presentador.ConsultarHorarioPractica(idPersona);
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