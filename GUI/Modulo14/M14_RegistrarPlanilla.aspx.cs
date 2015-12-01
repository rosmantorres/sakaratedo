using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo14;
using DominioSKD;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_RegistrarPlanilla : System.Web.UI.Page
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

            LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
            List<Planilla> listPlanilla = new List<Planilla>();
            listPlanilla = lP.ObtenerTipoPlanilla();
            Dictionary<string, string> options = new Dictionary<string, string>();

            options.Add("-1", "Selecciona una opcion");
            try
            {
                foreach (Planilla item in listPlanilla)
                {
                    options.Add(item.IDtipoPlanilla.ToString(), item.TipoPlanilla);
                }
                options.Add("-2", "OTRO");
            }
            catch (Exception e)
            {

            }
            
        comboTipoPlanilla.DataSource = options;
        comboTipoPlanilla.DataTextField = "value";
        comboTipoPlanilla.DataValueField = "key";
        comboTipoPlanilla.DataBind();

        
        }


        protected void comboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipoPlanilla.SelectedValue == "-2")
            {
                id_otro.Visible = true;
            }
            else
            {
                id_otro.Visible = false;
            }
            
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            List<String> listDatos = new List<String>();
            Planilla laPlanilla = null;
            ListItemCollection listItem = this.ListBox2.Items;
            String TipoPlanilla = "";

            LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();

            foreach (var item in listItem )
            {
                listDatos.Add(item.ToString());
                
            }

            laPlanilla = new Planilla(this.id_nombrePlanilla.Value, true,
                                               this.comboTipoPlanilla.SelectedIndex,
                                               listDatos);
            
          if(this.comboTipoPlanilla.SelectedValue!= "-1"){
              if(this.id_nombrePlanilla.Value!=""){
                  if(this.ListBox2.Items.Count > 0){
                      if (this.comboTipoPlanilla.SelectedValue == "-2")
                      {
                          if(this.id_nombretipo.Value!=""){
                              TipoPlanilla = this.id_nombretipo.Value;
                              lP.NuevoTipoPlanilla(TipoPlanilla);
                              lP.RegistrarPlanilla(laPlanilla, TipoPlanilla);
                              Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
                          }
                          else {
                              alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                              alertlocal.Attributes["role"] = "alert";
                              alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No ingresaste nombre del tipo de planilla</div>";
                              alertlocal.Visible = true;
                          } 
                      }
                      else
                      {
                          lP.RegistrarPlanilla(laPlanilla);
                          Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
                      }
                  }
                  else {
                      alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                      alertlocal.Attributes["role"] = "alert";
                      alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No seleccionaste ningun dato</div>";
                      alertlocal.Visible = true;
                  }
              }
              else {
                  alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                  alertlocal.Attributes["role"] = "alert";
                  alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No ingresaste el nombre de la planilla</div>";
                  alertlocal.Visible = true;
              }
          }
          else {
              alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
              alertlocal.Attributes["role"] = "alert";
              alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No seleccionaste tipo de planilla</div>";
              alertlocal.Visible = true;
          }
           
        }

        protected void AgregarDato_Click(object sender, EventArgs e)
        {
              string opcionDato=ListBox1.SelectedItem.Text;
              ListBox2.Items.Add(new ListItem(opcionDato, ListBox1.SelectedValue));
              ListBox1.Items.Remove(opcionDato);
        }

        protected void QuitarDato_Click(object sender, EventArgs e)
        {
            string opcionDato2 = ListBox2.SelectedItem.Text;
            ListBox1.Items.Add(new ListItem(opcionDato2, ListBox2.SelectedValue));
            ListBox2.Items.Remove(opcionDato2);
        }

    }
}