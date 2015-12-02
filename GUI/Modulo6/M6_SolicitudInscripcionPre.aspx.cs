using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using LogicaNegociosSKD.Modulo6;
using LogicaNegociosSKD.Modulo3;
using DominioSKD;
using ExcepcionesSKD.Modulo6;
using System.Diagnostics;

namespace templateApp.GUI.Modulo6
{
    public partial class M6_SolicitudInscripcionPre : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Organizacion> organizaciones = LogicaOrganizaciones.obtenerListaDeOrganizaciones();
                
                // TODO Tratar de Ordenar la lista
                this.OrgDrop.DataSource = organizaciones;
                this.OrgDrop.DataTextField = "Nombre";
                this.OrgDrop.DataValueField = "Id_organizacion";
                this.OrgDrop.DataBind();

                this.SetDojoDrop(this.OrgDrop.SelectedItem.Value);
            }

        }

        protected void OrgDropChange(object sender, EventArgs e)
        {
            this.SetDojoDrop(this.OrgDrop.SelectedItem.Value);
        }

        private void SetDojoDrop(String value){
            List<Dojo> _dojos = new List<Dojo>();
            Dojo dj;

            switch (value)
            {
                case "2":
                    dj = new Dojo();
                    dj.Id_dojo = 1;
                    dj.Nombre_dojo = "Dojo 1";
                    _dojos.Add(dj);
                    dj = new Dojo();
                    dj.Id_dojo = 2;
                    dj.Nombre_dojo = "Dojo 2";
                    _dojos.Add(dj);
                    dj = new Dojo();
                    dj.Id_dojo = 6;
                    dj.Nombre_dojo = "Dojo 6";
                    _dojos.Add(dj);
                    dj = new Dojo();
                    dj.Id_dojo = 7;
                    dj.Nombre_dojo = "Dojo 7";
                    _dojos.Add(dj);
                    break;
                case "5":
                    dj = new Dojo();
                    dj.Id_dojo = 3;
                    dj.Nombre_dojo = "Dojo 3";
                    _dojos.Add(dj);
                    dj = new Dojo();
                    dj.Id_dojo = 5;
                    dj.Nombre_dojo = "Dojo 5";
                    _dojos.Add(dj);
                    dj = new Dojo();
                    dj.Id_dojo = 10;
                    dj.Nombre_dojo = "Dojo 10";
                    _dojos.Add(dj);
                    break;
                case "6":
                    dj = new Dojo();
                    dj.Id_dojo = 8;
                    dj.Nombre_dojo = "Dojo 8";
                    _dojos.Add(dj);
                    break;
                case "7":
                    dj = new Dojo();
                    dj.Id_dojo = 4;
                    dj.Nombre_dojo = "Dojo 4";
                    _dojos.Add(dj);
                    dj = new Dojo();
                    dj.Id_dojo = 9;
                    dj.Nombre_dojo = "Dojo 9";
                    _dojos.Add(dj);
                    break;
            }
            this.DojoDrop.DataSource = _dojos;
            this.DojoDrop.DataTextField = "Nombre_dojo";
            this.DojoDrop.DataValueField = "Id_dojo";
            this.DojoDrop.DataBind();
        }
        protected void ProsesarSolicitud(object sender, EventArgs e)
        {
            try { 
                LogicaSolicitudInscripcion.ProcesarSolicitudInscripcion(Request.Form);
                Response.Redirect("~/GUI/Modulo1/Index.aspx" + "?"
                    + "Info" + "=" +
                    "Solicitud Creada Satisfactoriamente.");
            }
            catch (SolicitudException excep)
            {
                this.labelinfo.Visible = true;
                this.labelinfo.Text = excep.Mensaje;
            }
        }
    }
}