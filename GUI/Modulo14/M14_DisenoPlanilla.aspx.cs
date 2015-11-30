using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo14;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_DisenoPlanilla : System.Web.UI.Page
    {
        private LogicaNegociosSKD.Modulo14.LogicaDiseño logica = new LogicaNegociosSKD.Modulo14.LogicaDiseño();
        private LogicaNegociosSKD.Modulo14.LogicaPlanilla logica1 = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
        private DominioSKD.Planilla planilla1;
        private DominioSKD.Diseño dis;
        private Boolean exito;
        private string htmlEncode;
        private int idPlanilla;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";

                try
                {
                    if (Request.Cookies["Planilla"]["id"].ToString() != "")
                    {
                        idPlanilla = Convert.ToInt32(Request.Cookies["Planilla"]["id"]);
                        this.tipoPlanilla.Text = Request.Cookies["Planilla"]["tipo"].ToString();
                        this.Planilla.Text = Request.Cookies["Planilla"]["nombre"].ToString();
                        dis = logica.ConsultarDiseñoPuro(idPlanilla);
                        planilla1 = new DominioSKD.Planilla(this.idPlanilla, this.Planilla.Text, true, this.tipoPlanilla.Text);
                       
                        if (!IsPostBack)
                        {
                            List<String> datos = logica1.ObtenerDatosPlanilla(idPlanilla);
                            foreach (string dat in datos)
                            {
                                comboDatos.Items.Add(dat);
                            }
                            llenarCombo();
                            CKEditor1.Text = Server.HtmlDecode(dis.Contenido);
                        }
                        Request.Cookies["Planilla"].Expires = DateTime.Now;
                        
                    }
                }
                catch (Exception exce)
                {
                    string a = exce.Message;
                    //HttpContext.Current.Response.Redirect("M14_DisenoPlanilla.aspx");
                }
            
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            htmlEncode = Server.HtmlEncode(CKEditor1.Text);
            DominioSKD.Diseño diseño = new DominioSKD.Diseño(CKEditor1.Text);
            try
            {
                if (dis.Contenido!= "")
                {
                   
                    if (CKEditor1.Text != "")
                    {
                        dis.Contenido = this.CKEditor1.Text;
                        exito = logica.ModificarDiseño(dis);

                        if (exito)
                        {
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Diseño de Plantilla Modificado satisfactoriamente</div>";
                        }
                        else
                        {
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error no se pudo Modificar el diseño. Intente más tarde</div>";
                        }
                    }

                }

            }
            catch (Exception exce)
            {
                string a = exce.Message;
                if (CKEditor1.Text != "")
                {
                    exito = logica.AgregarDiseño(diseño, planilla1);
                    if (exito)
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Diseño de Plantilla guardado satisfactoriamente</div>";
                    }
                    else
                    {
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error no se pudo guardar el diseño. Intente más tarde</div>";
                    }
                }
            }
        }

        public void llenarCombo()
        {
            if (comboDatos.SelectedValue == "DOJO")
            {
                this.campos.Text = "";
                this.campos.Text += "$doj_rif<br/>";
                this.campos.Text += "$doj_nombre<br/>";
                this.campos.Text += "$doj_telefono<br/>";
                this.campos.Text += "$doj_email<br/>";
                this.campos.Text += "$doj_status<br/>";
            }
            else if (comboDatos.SelectedValue == "PERSONA")
            {
                this.campos.Text = "";
                this.campos.Text += "$per_tipo_doc_id<br/>";
                this.campos.Text += "$per_num_doc_id<br/>";
                this.campos.Text += "$per_nombre<br/>";
                this.campos.Text += "$per_apellido<br/>";
                this.campos.Text += "$per_sexo<br/>";
                this.campos.Text += "$per_fecha_nacimiento<br/>";
                this.campos.Text += "$per_nombre_usuario<br/>";
                this.campos.Text += "$per_peso<br/>";
                this.campos.Text += "$per_estatura<br/>";
                this.campos.Text += "$per_imagen<br/>";
            }
            else if (comboDatos.SelectedValue == "EVENTO")
            {
                this.campos.Text = "";
                this.campos.Text += "$eve_descripcion<br/>";
                this.campos.Text += "$eve_nombre<br/>";
                this.campos.Text += "$eve_costo<br/>";
                this.campos.Text += "$CATEGORIA_cat_id<br/>";
                this.campos.Text += "$HORARIO_hor_id<br/>";
                this.campos.Text += "$TIPO_EVENTO_TIPO_EVENTO<br/>";
            }
            else if (comboDatos.SelectedValue == "COMPETENCIA")
            {
                this.campos.Text = "";
                this.campos.Text += "$comp_nombre<br/>";
                this.campos.Text += "$comp_tipo<br/>";
                this.campos.Text += "$CATEGORIA_comp_id<br/>";
                this.campos.Text += "$comp_fecha_ini<br/>";
                this.campos.Text += "$comp_fecha_fin<br/>";
                this.campos.Text += "$comp_costo<br/>";
            }
            else if (comboDatos.SelectedValue == "ORGANIZACION")
            {
                this.campos.Text = "";
                this.campos.Text += "$org_nombre<br/>";
                this.campos.Text += "$org_direccion<br/>";
                this.campos.Text += "$org_telefono<br/>";
                this.campos.Text += "$org_email<br/>";
            }
            else if (comboDatos.SelectedValue == "MATRICULA")
            {
                this.campos.Text = "";
                this.campos.Text += "$mat_identificador<br/>";
                this.campos.Text += "$mat_fecha_creacion<br/>";
                this.campos.Text += "$mat_activa<br/>";
                this.campos.Text += "$mat_fecha_ultimo_pago<br/>";
            }
            else
                this.campos.Text = "";
        }
        protected void comboDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCombo();
        }
        
    }
}