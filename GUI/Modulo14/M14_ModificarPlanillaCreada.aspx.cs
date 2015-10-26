using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_ModificarPlanillaCreada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            if (!IsPostBack)
            {
                id_otro.Visible = false;
                llenarComboTipoPlanilla();
            }
        }
        protected void llenarComboTipoPlanilla()
        {

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            options.Add("1", "Retiro");
            options.Add("2", "Ascenso");
            options.Add("3", "Otro");

            comboTipoPlanilla.DataSource = options;
            comboTipoPlanilla.DataTextField = "value";
            comboTipoPlanilla.DataValueField = "key";
            comboTipoPlanilla.DataBind();


        }

        protected void comboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoPlanilla.SelectedValue == "3")
            {
                id_otro.Visible = true;
            }
            else
            {
                id_otro.Visible = false;
            }

        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (comboTipoPlanilla.SelectedValue == "-1")
            {
                this.alertlocal.Attributes["class"] = "alert alert-danger";
                this.alertlocal.Attributes["role"] = "alert";
                this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has seleccionado el tipo de planilla.</div>";
                this.alertlocal.Visible = true;
            }
            if (comboTipoPlanilla.SelectedValue == "1" || comboTipoPlanilla.SelectedValue == "2")
            {
                if (Text1.Value == "")
                {
                    this.alertlocal.Attributes["class"] = "alert alert-danger";
                    this.alertlocal.Attributes["role"] = "alert";
                    this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has introduccido el nombre de planilla.</div>";
                    this.alertlocal.Visible = true;
                }

            }
            if (comboTipoPlanilla.SelectedValue == "3")
            {
                if (id_nombretipo.Value == "")
                {
                    this.alertlocal.Attributes["class"] = "alert alert-danger";
                    this.alertlocal.Attributes["role"] = "alert";
                    this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has introduccido el nombre de tipo planilla.</div>";
                    this.alertlocal.Visible = true;
                }
            }
            if (comboTipoPlanilla.SelectedValue == "3" && id_nombretipo.Value != "")
            {
                if (Text1.Value == "")
                {
                    this.alertlocal.Attributes["class"] = "alert alert-danger";
                    this.alertlocal.Attributes["role"] = "alert";
                    this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No has introduccido el nombre de tipo planilla.</div>";
                    this.alertlocal.Visible = true;
                }
            }
            if (comboTipoPlanilla.SelectedValue == "1" || comboTipoPlanilla.SelectedValue == "2")
            {
                /*    if (Text1.Value != "")
                   {
                        if (checkbox0.Value == "" && checkbox1.Value == "" && checkbox2.Value == "" && checkbox3.Value == "" && checkbox4.Value == "" && checkbox5.Value == "" && checkbox6.Value == "")
                        {
                        this.alertlocal.Attributes["class"] = "alert alert-danger";
                        this.alertlocal.Attributes["role"] = "alert";
                        this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>no has seleccionado datos para la planilla.</div>";
                        this.alertlocal.Visible = true;
                        }
                    }*/
            }
            if (comboTipoPlanilla.SelectedValue == "1" || comboTipoPlanilla.SelectedValue == "2")
            {
                if (Text1.Value != "")
                {
                    this.alertlocal.Attributes["class"] = "alert alert-success";
                    this.alertlocal.Attributes["role"] = "alert";
                    this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha registrado la planilla correctamente.</div>";
                    this.alertlocal.Visible = true;

                }
            }
            if (comboTipoPlanilla.SelectedValue == "3")
            {
                if (id_nombretipo.Value != "" && Text1.Value != "")
                {
                    this.alertlocal.Attributes["class"] = "alert alert-success";
                    this.alertlocal.Attributes["role"] = "alert";
                    this.alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha registrado la planilla correctamente.</div>";
                    this.alertlocal.Visible = true;

                }
            }
        }
    
    }

}