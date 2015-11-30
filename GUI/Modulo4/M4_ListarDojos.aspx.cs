using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo4;

namespace templateApp.GUI.Modulo4
{
    public partial class M4_ListarDojos : System.Web.UI.Page
    {
        private List<Dojo> laLista = new List<Dojo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";
            
            String success = Request.QueryString["success"];
            String detalleString = Request.QueryString["dojoDetalle"];


           /* if (detalleString != null)
            {
                llenarModalInfo(int.Parse(detalleString));
                            
            
            
            
            }*/



            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Dojo agregado exitosamente</div>";
                }

                if (success.Equals("2"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Dojo eliminado exitosamente</div>";
                }

                if (success.Equals("3"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Dojo modificado exitosamente</div>";
                }

            }

            #region Llenar Data Table Con Dojos

            LogicaDojo logDojo = new LogicaDojo();
            if (!IsPostBack)
            {
                try
                {
                    laLista = logDojo.obtenerListaDeDojos();

                    foreach (Dojo d in laLista)
                    {
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTR;
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + M4_RecursoInterfaz.InicioImagen + d.Logo_dojo + M4_RecursoInterfaz.FinalImagen + M4_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Rif_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Nombre_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Organizacion_dojo + M4_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Ubicacion.Ciudad.ToString() + ", " + d.Ubicacion.Estado.ToString() + M4_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Estilo_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M4_RecursoInterfaz.AbrirTD;
                        this.laTabla.Text += M4_RecursoInterfaz.BotonInfo + d.Dojo_Id + M4_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M4_RecursoInterfaz.BotonModificar + d.Dojo_Id + M4_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M4_RecursoInterfaz.BotonEliminar + d.Dojo_Id + M4_RecursoInterfaz.BotonCerrar;
                        this.laTabla.Text += M4_RecursoInterfaz.CerrarTD;
                        this.laTabla.Text += M4_RecursoInterfaz.CerrarTR;
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

       /* protected void llenarModalInfo(int elIdDojo)
        {
            Competencia laCompetencia = new Competencia();
            LogicaDojo logica = new LogicaDojo();
            laCompetencia = logica.detalleDojoXId(elIdDojo);



        
        }*/
    }
}