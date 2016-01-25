using DominioSKD;
using Interfaz_Contratos.Modulo10;
using Interfaz_Presentadores.Modulo10;
using LogicaNegociosSKD.Modulo10;
using LogicaNegociosSKD.Modulo9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_ModificarAsistenciaEventos : System.Web.UI.Page, IContratoModificarAsistencia
    {
        PresentadorModificarAsistencia presentador;

        public M10_ModificarAsistenciaEventos()
        {
            this.presentador = new PresentadorModificarAsistencia(this);
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

        public ListBox ListaNo
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

        public ListBox ListaAsis
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
                Session[M10_RecursosInterfaz.IdEvento] = HttpContext.Current.Request.QueryString[M10_RecursosInterfaz.Modificar];
                Session[M10_RecursosInterfaz.tipoEvento] = HttpContext.Current.Request.QueryString[M10_RecursosInterfaz.Tipo];
                presentador.CargaVentana(Session[M10_RecursosInterfaz.IdEvento].ToString(), Session[M10_RecursosInterfaz.tipoEvento].ToString());
            }
        }

        protected void bIzquierdo_Click(object sender, EventArgs e)
        {
            presentador.MoverIzquierda();
        }

        protected void bDerecho_Click(object sender, EventArgs e)
        {
            presentador.MoverDerecha();
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            bool resultado = presentador.EventoClick_Modificar(Session[M10_RecursosInterfaz.IdEvento].ToString(), Session[M10_RecursosInterfaz.tipoEvento].ToString());
            if (resultado.Equals(true))
            {
                Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaModificada);
            }
            else if (resultado.Equals(false))
            {
                Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaNoModificada);
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(presentador.RedireccionarListarAsistenciaEvento());
        }

    }
}