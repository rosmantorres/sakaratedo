using DominioSKD;
using Interfaz_Contratos.Modulo10;
using Interfaz_Presentadores.Modulo10;
using LogicaNegociosSKD.Modulo10;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo10
{
    public partial class M10_AgregarAsistenciaEventos : System.Web.UI.Page, IContratoAgregarAsistencia
    {
        List<Entidad> horariosEventos = new List<Entidad>();
        PresentadorAgregarAsistencia presentador;
        public M10_AgregarAsistenciaEventos()
        {
            this.presentador = new PresentadorAgregarAsistencia(this);
        }

        #region Contrato
        public Calendar calendario
        {
            get
            {
                return calendar;
            }
            set
            {
                calendar = value;
            }
        }

        public DropDownList comboEvento
        {
            get
            {
                return comboEventos;
            }
            set
            {
                comboEventos = value;
            }
        }

        public ListBox inscritos
        {
            get
            {
                return listaInscritos;
            }
            set
            {
                listaInscritos = value;
            }
        }

        public ListBox asistentes
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

        public Literal ausentesPlanilla
        {
            get
            {
                return tabla;
            }
            set 
            { 
                tabla = value; 
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "10";
            horariosEventos = presentador.horarioEventos();
        }

        protected void bDerecho_Click(object sender, EventArgs e)
        {
            presentador.MoverDerecha();
        }

        protected void bIzquierdo_Click(object sender, EventArgs e)
        {
            presentador.MoverIzquierda();
        }

        protected void bAgregar_Click(object sender, EventArgs e)
        {
            List<Asistencia> listaA = new List<Asistencia>();
            if (Session[M10_RecursosInterfaz.tipoEvento].ToString().Equals(M10_RecursosInterfaz.Evento))
            {
                #region Agregar Evento
                bool resultado = presentador.AgregarAsistenciaEvento(Session[M10_RecursosInterfaz.IdEvento].ToString());
                if (resultado.Equals(true))
                {
                    Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaEventoAgregada);
                }
                else if (resultado.Equals(false)) 
                {
                    Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaEventoNoAgregada);
                }
                #endregion
            }
            else if (Session[M10_RecursosInterfaz.tipoEvento].ToString().Equals(M10_RecursosInterfaz.Competencia))
            {
                #region Agregar Competencia
                bool resultado = presentador.AgregarAsistenciaCompetencia(Session[M10_RecursosInterfaz.IdEvento].ToString());
                if (resultado.Equals(true))
                {
                    Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaCompetenciaAgregada);
                }
                else if (resultado.Equals(false))
                {
                    Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaCompetenciaNoAgregada);
                }

                #endregion
            }
        }

        protected void bCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect(presentador.RedireccionarListarAsistenciaEvento());
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            presentador.RenderCalendario(e, horariosEventos);
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            Session[M10_RecursosInterfaz.FechaEvento] = ((Calendar)sender).SelectedDate.ToString();
            presentador.CargarComboEvento(Session[M10_RecursosInterfaz.FechaEvento].ToString());
        }

        protected void comboEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entidad> listaEventos = presentador.diccionarioEventos(Session[M10_RecursosInterfaz.FechaEvento].ToString());
            Session[M10_RecursosInterfaz.tipoEvento] = presentador.buscandoTipoEnValores(listaEventos, sender);
            Session[M10_RecursosInterfaz.IdEvento] = presentador.CargarListaInscritos_InasistentesPlanilla(Session[M10_RecursosInterfaz.tipoEvento].ToString(), sender);
        }
    }
}