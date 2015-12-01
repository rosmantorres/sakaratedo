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
            DateTime fechaPago;
            float monto;
            int idEvento;

            String detalleString = Request.QueryString["eventDetalle"];

            if (detalleString != null)
            {
                //llenarModalInfo(int.Parse(detalleString));
            }

            #region Llenar Data Table con Eventos
            LogicaEventosPagos logEvento = new LogicaEventosPagos();


            if (!IsPostBack)
            {
                try
                {
                    laLista = logEvento.obtenerListaDeEventos(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                    laListaCompetencias = logEvento.obtenerListaDeCompetencias(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));

                    foreach (Evento evento in laLista)
                    {
                    
                        monto = logEvento.obtenerMontoEvento(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()), evento.Id_evento);
                        fechaPago = logEvento.obtenerFechaPagoEvento(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()), evento.Id_evento);
                        this.laTabla.Text += M7_Recursos.AbrirTR;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.Nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + evento.TipoEvento.Nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + fechaPago.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + monto.ToString()+ M7_Recursos.CerrarTD;
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
                        this.laTabla.Text += M7_Recursos.AbrirTD + "MM/dd/yyyy" + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Costo.ToString() + M7_Recursos.CerrarTD;
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
