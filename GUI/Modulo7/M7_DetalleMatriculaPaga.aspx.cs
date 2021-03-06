﻿using System;
using System.Collections.Generic;
using System.Web.UI;
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
    /// Clase que maneja la interfaz de detallar matriculas pagas
    /// </summary>
    public partial class M7_DetalleMatriculaPaga : System.Web.UI.Page, IContratoDetallarMatricula
        
    {
        private MatriculaM7 idMatricula;
        private PersonaM7 idPersona;
        private PresentadorDetallarMatricula presentador;
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public M7_DetalleMatriculaPaga()
        {
            presentador = new PresentadorDetallarMatricula(this);
        }


        #region Contrato
        /// <summary>
        /// Implementacion contrato identificadorMatricula
        /// </summary>
        string IContratoDetallarMatricula.identificadorMatricula
        {
            get
            {
                return identificador1.InnerText;
            }

            set
            {
                identificador1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato colorCinta
        /// </summary>
        string IContratoDetallarMatricula.fechaCreacionMatricula
        {
            get
            {
                return fecha_creacion1.InnerText;
            }

            set
            {
                fecha_creacion1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato colorCinta
        /// </summary>
        string IContratoDetallarMatricula.fechaPagoMatricula

        {
            get
            {
                return fecha_pago1.InnerText;
            }

            set
            {
                fecha_pago1.InnerText += value;
            }
        }

        /// <summary>
        /// Implementacion contrato colorCinta
        /// </summary>
        string IContratoDetallarMatricula.estadoMatricula
        {
            get
            {
                return estado_matricula1.InnerText;
            }

            set
            {
                estado_matricula1.InnerText += value;
            }
        }

        
        #endregion
      
        /// <summary>
        /// Método que se ejecuta al cargar la página Listar Matriculas pagas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M7_Recursos.NumeroModulo;
            String detalleStringMatricula = Request.QueryString[M7_Recursos.MatriculaDetalle];

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
                            idMatricula = (MatriculaM7)FabricaEntidades.ObtenerMatriculaM7();
                            idPersona = (PersonaM7)FabricaEntidades.ObtenerPersonaM7();
                            idPersona.Id = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());               
                            idMatricula.Id = int.Parse(detalleStringMatricula);
                            presentador.CargarDatos(idMatricula,idPersona);
                           
                            
                          
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
   

