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
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Presentadores.Modulo7;
using Interfaz_Contratos.Modulo7;
using DominioSKD.Entidades.Modulo7;
using DominioSKD.Fabrica;




namespace templateApp.GUI.Modulo7
{

    /// <summary>
    /// Clase que maneja la interfaz de detallar eventos pagos
    /// </summary>
    public partial class M7_DetalleEventoPago : System.Web.UI.Page, IContratoDetallarEvento
    {

        private EventoM7 idEvento;
        private PresentadorDetallarEvento presentador;
        private PersonaM7 idPersona;
          /// <summary>
        /// Constructor de la clase
        /// </summary>
        public M7_DetalleEventoPago()
        {
            presentador = new PresentadorDetallarEvento(this);
        }

        #region Contrato
        /// <summary>
        /// Implementacion contrato ciudad_evento
        /// </summary>
        public string ciudad_evento
        {
            get
            {
                return ciudad_evento1.InnerText;
            }

            set
            {
                ciudad_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato direccionEvento_evento
        /// </summary>
        public string direccionEvento_evento
        {
            get
            {
                return direccion_evento1.InnerText;
            }

            set
            {
                direccion_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato costo_evento
        /// </summary>
        public string costo_evento
        {
            get
            {
                return costo_evento1.InnerText;
            }

            set
            {
                costo_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato descripcion_evento
        /// </summary>
        public string descripcion_evento
        {
            get
            {
                return descripcion_evento1.InnerText;
            }

            set
            {
                descripcion_evento1.InnerText += value;
            }
        }

       

        /// <summary>
        /// Implementacion contrato estadoUbicacion_evento
        /// </summary>
        public string estadoUbicacion_evento
        {
            get
            {
                return estadoUbicacion_evento1.InnerText;
            }

            set
            {
                estadoUbicacion_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato estado_evento
        /// </summary>
        public string estado_evento
        {
            get
            {
                return estado_evento1.InnerText;
            }

            set
            {
                estado_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato fechaFin_evento1_evento
        /// </summary>
        public string fechaFin_evento
        {
            get
            {
                return fechaFin_evento1.InnerText;
            }

            set
            {
                fechaFin_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato fechaInicio_evento
        /// </summary>
        public string fechaInicio_evento
        {
            get
            {
                return fechaInicio_evento1.InnerText;
            }

            set
            {
                fechaInicio_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato horaFin_evento
        /// </summary>
        public string horaFin_evento
        {
            get
            {
                return horaFin_evento1.InnerText;
            }

            set
            {
                horaFin_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato horaInicio_evento
        /// </summary>
        public string horaInicio_evento
        {
            get
            {
                return horaInicio_evento1.InnerText;
            }

            set
            {
                horaInicio_evento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato nombre_evento
        /// </summary>
        public string nombre_evento
        {
            get
            {
                return nombre_evento1.InnerText;
            }

            set
            {
                nombre_evento1.InnerText += value;
            }
        }
        #endregion

         /// <summary>
        /// Método que se ejecuta al cargar la página Listar Eventos pagos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
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

                            idEvento = (EventoM7)FabricaEntidades.ObtenerEventoM7();
                            idEvento.Id = int.Parse(detalleStringEvento);
                            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                            idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                            presentador.CargarDatos(idEvento);

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