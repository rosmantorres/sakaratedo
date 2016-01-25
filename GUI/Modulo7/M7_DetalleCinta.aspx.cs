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
    /// Clase que maneja la interfaz de detallar cinta
    /// </summary>
    public partial class M7_DetalleCinta : System.Web.UI.Page, IContratoDetallarCinta
    {
        private CintaM7 idCinta;
        private PresentadorDetallarCinta presentador;
        private PersonaM7 idPersona;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public M7_DetalleCinta()
        {
            presentador = new PresentadorDetallarCinta(this);
        }

        #region Contratos
        /// <summary>
        /// Implementacion contrato clasificacionCinta
        /// </summary>
        string IContratoDetallarCinta.clasificacionCinta
        {
            get
            {
                return clasificacionCinta1.InnerText;
            }

            set
            {
                clasificacionCinta1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato colorCinta
        /// </summary>
        string IContratoDetallarCinta.colorCinta
        {
            get
            {
                return colorCinta1.InnerText;
            }

            set
            {
                colorCinta1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato fechaObtencionCinta
        /// </summary>
        string IContratoDetallarCinta.fechaObtencionCinta
        {
            get
            {
                return fechaObtencionCinta1.InnerText;
            }

            set
            {
                fechaObtencionCinta1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato ordenCinta
        /// </summary>
        string IContratoDetallarCinta.ordenCinta
        {
            get
            {
                return ordenCinta1.InnerText;
            }

            set
            {
                ordenCinta1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato rangoCinta
        /// </summary>
        string IContratoDetallarCinta.rangoCinta
        {
            get
            {
                return rangoCinta1.InnerText;
            }

            set
            {
                rangoCinta1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato significadoCinta
        /// </summary>
        string IContratoDetallarCinta.significadoCinta
        {
            get
            {
                return significadoCinta1.InnerText;
            }

            set
            {
                significadoCinta1.InnerText += value;
            }
        }

        #endregion

        /// <summary>
        /// Método que se ejecuta al cargar la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";
            String detalleStringCinta = Request.QueryString["cintaDetalle"];

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
                    if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                    {
                        try
                        {
                            idCinta = (CintaM7)FabricaEntidades.ObtenerCintaM7();
                            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                            idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                            idCinta.Id = int.Parse(detalleStringCinta);
                            presentador.CargarDatos(idCinta, idPersona);
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