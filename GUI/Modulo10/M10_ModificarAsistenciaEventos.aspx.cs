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
                String idEvento = HttpContext.Current.Request.QueryString[M10_RecursosInterfaz.Modificar];
                String tipo = HttpContext.Current.Request.QueryString[M10_RecursosInterfaz.Tipo];
                Session[M10_RecursosInterfaz.IdEvento] = "5";
                Session[M10_RecursosInterfaz.tipoEvento] = "Competencia";
                presentador.CargaVentana(Session[M10_RecursosInterfaz.IdEvento].ToString(), Session[M10_RecursosInterfaz.tipoEvento].ToString());
            }
        }

        protected void bIzquierdo_Click(object sender, EventArgs e)
        {
            for (int i = listaAsistentes.Items.Count - 1; i >= 0; i--)
            {
                if (listaAsistentes.Items[i].Selected == true)
                {
                    listaNoAsistieron.Items.Add(listaAsistentes.Items[i]);
                    ListItem li = listaAsistentes.Items[i];
                    listaAsistentes.Items.Remove(li);
                }
            }
        }

        protected void bDerecho_Click(object sender, EventArgs e)
        {
            for (int i = listaNoAsistieron.Items.Count - 1; i >= 0; i--)
            {
                if (listaNoAsistieron.Items[i].Selected == true)
                {
                    listaAsistentes.Items.Add(listaNoAsistieron.Items[i]);
                    ListItem li = listaNoAsistieron.Items[i];
                    listaNoAsistieron.Items.Remove(li);
                }
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            string idEvento = Session[M10_RecursosInterfaz.IdEvento].ToString();
            string tipoEvento = Session[M10_RecursosInterfaz.tipoEvento].ToString();
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