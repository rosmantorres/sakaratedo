using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using Interfaz_Presentadores.Modulo7;
using System;
using System.Collections.Generic;
using System.Web.UI;
using templateApp.GUI.Master;



namespace templateApp.GUI.Modulo7
{
    /// <summary>
    /// Clase que maneja la interfaz de inscripción a eventos
    /// </summary>
    public partial class M7_ListarEventosInscritos : System.Web.UI.Page, IContratoListarEventosInscritos
    {
         #region Atributos
        private PresentadorListarEventosInscritos presentador;
        private FabricaEntidades fabricaEntidades;
        private Persona idPersona;

        /// <summary>
        /// Implementacion de contrato laTabla
        /// </summary>
        string IContratoListarEventosInscritos.laTabla
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

        private List<Evento> laLista;
        private List<DominioSKD.Competencia> laListaCompetencias;

        #endregion
        #region Page Load
        /// <summary>
        /// Método que se ejecuta al cargar la página eventos inscritos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M7_Recursos.Modulo;
            String detalleString = Request.QueryString[M7_Recursos.DetalleStringEventoInscrito];

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
                            presentador.ConsultarEventosInscritos(idPersona);
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
