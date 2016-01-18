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
    public partial class M12_ListarCompetencias : System.Web.UI.Page, IContratoListarCompetencias
    {
        private List<Competencia> laLista = new List<Competencia>();
        private PresentadorListarCompetencias presentador;

        public M12_ListarCompetencias()
        {
            presentador = new PresentadorListarCompetencias(this);
        }

        #region Contrato

        string IContratoListarCompetencias.laTabla
        {
            get
            {
                return laTabla.Text;
            }
            set
            {
                laTabla.Text = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = M12_RecursoInterfaz.idModulo;


            String success = Request.QueryString[M12_RecursoInterfaz.strSuccess];
            String detalleString = Request.QueryString[M12_RecursoInterfaz.strCompDetalle];


            if (detalleString != null)
            {
                
            }

            if (success != null)
            {
                if (success.Equals(M12_RecursoInterfaz.idAlertAgregar))
                {
                    alert.Attributes[M12_RecursoInterfaz.alertClase] = M12_RecursoInterfaz.alertaSuccess;
                    alert.Attributes[M12_RecursoInterfaz.alertRole] = M12_RecursoInterfaz.tipoAlerta;
                    alert.InnerHtml = M12_RecursoInterfaz.innerHtmlAlertAgregar;
                    alert.Visible = true;
                }

                if (success.Equals(M12_RecursoInterfaz.idAlertModificar))
                {
                    alert.Attributes[M12_RecursoInterfaz.alertClase] = M12_RecursoInterfaz.alertaSuccess;
                    alert.Attributes[M12_RecursoInterfaz.alertRole] = M12_RecursoInterfaz.tipoAlerta;
                    alert.InnerHtml = M12_RecursoInterfaz.innerHtmlAlertModificar;
                    alert.Visible = true;
                }

            }

            #region Llenar Data Table Con Competencias

            LogicaCompetencias logComp = new LogicaCompetencias();
            if (!IsPostBack)
            {
                try
                {
                    laLista = logComp.obtenerListaDeCompetencias();

                    foreach (Competencia c in laLista)
                    {
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTR;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.Nombre.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.TipoCompetencia.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.Organizacion.Nombre.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.Ubicacion.Ciudad.ToString() + M12_RecursoInterfaz.coma + c.Ubicacion.Estado.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.Status.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD;
                        this.laTabla.Text += M12_RecursoInterfaz.BotonInfo + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M12_RecursoInterfaz.BotonModificar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.CerrarTR;
                    }

                }
                catch (ExcepcionesSKD.ExceptionSKD ex)
                {
                    this.alert.Attributes[M12_RecursoInterfaz.alertClase] = M12_RecursoInterfaz.alertaError;
                    this.alert.Attributes[M12_RecursoInterfaz.alertRole] = M12_RecursoInterfaz.tipoAlerta;
                    this.alert.InnerHtml = M12_RecursoInterfaz.alertaHtml + ex.Mensaje + M12_RecursoInterfaz.alertaHtmlFinal;
                    this.alert.Visible = true;
                }
            }
        }
        #endregion

        protected void btn_eliminarComp_Click(object sender, EventArgs e)
        {

        }

        protected void llenarModalInfo(int elIdCompetencia)
        {
            Competencia laCompetencia = new Competencia();
            LogicaCompetencias logica = new LogicaCompetencias();
            laCompetencia = logica.detalleCompetenciaXId(elIdCompetencia);

        }

    }
}