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
        Competencia laCompetencia = new Competencia();
        LogicaCompetencias laLogica = new LogicaCompetencias();
        public string laLatitud;
        public string laLongitud;

        private PresentadorDetalleCompetencia presentador;

        public M12_DetalleCompetencia()
        {
            presentador = new PresentadorDetalleCompetencia(this);
        }

        #region Contratos

        string IContratoDetalleCompetencia.nombreComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.tipoComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.orgComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.statusComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.costoComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.inicioComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.finComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string latitudComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string longitudComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.categIniComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.categFinComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.categEdadIniComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string cateEdadFinComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IContratoDetalleCompetencia.categSexoComp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string alertaClase
        {
            set { throw new NotImplementedException(); }
        }

        public string alertaRol
        {
            set { throw new NotImplementedException(); }
        }

        public string alerta
        {
            set { throw new NotImplementedException(); }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModulo;
            String detalleString = HttpContext.Current.Request.QueryString[M12_RecursoInterfaz.strCompDetalle];

            if (!IsPostBack) // verificar si la pagina se muestra por primera vez
            {
                presentador.DetallarCompetencia(int.Parse(detalleString));
            }
        }
    }

}