﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo7;


namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarAsistenciaAEventos : System.Web.UI.Page
    {
        #region Atributos
        private List<DominioSKD.Evento> laListaEventos;
        private List<DominioSKD.Competencia> laListaCompetencias;
        #endregion

        #region Page Load
        /// <summary>
        /// Método que se ejecuta al cargar la página Asistencia a Eventos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";

            String detalleString = Request.QueryString["impDetalle"];

            if (detalleString != null)
            {
                //llenarModalInfo(int.Parse(detalleString));
                //llenarModalInfo1(1);
            }

            #region Llenar Data Table con Eventos
            LogicaEventosAsistidos logEvento = new LogicaEventosAsistidos();

            if (!IsPostBack)
            {
                try
                {
                    laListaEventos = logEvento.obtenerListaDeEventos();
                    laListaCompetencias = logEvento.obtenerListaDeCompetencias();
                    
                    foreach (Evento evento in laListaEventos)
                    {
                        this.laTabla.Text += M7_Recursos.AbrirTR;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.Id_evento.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.Nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.TipoEvento.Nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.Horario.FechaInicio.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.Ubicacion.Estado.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD;
                        this.laTabla.Text += M7_Recursos.BotonInfoAsistenciaAEventos + evento.Id_evento + M7_Recursos.BotonCerrar;
                        this.laTabla.Text += M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.CerrarTR;
                    }

                    foreach (Competencia competencia in laListaCompetencias)
                    {
                        this.laTabla.Text += M7_Recursos.AbrirTR;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Id_competencia.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.TipoCompetencia.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.FechaInicio.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Ubicacion.Estado.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD;
                        this.laTabla.Text += M7_Recursos.BotonInfoAsistenciaAEventos + competencia.Id_competencia + M7_Recursos.BotonCerrar;
                        this.laTabla.Text += M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.CerrarTR;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        
            /// <summary>
            /// Método que llena el modal con la información del evento
            /// </summary>
            /// <param name="idEvento">Número entero que representa el ID del evento</param>
            protected void llenarModalInfo(int idEvento)
            {
                /*Evento evento = new Evento();
                LogicaEventosAsistidos logica = new LogicaEventosAsistidos();
                evento = logica.detalleEventoID(idEvento);*/
                //this.elModal.Text += M7_Recursos.AbrirTD + "hola" + M7_Recursos.CerrarTD;

        }

        [System.Web.Services.WebMethod]
        public static string prueba(int idEvento)
        {
            Ubicacion evento;
            LogicaEventosAsistidos logica = new LogicaEventosAsistidos();
            evento = logica.obtenerUbicacion(1);
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(evento);
            return json;
        }

        #region Llenado del Modal de Informacion del producto
        [System.Web.Services.WebMethod]
        public static string prueba(string id)
        {
            Ubicacion laCompetencia = new Ubicacion();
            LogicaEventosAsistidos logica = new LogicaEventosAsistidos();
            laCompetencia = logica.obtenerUbicacion(int.Parse(id));
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(laCompetencia);
            return json;
        }
        #endregion

    }
    #endregion




#endregion

}
