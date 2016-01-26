using DominioSKD;
using Interfaz_Contratos.Modulo11;
using Interfaz_Presentadores.Modulo11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo11
{
    public partial class M11_DetalleResultadoCompetencia : System.Web.UI.Page, IContratoDetalleResultadoCompetencia
    {
        Evento evento = new Evento();
        Competencia competencia = new Competencia();
        PresentadorDetalleResultado presentador;
        public M11_DetalleResultadoCompetencia()
        {
            this.presentador = new PresentadorDetalleResultado(this);
        }
        #region Contrato
        public TextBox FechaEvento
        {
            get
            {
                return this.fechaEvento;
            }
            set
            {
                fechaEvento = value;
            }
        }

        public TextBox NombreEvento
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

        public TextBox EspecialidadEvento
        {
            get
            {
                return especialidadEvento;
            }
            set
            {
                especialidadEvento = value;
            }
        }

        public TextBox CategoriaEvento
        {
            get
            {
                return categoriaEvento;
            }
            set
            {
                categoriaEvento = value;
            }
        }

        public Literal TablaAscenso
        {
            get
            {
                return this.dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        public Literal TablaKata
        {
            get
            {
                return dataTable2;
            }
            set
            {
                dataTable2 = value;
            }
        }

        public Literal TablaKumite
        {
            get
            {
                return dataTable3;
            }
            set
            {
                dataTable3 = value;
            }
        }
        public bool LEspecialidad
        {
            get
            {
                return this.lEspecialidad.Visible;
            }
            set
            {
                this.lEspecialidad.Visible = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "11";
            if (!IsPostBack)
            {
                Session[M11_RecursoInterfaz.IdEvento] = Request.QueryString[M11_RecursoInterfaz.Mostrar];
                Session[M11_RecursoInterfaz.TipoEvento] = Request.QueryString[M11_RecursoInterfaz.Tipo];
                presentador.CargarVentana(Session[M11_RecursoInterfaz.IdEvento].ToString(), Session[M11_RecursoInterfaz.TipoEvento].ToString());
            }
        }
    }
}