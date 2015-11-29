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
    public partial class M7_ListarCintas : System.Web.UI.Page
    {
        #region Atributos
        private List<Cinta> laLista = new List<Cinta>();
        #endregion

        #region Page_Load
        /// <summary>
        /// Método que se ejecuta al cargar la página Listar Cintas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "7";

            String detalleString = Request.QueryString["compDetalle"];
            DateTime fechaInscripcion;

            if (detalleString != null)
            {
                llenarModalInfo(int.Parse(detalleString));
            }

            #region Llenar DataTable con Cintas

            LogicaCintas logEvento = new LogicaCintas();

            if (!IsPostBack)
            {
                try
                {
                    laLista = logEvento.obtenerListaDeCintas();

                    foreach (Cinta cinta in laLista)
                    {
                        fechaInscripcion = logEvento.obtenerFechaCinta(1, cinta.Id_cinta);
                        this.laTabla.Text += M7_Recursos.AbrirTR;
                        this.laTabla.Text += M7_Recursos.AbrirTD + cinta.Color_nombre.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + cinta.Rango.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + cinta.Clasificacion.ToString()+ M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + fechaInscripcion.ToString("MM/dd/yyyy") + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD;
                        this.laTabla.Text += M7_Recursos.BotonInfoAsistenciaAEventos + cinta.Id_cinta + M7_Recursos.BotonCerrar;
                        this.laTabla.Text += M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.CerrarTR;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            #endregion
        }

        /// <summary>
        /// Método que llena el modal con la información de la cinta
        /// </summary>
        /// <param name="idCinta">Número entero que representa el id de la cinta</param>
        protected void llenarModalInfo(int idCinta)
        {
            /*Evento evento = new Evento();
            LogicaEventosAsistidos logica = new LogicaEventosAsistidos();
            evento = logica.detalleEventoID(idEvento);*/
        }
    }

        #endregion
}