using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_ModificarPlanillaCreada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "14";

            
            Planilla laPlanilla = null;
            try
            {
                if (!IsPostBack)
                {
                    int idPlanilla = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
                    id_planilla.Visible = false;
                    id_otro.Visible = false;
                    this.id_planilla.Value = idPlanilla.ToString();
                    LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
                    laPlanilla = lP.ObtenerPlanillaID(idPlanilla);
                    llenarComboTipoPlanilla(laPlanilla.TipoPlanilla);
                    this.id_nombrePlanilla.Value = laPlanilla.Nombre;
                    foreach (String item in laPlanilla.Dato)
                    {
                        this.ListBox2.Items.Add(new ListItem(item, item));
                        ListBox1.Items.Remove(item);
                    }

                }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
        }

        public void Alerta(string msj)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        protected void llenarComboTipoPlanilla(String tipoPlanilla)
        {

            LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
            List<Planilla> listPlanilla = new List<Planilla>();
            Dictionary<string, string> options = new Dictionary<string, string>();
            try
            {
            listPlanilla = lP.ObtenerTipoPlanilla();
            
                //mostrar el primer lugar el tipo de planilla actual
                foreach (Planilla item2 in listPlanilla)
                {
                    if(tipoPlanilla == item2.TipoPlanilla)
                        options.Add(item2.IDtipoPlanilla.ToString(), item2.TipoPlanilla);
                }
                //mostrar los tipos de planilla menos el actual
                foreach (Planilla item in listPlanilla)
                {
                    if (tipoPlanilla != item.TipoPlanilla)
                       options.Add(item.IDtipoPlanilla.ToString(), item.TipoPlanilla);
                }
                options.Add("-2", "OTRO");
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
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

        protected void btneditar_Click(object sender, EventArgs e)
        {
            List<String> listDatos = new List<String>();
            Planilla laPlanilla = null;
            ListItemCollection listItem = this.ListBox2.Items;
            String TipoPlanilla = "";

            LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();

            try
            {
                foreach (var item in listItem)
                {
                    listDatos.Add(item.ToString());

                }

                laPlanilla = new Planilla(Int32.Parse(this.id_planilla.Value), this.id_nombrePlanilla.Value, true,
                                                   Int32.Parse(this.comboTipoPlanilla.SelectedValue),
                                                   listDatos);

                if (this.comboTipoPlanilla.SelectedValue != "-1")
                {
                    if (this.id_nombrePlanilla.Value != "")
                    {
                        if (this.ListBox2.Items.Count > 0)
                        {
                            if (this.comboTipoPlanilla.SelectedValue == "-2")
                            {
                                if (this.id_nombretipo.Value != "")
                                {
                                    TipoPlanilla = this.id_nombretipo.Value;
                                    lP.NuevoTipoPlanilla(TipoPlanilla);
                                    lP.ModificarPlanillaID(laPlanilla, TipoPlanilla);
                                    Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
                                }
                                else
                                {
                                    alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                                    alertlocal.Attributes["role"] = "alert";
                                    alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No ingresaste nombre del tipo de planilla</div>";
                                    alertlocal.Visible = true;
                                }
                            }
                            else
                            {
                                lP.ModificarPlanillaID(laPlanilla);
                                Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
                            }
                        }
                        else
                        {
                            alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alertlocal.Attributes["role"] = "alert";
                            alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No seleccionaste ningun dato</div>";
                            alertlocal.Visible = true;
                        }
                    }
                    else
                    {
                        alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alertlocal.Attributes["role"] = "alert";
                        alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No ingresaste el nombre de la planilla</div>";
                        alertlocal.Visible = true;
                    }
                }
                else
                {
                    alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alertlocal.Attributes["role"] = "alert";
                    alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No seleccionaste tipo de planilla</div>";
                    alertlocal.Visible = true;
                }
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
           
        }

        protected void AgregarDato_Click(object sender, EventArgs e)
        {
            try
            {
                string opcionDato = ListBox1.SelectedItem.Text;
                ListBox2.Items.Add(new ListItem(opcionDato, ListBox1.SelectedValue));
                ListBox1.Items.Remove(opcionDato);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
        }

        protected void QuitarDato_Click(object sender, EventArgs e)
        {
            try
            {
                string opcionDato2 = ListBox2.SelectedItem.Text;
                ListBox1.Items.Add(new ListItem(opcionDato2, ListBox2.SelectedValue));
                ListBox2.Items.Remove(opcionDato2);
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }
        }
    
    }

}