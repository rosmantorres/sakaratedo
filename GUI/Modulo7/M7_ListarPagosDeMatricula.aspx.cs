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
    public partial class M7_ListarPagosDeMatricula : System.Web.UI.Page
    {
        #region Atributos
        private List<Matricula> laLista = new List<Matricula>();
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

            #region Llenar Data Table con Matriculas
            LogicaMatriculasPagas logMatricula = new LogicaMatriculasPagas();

            if (!IsPostBack)
            {
                try
                {
                    laLista = logMatricula.obtenerListaDeMatriculas();

                    foreach (Matricula matricula in laLista)
                    {
                        this.laTabla.Text += M7_Recursos.AbrirTR;
                        this.laTabla.Text += M7_Recursos.AbrirTD + matricula.ID.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + matricula.FechaCreacion.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD + matricula.UltimaFechaPago.ToString() + M7_Recursos.CerrarTD;
                        this.laTabla.Text += M7_Recursos.AbrirTD;
                        this.laTabla.Text += M7_Recursos.BotonInfoPagosDeMatricula + matricula.ID + M7_Recursos.BotonCerrar;
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
        /// Método que llena el modal con la información de matricula
        /// </summary>
        /// <param name="idEvento">Número entero que representa el ID de la matricula</param>
        protected void llenarModalInfo(int idMatricula)
        {
            Matricula matricula = new Matricula();
            LogicaMatriculasPagas logica = new LogicaMatriculasPagas();
            matricula = logica.detalleMatriculaID(idMatricula);
        }

    }
            #endregion




        #endregion

}