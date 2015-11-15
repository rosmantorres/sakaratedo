using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo12;

namespace templateApp.GUI.Modulo12
{
    public partial class M12_ListarCompetencias : System.Web.UI.Page
    {
        private List<Competencia> laLista = new List<Competencia>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "12";

            String success = Request.QueryString["success"];
            String detalleString = Request.QueryString["compDetalle"];


            if (detalleString != null)
            {
                llenarModalInfo(int.Parse(detalleString));
                            
            
            
            
            }



            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Competencia agregada exitosamente</div>";
                }

                if (success.Equals("2"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Competencia eliminada exitosamente</div>";
                }

                if (success.Equals("3"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Competencia modificada exitosamente</div>";
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
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.Organizacion.Nombre.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.TipoCompetencia.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.Ubicacion.Ciudad.ToString() + ", " + c.Ubicacion.Estado.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD + c.Status.ToString() + M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.AbrirTD;
                        this.laTabla.Text += M12_RecursoInterfaz.BotonInfo + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M12_RecursoInterfaz.BotonModificar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M12_RecursoInterfaz.BotonEliminar + c.Id_competencia + M12_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M12_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M12_RecursoInterfaz.CerrarTR;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
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