using DominioSKD;
using Interfaz_Contratos.Modulo10;
using Interfaz_Presentadores.Modulo10;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_DetalleAsistenciaEvento : System.Web.UI.Page, IContratoDetalleAsistencia
    {   
        PresentadorDetalleAsistencia presentador;
        public M10_DetalleAsistenciaEvento()
        {
            presentador = new PresentadorDetalleAsistencia(this);
        }

        #region Contrato
        public TextBox Fecha
        {
            get
            {
                return fechaEvento;
            }
            set
            {
                fechaEvento = value;
            }
        }

        public TextBox Nombre
        {
            get
            {
                return nombreEvento;
            }
            set
            {
                nombreEvento = value;
            }
        }

        public ListBox NoAsistieron
        {
            get
            {
                return listaNoAsistieron;
            }
            set
            {
                listaNoAsistieron = value;
            }
        }

        public ListBox Asistieron
        {
            get
            {
                return listaAsistentes;
            }
            set
            {
                listaAsistentes = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";

            if (!IsPostBack)
            {
                string idEvento = HttpContext.Current.Request.QueryString[M10_RecursosInterfaz.Detalle];
                string tipo = HttpContext.Current.Request.QueryString[M10_RecursosInterfaz.Tipo];
                presentador.CargarVentanaDetalle(idEvento, tipo);
            }

        }
    }
}