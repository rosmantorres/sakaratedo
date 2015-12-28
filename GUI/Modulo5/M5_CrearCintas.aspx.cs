using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo5;
using LogicaNegociosSKD.Modulo3;

namespace templateApp.GUI.Modulo5
{
    public partial class M5_CrearCintas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "5";

            // Controlador

            if (!IsPostBack)
            {
                llenarComboORG();
            }
            
        }

        protected void llenarComboORG()
        {

            LogicaNegociosSKD.Modulo3.LogicaOrganizacion lO = new LogicaNegociosSKD.Modulo3.LogicaOrganizacion();
            List<Organizacion> listOrganizacion = new List<Organizacion>();
            listOrganizacion = lO.ListarOrganizacion();
            Dictionary<string, string> options = new Dictionary<string, string>();

            options.Add("-1", "Selecciona una opcion");
            try
            {
                foreach (Organizacion item in listOrganizacion)
                {
                    options.Add(item.Id_organizacion.ToString(), item.Nombre);
                }
                options.Add("-2", "OTRO");
            }
            catch (Exception e)
            {

            }

            ListOrg.DataSource = options;
            ListOrg.DataTextField = "value";
            ListOrg.DataValueField = "key";
            ListOrg.DataBind();
        }

        protected void btnCrearCinta(object sender, EventArgs e){

            LogicaCinta lO = new LogicaNegociosSKD.Modulo5.LogicaCinta();
            string organizacion = "";
            string nombre = "";
            Cinta laCinta = new Cinta();
            Organizacion laOrganizacion = new Organizacion();
/*
            if (cinta.Value == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has llenado el campo nombre de la cinta.</div>";
                this.alertlocal.Visible = true;
            }
            else if (ran.Value == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has llenado el campo rango de la cinta.</div>";
                this.alertlocal.Visible = true;
            }
            else if (cate.Value == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has llenado el campo categoria de la cinta.</div>";
                this.alertlocal.Visible = true;
            }
            else if (signi.Value == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has llenado el campo significado de la cinta.</div>";
                this.alertlocal.Visible = true;
            }
            else if (ord.Value == "")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has llenado el campo orden de la cinta.</div>";
                this.alertlocal.Visible = true;
            }
            */
            if (this.ListOrg.SelectedValue != "-1" && this.ListOrg.SelectedValue != "-2")
            {           
                organizacion = this.ListOrg.SelectedValue;
                nombre = this.ListOrg.Text;
            }
                          
            string color = cinta.Value;
            string rango = ran.Value;
            string categoria = cate.Value;
            string significado = signi.Value;
            string orden = ord.Value;

            laCinta.Color_nombre = color;
            laCinta.Rango = rango;
            laCinta.Clasificacion = categoria;
            laCinta.Significado = significado;
            laCinta.Orden = Int32.Parse(orden);
            laOrganizacion.Id_organizacion = Int32.Parse(organizacion);
            laOrganizacion.Nombre = nombre;
            laCinta.Organizacion = laOrganizacion;
            //try
           try{
               lO.agregarCinta(laCinta);
               if (cinta.Value != "" && ran.Value != "" && cate.Value != "" && cate.Value != "" && signi.Value != "" && ord.Value != "")
               {
                   this.alertlocal.Attributes["class"] = "alert alert-success";
                   this.alertlocal.Attributes["role"] = "alert";
                   this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha creado la cinta con exito.</div>";
                   this.alertlocal.Visible = true;
               }
           }
           catch (ExcepcionesSKD.Modulo5.FormatoIncorrectoException ex)
           {
               
           }

        }

    }

}