using System;
using System.Collections.Generic;
using System.Web.UI;
using templateApp.GUI.Master;
using ExcepcionesSKD;
using Interfaz_Presentadores.Modulo7;
using Interfaz_Contratos.Modulo7;
using DominioSKD.Fabrica;
using DominioSKD.Entidades.Modulo7;



namespace templateApp.GUI.Modulo7
{
    /// <summary>
    /// Clase que maneja la interfaz de perfil de persona
    /// </summary>
    public partial class M7_ListarOrganizacionYDojo : System.Web.UI.Page, IContratoConsultarPerfil
    {
        private PresentadorConsultarPerfil presentador;
        private PersonaM7 idPersona;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public M7_ListarOrganizacionYDojo()
        {
            presentador = new PresentadorConsultarPerfil(this);
        }

        #region Contrato
        /// <summary>
        /// Implementacion contrato nombrePersona
        /// </summary>
        public string nombrePersona
        {
            get
            {
                return nombrePersona1.InnerText;
            }

            set
            {
                nombrePersona1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato apellidoPersona
        /// </summary>
        string IContratoConsultarPerfil.apellidoPersona
        {
            get
            {
                return apellidoPersona1.InnerText;
            }

            set
            {
                apellidoPersona1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato fechaNacimiento
        /// </summary>
        string IContratoConsultarPerfil.fechaNacimiento
        {
            get
            {
                return fechaNacimiento1.InnerText;
            }

            set
            {
                fechaNacimiento1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato direccion
        /// </summary>
        string IContratoConsultarPerfil.direccion
        {
            get
            {
                return direccion1.InnerText;
            }

            set
            {
                direccion1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato nombreDojo
        /// </summary>
        string IContratoConsultarPerfil.nombreDojo
        {
            get
            {
                return nombreDojo1.InnerText;
            }

            set
            {
                nombreDojo1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato telefonoDojo
        /// </summary>
        string IContratoConsultarPerfil.telefonoDojo
        {
            get
            {
                return telefonoDojo1.InnerText;
            }

            set
            {
                telefonoDojo1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato emailDojo
        /// </summary>
        string IContratoConsultarPerfil.emailDojo
        {
            get
            {
                return emailDojo1.InnerText;
            }

            set
            {
                emailDojo1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato ubicacionDojo
        /// </summary>
        string IContratoConsultarPerfil.ubicacionDojo
        {
            get
            {
                return ubicacionDojo1.InnerText;
            }

            set
            {
                ubicacionDojo1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato nombreOrganizacion
        /// </summary>
        string IContratoConsultarPerfil.nombreOrganizacion
        {
            get
            {
                return nombreOrganizacion1.InnerText;
            }

            set
            {
                nombreOrganizacion1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato emailOrganizacion
        /// </summary>
        string IContratoConsultarPerfil.emailOrganizacion
        {
            get
            {
                return emailOrganizacion1.InnerText;
            }

            set
            {
                emailOrganizacion1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato ubicacionOrganizacion
        /// </summary>
        string IContratoConsultarPerfil.ubicacionOrganizacion
        {
            get
            {
                return ubicacionOrganizacion1.InnerText;
            }

            set
            {
                ubicacionOrganizacion1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato cintaActual
        /// </summary>
        string IContratoConsultarPerfil.cintaActual
        {
            get
            {
                return cintaActual1.InnerText;
            }

            set
            {
                cintaActual1.InnerText += value;
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
                    try {
                        idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                        idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());
                        presentador.cargarDatos(idPersona);
                    }
                    catch (Exception ex)
                    {
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
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