﻿using System;
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
    // <summary>
    /// Clase que maneja la interfaz de detallar competencia paga
    /// </summary>
    public partial class M7_DetalleCompetenciaPaga : System.Web.UI.Page, IContratoDetallarCompetencia
    {
        private Competencia idCompetencia;
        private PresentadorDetallarCompetencia presentador;

         /// <summary>
        /// Constructor de la clase
        /// </summary>
        public M7_DetalleCompetenciaPaga()
        {
            presentador = new PresentadorDetallarCompetencia(this);
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
        /// Implementacion contrato direccion_evento
        /// </summary>
        public string direccion_evento
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
        /// Implementacion contrato fechaFin_evento
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

        /// <summary>
        /// Implementacion contrato tipo_evento
        /// </summary>
        public string tipo_evento
        {
            get
            {
                return tipo_evento1.InnerText;
            }

            set
            {
                tipo_evento1.InnerText += value;
            }
        }
        #endregion
        /// <summary>
        /// Método que se ejecuta al cargar la página Listar Competencias pagas
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
                    (new string[] { "Sistema", "Atleta", "Representante", "Atleta(Menor)" });
                foreach (String rol in rolesPermitidos)
                {
                    if (rol == rolUsuario)
                        permitido = true;
                }
                if (permitido)
                {
                    ((SKD)Page.Master).IdModulo = "7";
                    String detalleStringCompetencia = Request.QueryString["compDetalle"];

                    if (!IsPostBack) // verificar si la pagina se muestra por primera vez
                    {
                        try
                        {
                            idCompetencia = new Competencia();//cambiar por fabrica
                            idCompetencia.Id = int.Parse(detalleStringCompetencia);
                            presentador.cargarDatos(idCompetencia);
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