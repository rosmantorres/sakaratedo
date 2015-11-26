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
        private DominioSKD.Planilla planilla1;
        private DominioSKD.Diseño dis;
        private Boolean exito;
        private string htmlEncode;
        private int idPlanilla;

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";
            if (!IsPostBack)
            {
                try
                {
                    if (Request.Cookies["Planilla"]["id"].ToString() != "")
                    {
                        idPlanilla = Convert.ToInt32(Request.Cookies["Planilla"]["id"]);
                        this.tipoPlanilla.Text = Request.Cookies["Planilla"]["tipo"].ToString();
                        this.Planilla.Text = Request.Cookies["Planilla"]["nombre"].ToString();
                        if (Request.Cookies["Planilla"]["diseño"].ToString() != "")
                        {
                            exito = true;
                            dis = logica.ConsultarDiseñoPuro(idPlanilla);
                            CKEditor1.Text = Server.HtmlDecode(dis.Contenido);
                            Request.Cookies["Planilla"].Expires = DateTime.Now;
                        }
                    }
                }
                catch (Exception exce)
                {
                    string a = exce.Message;
                    exito = false;
                    this.tipoPlanilla.Text = "Retiro";
                    this.Planilla.Text = "Vacaciones";
                }
                planilla1 = new DominioSKD.Planilla(1, this.Planilla.Text, true, this.tipoPlanilla.Text);
            }
            
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            htmlEncode = Server.HtmlEncode(CKEditor1.Text);
            DominioSKD.Diseño diseño = new DominioSKD.Diseño(CKEditor1.Text);
            if (!exito)
            {
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
            else
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
    }
}