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
using Interfaz_Presentadores.Modulo7;
using Interfaz_Contratos.Modulo7;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_DetalleEventoInscrito : System.Web.UI.Page, IContratoDetallarEvento
    {
        private Evento idEvento;
        private PresentadorDetallarEvento presentador;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public M7_DetalleEventoInscrito()
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
        /// Metodo que se ejecuta cuando se carga la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String rolUsuario = Session[GUI.Master.RecursosInterfazMaster.sessionRol].ToString();
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
            ((SKD)Page.Master).IdModulo = M7_Recursos.Modulo;
            String detalleStringEvento = Request.QueryString[M7_Recursos.DetalleStringDetalleEventoInscrito];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                try
                {
                            idEvento = new Evento();//cambiar por fabrica
                            idEvento.Id = int.Parse(detalleStringEvento);
                            presentador.cargarDatos(idEvento);
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
                    Response.Redirect(GUI.Master.RecursosInterfazMaster.direccionMaster_Inicio);
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