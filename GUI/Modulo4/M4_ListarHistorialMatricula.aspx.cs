using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo4;
using templateApp.GUI.Master;

namespace templateApp.GUI.Modulo4
{
    public partial class M4_ListarHistorialMatricula : System.Web.UI.Page
    {
        private List<Historial_Matricula> laLista = new List<Historial_Matricula>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";

            String success = Request.QueryString["success"];
            String detalleString = Request.QueryString["dojoDetalle"];



            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Matricula agregada exitosamente</div>";
                }

                if (success.Equals("2"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Matricula eliminada exitosamente</div>";
                }

                if (success.Equals("3"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Matricula modificada exitosamente</div>";
                }

            }

            #region Llenar Data Table Con Historial Matriculas

            LogicaHistorial_Matricula logMatricula = new LogicaHistorial_Matricula();
            if (!IsPostBack)
            {
                try
                {
                    String RolPersona = (Session[RecursosInterfazMaster.sessionRol].ToString());
                    this.sta.Text += M4_RecursoInterfaz.AbrirTR;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Fecha" + M4_RecursoInterfaz.CerrarTH;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Modalidad" + M4_RecursoInterfaz.CerrarTH;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Monto" + M4_RecursoInterfaz.CerrarTH;
                    if (String.Compare(RolPersona, "Sistema") == 0)
                    {
                        this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Dojo" + M4_RecursoInterfaz.CerrarTH;
                        this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Acciones" + M4_RecursoInterfaz.CerrarTH;
                        this.sta.Text += M4_RecursoInterfaz.CerrarTR;

                        laLista = logMatricula.obtenerListaDeMatriculas();

                        foreach (Dojo d in laLista)
                        {

                            this.laTabla.Text += M4_RecursoInterfaz.AbrirTR;
                            this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + M4_RecursoInterfaz.InicioImagen + d.Logo_dojo + M4_RecursoInterfaz.FinalImagen + M4_RecursoInterfaz.CerrarTD;
                            this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.OrgNombre_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                            this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Nombre_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                            this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Ubicacion.Ciudad.ToString() + ", " + d.Ubicacion.Estado.ToString() + M4_RecursoInterfaz.CerrarTD;
                            if (String.Compare(d.Status_dojo, "True") == 0)
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + "Activo" + M4_RecursoInterfaz.CerrarTD;
                            else
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + "Bloqueado" + M4_RecursoInterfaz.CerrarTD;
                            this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.OrgNombre_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                            this.laTabla.Text += M4_RecursoInterfaz.AbrirTD;
                            this.laTabla.Text += M4_RecursoInterfaz.BotonInfo + d.Id_dojo + M4_RecursoInterfaz.BotonCerrar;
                            this.laTabla.Text += M4_RecursoInterfaz.BotonModificar + d.Id_dojo + M4_RecursoInterfaz.BotonCerrar;
                            this.laTabla.Text += M4_RecursoInterfaz.BotonEliminar + d.Id_dojo + M4_RecursoInterfaz.BotonCerrar;
                            this.laTabla.Text += M4_RecursoInterfaz.CerrarTD;
                            this.laTabla.Text += M4_RecursoInterfaz.CerrarTR;
                        }
                    }
                    else
                        if (String.Compare(RolPersona, "Organización") == 0)
                        {
                            this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Acciones" + M4_RecursoInterfaz.CerrarTH;
                            this.sta.Text += M4_RecursoInterfaz.CerrarTR;

                            laLista = logMatricula.obtenerListaDeDojos();


                            foreach (Dojo d in laLista)
                            {

                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTR;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + M4_RecursoInterfaz.InicioImagen + d.Logo_dojo + M4_RecursoInterfaz.FinalImagen + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.OrgNombre_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Nombre_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Ubicacion.Ciudad.ToString() + ", " + d.Ubicacion.Estado.ToString() + M4_RecursoInterfaz.CerrarTD;
                                if (String.Compare(d.Status_dojo, "True") == 0)
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + "Activo" + M4_RecursoInterfaz.CerrarTD;
                                else
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + "Bloqueado" + M4_RecursoInterfaz.CerrarTD;

                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD;
                                this.laTabla.Text += M4_RecursoInterfaz.BotonInfo + d.Id_dojo + M4_RecursoInterfaz.BotonCerrar;
                                this.laTabla.Text += M4_RecursoInterfaz.BotonModificar + d.Id_dojo + M4_RecursoInterfaz.BotonCerrar;
                                this.laTabla.Text += M4_RecursoInterfaz.BotonEliminar + d.Id_dojo + M4_RecursoInterfaz.BotonCerrar;
                                this.laTabla.Text += M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.CerrarTR;
                            }
                        }




                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
            #endregion
        
    }
}