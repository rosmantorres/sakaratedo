using System;
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
    public partial class M7_ListarPagosAEventos : System.Web.UI.Page
    { 
        #region Atributos
        private List<DominioSKD.Evento> laLista;
        private List<DominioSKD.Competencia> laListaCompetencias;
        #endregion
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

            if (detalleString != null)
            {
                llenarModalInfo(int.Parse(detalleString));
            }

            #region Llenar Data Table con Eventos
            LogicaEventosPagos logEvento = new LogicaEventosPagos();
             LogicaEventosInscritos logEvento2 = new LogicaEventosInscritos();
             laListaCompetencias = logEvento2.obtenerListaDeCompetencias();
            if (!IsPostBack)
            {
                try
                {
                    laLista = logEvento.obtenerListaDeEventos();
                    

                    foreach (Evento evento in laLista)
                    {
                        this.laTabla.Text += M7_Recursos.AbrirTR;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.Id_evento.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.Nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.TipoEvento.ToString() + M7_Recursos.CerrarTD;
                      //  this.laTabla.Text += M7_Recursos.AbrirTD + evento.fecha.ToString() + M7_Recursos.CerrarTD;
                      //this.laTabla.Text += M7_Recursos.AbrirTD + evento.monto.ToString() + M7_Recursos.CerrarTD;   
                        this.laTabla.Text += M7_Recursos.AbrirTD;
                        this.laTabla.Text += M7_Recursos.BotonInfoPagosAEventos + evento.Id_evento + M7_Recursos.BotonCerrar;
                        this.laTabla.Text += M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.CerrarTR;
                    }

                    foreach (Competencia competencia in laListaCompetencias)
                    {
                        this.laTabla.Text += M7_Recursos.AbrirTR;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.TipoCompetencia.ToString() + M7_Recursos.CerrarTD;
                        //this.laTabla.Text += M7_Recursos.AbrirTD + competencia.fecha.ToString() + M7_Recursos.CerrarTD;
                        //this.laTabla.Text += M7_Recursos.AbrirTD + competencia.monto.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD;
                        this.laTabla.Text += M7_Recursos.BotonInfoPagosAEventos + competencia.Id_competencia + M7_Recursos.BotonCerrar;
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
                LogicaEventosPagos logica = new LogicaEventosPagos();
                evento = logica.detalleEventoID(idEvento);*/
            }

        }
            #endregion
            
            

        
        #endregion
        
}
