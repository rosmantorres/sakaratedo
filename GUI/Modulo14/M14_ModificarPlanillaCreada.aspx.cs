using DominioSKD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_ModificarPlanillaCreada : System.Web.UI.Page, IContratoM14ModificarPlanillaCreada
    {
         private PresentadorM14ModificadorPlanillaCreada presentador;

         public M14_ModificarPlanillaCreada()
            {
               presentador = new PresentadorM14ModificadorPlanillaCreada(this);
            }
        protected void Page_Load(object sender, EventArgs e)
        {

            ((SKD)Page.Master).IdModulo = "14";

                if (!IsPostBack)
                {
                    presentador.PageLoadModificarPlanilla();
                   
                    /*try
                    {
                    Planilla laPlanilla = null;
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
                        if (item == "EVENTO")
                        {
                            ListBox1.Items.Remove("COMPETENCIA");
                        }
                        if (item == "COMPETENCIA")
                        {
                            ListBox1.Items.Remove("EVENTO");
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
                    }*/
            }
            
        }

        #region contratos

        public String planillaId
        {
            get
            {
                return this.id_planilla.Value;
            }
            set
            {
                this.id_planilla.Value = value;
            }
        }
        public DropDownList tipoPlanillaCombo
        {
            get
            {
                return this.comboTipoPlanilla;
            }
            set
            {
                this.comboTipoPlanilla = value;
            }
        }
        public String nombreTipo
        {
            get
            {
                return this.id_nombretipo.Value;
            }
            set
            {
                this.id_nombretipo.Value = value;
            }
        }
        public String nombrePlanilla
        {
            get
            {
                return this.id_nombrePlanilla.Value;
            }
            set
            {
                this.id_nombrePlanilla.Value = value;
            }
        }
        public ListBox datosPlanilla1
        {
            get
            {
                return this.ListBox1;
            }
            set
            {
                this.ListBox1 = value;
            }
        }
        public ListBox datosPlanilla2
        {
            get
            {
                return this.ListBox2;
            }
            set
            {
                this.ListBox2 = value;
            }
        }
        public String alertLocalRol
        {
            set
            {
                this.alertlocal.Attributes["role"] = value;
            }
        }
        public String alertLocalClase
        {
            set
            {
                this.alertlocal.Attributes["class"] = value;
            }
        }
        public String alertLocal
        {
            set
            {
                this.alertlocal.InnerHtml = value;
            }
        }
        public bool alerta
        {
            set
            {
                this.alertlocal.Visible = value;
            }
        }
        public bool id_otroTipo
        {
            set
            {
                this.id_otro.Visible = value;
            }
        }
        public int IDPlanillaModificar
        {
            get
            {
                return Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
            }
        }
        public bool IDPlanillaModificarVisible
        {
            set
            {
                this.id_planilla.Visible = value;
            }
        }
       

        #endregion
        public void Alerta(string msj)
        {
            presentador.Alerta(msj);
           /* alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
            */
        }

        /*protected void llenarComboTipoPlanilla(String tipoPlanilla)
        {
            presentador.LlenarTipoPlanillaCombo(tipoPlanilla);
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

            

        }*/

        protected void comboTipoPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.NombreTipoPVisible();
           /* if (comboTipoPlanilla.SelectedValue == "-2")
            {
                id_otro.Visible = true;
            }
            else
            {
                id_otro.Visible = false;
            }*/

        }

        protected void btneditar_Click(object sender, EventArgs e)
        {

            if (presentador.EditarPlanilla() == true)
            {
                Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
            }
            
                               
            /*List<String> listDatos = new List<String>();
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
            }*/
           
        }

        protected void AgregarDato_Click(object sender, EventArgs e)
        {
            presentador.AgregarDato();
            /*try
            {
                string opcionDato = ListBox1.SelectedItem.Text;
                ListBox2.Items.Add(new ListItem(opcionDato, ListBox1.SelectedValue));
                ListBox1.Items.Remove(opcionDato);
                if (opcionDato == "EVENTO")
                {
                    ListBox1.Items.Remove("COMPETENCIA");
                }
                if (opcionDato == "COMPETENCIA")
                {
                    ListBox1.Items.Remove("EVENTO");
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
            }*/
        }

        protected void QuitarDato_Click(object sender, EventArgs e)
        {
            presentador.QuitarDatos();
           /* try
            {
                string opcionDato2 = ListBox2.SelectedItem.Text;
                ListBox1.Items.Add(new ListItem(opcionDato2, ListBox2.SelectedValue));
                ListBox2.Items.Remove(opcionDato2);
                if (opcionDato2 == "EVENTO")
                {
                    ListBox1.Items.Add("COMPETENCIA");
                }
                if (opcionDato2 == "COMPETENCIA")
                {
                    ListBox1.Items.Add("EVENTO");
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
            }*/
        }
    
    }

}