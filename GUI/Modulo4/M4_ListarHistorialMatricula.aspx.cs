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
            String info = Request.QueryString["info"];
            String detalleString = Request.QueryString["matriculaEliminar"];

            if (detalleString != null)
            {
                Eliminarmatricula(detalleString);
            }


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
                    this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Monto BsF." + M4_RecursoInterfaz.CerrarTH;
                    if (String.Compare(RolPersona, "Sistema") == 0)
                    {
                        this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Dojo" + M4_RecursoInterfaz.CerrarTH;
                        this.sta.Text += M4_RecursoInterfaz.AbrirTH + "Acciones" + M4_RecursoInterfaz.CerrarTH;
                        this.sta.Text += M4_RecursoInterfaz.CerrarTR;

                        laLista = logMatricula.obtenerListaDeMatriculas();
                      if (laLista.Count != 0)
                            foreach (Historial_Matricula h in laLista)
                            {

                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTR;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + h.Fecha_historial_matricula.ToString("dd/MM/yyyy") + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + h.Modalidad_historial_matricula.ToString() + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + "Bsf. " + h.Monto_historial_matricula.ToString() + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + h.DojoNombre_historial_matricula.ToString() + M4_RecursoInterfaz.CerrarTD;
                                this.laTabla.Text += M4_RecursoInterfaz.AbrirTD;
                                this.laTabla.Text += M4_RecursoInterfaz.BotonModificar + h.Id_historial_matricula + M4_RecursoInterfaz.BotonCerrar;
                                this.laTabla.Text += M4_RecursoInterfaz.BotonEliminar + h.Id_historial_matricula + M4_RecursoInterfaz.BotonCerrar;
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
                            int id = 0;
                            id = BuscarDojoPersona(int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString()));
                            laLista = logMatricula.obtenerListaDeMatriculas(id);
                            if (laLista.Count != 0)
                                foreach (Historial_Matricula h in laLista)
                                {

                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTR;
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + h.Fecha_historial_matricula.ToString("dd/MM/yyyy") + M4_RecursoInterfaz.CerrarTD;
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + h.Modalidad_historial_matricula.ToString() + M4_RecursoInterfaz.CerrarTD;
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD + "Bsf. " + h.Monto_historial_matricula.ToString() + M4_RecursoInterfaz.CerrarTD;
                                    this.laTabla.Text += M4_RecursoInterfaz.AbrirTD;
                                    this.laTabla.Text += M4_RecursoInterfaz.BotonModificar + h.Id_historial_matricula + M4_RecursoInterfaz.BotonCerrar;
                                    this.laTabla.Text += M4_RecursoInterfaz.BotonEliminar + h.Id_historial_matricula + M4_RecursoInterfaz.BotonCerrar2;
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




                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
            #endregion

        protected int BuscarDojoPersona(int idusuario)
        {
            LogicaHistorial_Matricula logMatricula = new LogicaHistorial_Matricula();
            int idDojo=0;
            try 
            {
                 idDojo = logMatricula.obtenerDojoPersona(idusuario);
                 return idDojo;
                    
            }
            catch (Exception ex)
            {
                   throw ex;
            }
           
        }

        protected void Eliminarmatricula(String matriculaEliminar)
        {
            int idmatricula = int.Parse(matriculaEliminar);
            LogicaHistorial_Matricula logMatricula = new LogicaHistorial_Matricula();
            try
            {
                logMatricula.eliminarMatricula(idmatricula);
                Response.Redirect("M4_ListarHistorialMatricula.aspx?success=2");
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}