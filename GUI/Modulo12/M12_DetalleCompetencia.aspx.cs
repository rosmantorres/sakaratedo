using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo12;
using Interfaz_Contratos.Modulo12;
using Interfaz_Presentadores.Modulo12;


namespace templateApp.GUI.Modulo12
{
    public partial class M12_DetalleCompetencia : System.Web.UI.Page, IContratoDetalleCompetencia
    {
        //Competencia laCompetencia = new Competencia();
        //LogicaCompetencias laLogica = new LogicaCompetencias();
        public string laLatitud;
        public string laLongitud;

        private PresentadorDetalleCompetencia presentador;

        public M12_DetalleCompetencia()
        {
            presentador = new PresentadorDetalleCompetencia(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModulo;

            presentador.ObtenerVariableURL();

            //if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            //{
                
            //}
        }

        #region Contrato
        string IContratoDetalleCompetencia.nombreComp
        {
            get
            {
                return nombreComp.Text;
            }
            set
            {
                nombreComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.tipoComp
        {
            get
            {
                return tipoComp.Text;
            }
            set
            {
                tipoComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.orgComp
        {
            get
            {
                return orgComp.Text;
            }
            set
            {
                orgComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.statusComp
        {
            get
            {
                return statusComp.Text;
            }
            set
            {
                statusComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.costoComp
        {
            get
            {
                return costoComp.Text;
            }
            set
            {
                costoComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.inicioComp
        {
            get
            {
                return inicioComp.Text;
            }
            set
            {
                inicioComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.finComp
        {
            get
            {
                return finComp.Text;
            }
            set
            {
                finComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.latitudComp
        {
            get
            {
                return laLatitud;
            }
            set
            {
                laLatitud = value;
            }
        }

        string IContratoDetalleCompetencia.longitudComp
        {
            get
            {
                return laLongitud;
            }
            set
            {
                laLongitud = value;
            }
        }

        string IContratoDetalleCompetencia.categIniComp
        {
            get
            {
                return categIniComp.Text;
            }
            set
            {
                categIniComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.categFinComp
        {
            get
            {
                return categFinComp.Text;
            }
            set
            {
                categFinComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.edadIniComp
        {
            get
            {
                return categEdadIniComp.Text;
            }
            set
            {
                categEdadIniComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.edadFinComp
        {
            get
            {
                return categEdadFinComp.Text;
            }
            set
            {
                categEdadFinComp.Text = value;
            }
        }

        string IContratoDetalleCompetencia.categSexoComp
        {
            get
            {
                return categSexoComp.Text;
            }
            set
            {
                categSexoComp.Text = value;
            }
        }

        public string alertaClase
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[M12_RecursoInterfaz.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion
    }

}