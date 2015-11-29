using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo7
{
    public partial class M7_ListarOrganizacionYDojo : System.Web.UI.Page
    {
        #region Atributos
        private List<DominioSKD.Organizacion> laOrganizacion;
        private List<DominioSKD.Dojo> elDojo;
        private List<DominioSKD.Persona> laPersona;
        #endregion

        /// <summary>
        /// Metodo que se ejecuta al cargar la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            /* ((SKD)Page.Master).IdModulo = "7";

             #region Llenar Data Table con Eventos

             if (!IsPostBack)
             {
                 try
                 {
                     laLista = logEvento.obtenerListaDeEventos();

                     foreach (Evento evento in laLista)
                     {
                         this.laTabla.Text += M7_Recursos.AbrirTR;
                         this.laTabla.Text += M7_Recursos.AbrirTD + evento.Nombre.ToString() + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD + evento.TipoEvento.Nombre.ToString() + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD + evento.Horario.FechaInicio.ToString("dd/MM/yyyy") + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD + evento.Ubicacion.Ciudad.ToString() + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD;
                         this.laTabla.Text += M7_Recursos.BotonInfoEventosInscritos + evento.Id_evento + M7_Recursos.BotonCerrar;
                         this.laTabla.Text += M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.CerrarTR;
                     }

                     foreach (Competencia competencia in laListaCompetencias)
                     {
                         this.laTabla.Text += M7_Recursos.AbrirTR;
                         this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Nombre.ToString() + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD + competencia.TipoCompetencia.ToString() + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD + competencia.FechaInicio.ToString("dd/MM/yyyy") + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD + competencia.Ubicacion.Ciudad.ToString() + M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.AbrirTD;
                         this.laTabla.Text += M7_Recursos.BotonInfoEventosInscritos + competencia.Id_competencia + M7_Recursos.BotonCerrar;
                         this.laTabla.Text += M7_Recursos.CerrarTD;
                         this.laTabla.Text += M7_Recursos.CerrarTR;
                     }

                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
             }
         }*/
//#endregion

        }
        
    }
}