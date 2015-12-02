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
    public partial class M4_ListarDojos : System.Web.UI.Page
    {
        private List<Dojo> laLista = new List<Dojo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "4";
            
            String success = Request.QueryString["success"];
            String detalleString = Request.QueryString["dojoDetalle"];
            String detalleString1 = Request.QueryString["dojoEliminar"];

            if (detalleString1 != null)
            {
                EliminarDojo(detalleString1);
            }


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
                    String RolPersona= (Session[RecursosInterfazMaster.sessionRol].ToString());
                    this.sta.Text += M4_RecursoInterfaz.AbrirTR;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Logo" + M4_RecursoInterfaz.CerrarTH;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Rif" + M4_RecursoInterfaz.CerrarTH;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Nombtre" + M4_RecursoInterfaz.CerrarTH;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Ubicación" + M4_RecursoInterfaz.CerrarTH;
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Status" + M4_RecursoInterfaz.CerrarTH;
                    if (String.Compare(RolPersona, "Sistema") == 0)
                    {
                        this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Organización" + M4_RecursoInterfaz.CerrarTH;
                        this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Acciones" + M4_RecursoInterfaz.CerrarTH;
                        this.sta.Text += M4_RecursoInterfaz.CerrarTR;
                        
                        laLista = logDojo.obtenerListaDeDojos();
                        if (laLista.Count != 0)
                            foreach (Dojo d in laLista)
                            {

                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTR;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + M4_RecursoInterfaz.InicioImagen + d.Logo_dojo + M4_RecursoInterfaz.FinalImagen + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Rif_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
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
                        else
                        {
                            alert.Attributes["class"] = "alert alert-info alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se encontraron registros asociados a su solicitud</div>";

                        }
                    }
                    else
                        if (String.Compare(RolPersona, "Organización") == 0)
                        {
                            this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Acciones" + M4_RecursoInterfaz.CerrarTH;
                            this.sta.Text += M4_RecursoInterfaz.CerrarTR;
                            
                            laLista = logDojo.obtenerListaDeDojos();

                            if (laLista.Count != 0)
                                foreach (Dojo d in laLista)
                                {

                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTR;
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + M4_RecursoInterfaz.InicioImagen + d.Logo_dojo + M4_RecursoInterfaz.FinalImagen + M4_RecursoInterfaz.CerrarTD;
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + d.Rif_dojo.ToString() + M4_RecursoInterfaz.CerrarTD;
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
                            {
                                alert.Attributes["class"] = "alert alert-info alert-dismissible";
                                alert.Attributes["role"] = "alert";
                                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se encontraron registros asociados a su solicitud</div>";

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



        protected void EliminarDojo(String dojoEliminar)
        {
            int idDojo = int.Parse(dojoEliminar);
            LogicaDojo logDojo = new LogicaDojo();
            try
            {
                logDojo.eliminarDojo(idDojo);
                Response.Redirect("M4_ListarDojos.aspx?success=2");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       /* protected void llenarModalInfo(int elIdDojo)
        {
            Competencia laCompetencia = new Competencia();
            LogicaDojo logica = new LogicaDojo();
            laCompetencia = logica.detalleDojoXId(elIdDojo);



        
        }*/
    }
}