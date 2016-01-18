using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo14;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using Interfaz_Presentadores.Modulo14;
using CKEditor;
using CKEditor.NET;

namespace templateApp.GUI.Modulo14
{
    public partial class M14_DisenoPlanilla : System.Web.UI.Page, IContratoM14DisenoPlanilla
    {
        
        private PresentadorM14DisenoPlanilla presentador;

        #region contratos
        public Label tipoPlanilla 
        {
            get
            {
                return this.tipoPlanilla1;
            }
            set
            {
                this.tipoPlanilla1 = value;
            }
        }

        public Label planilla
        {
            get 
            {
                return this.Planilla1;
            }
            set
            {
                this.Planilla1 = value;
            }
        }
        public CKEditorControl CKEditor1
        {
            get
            {
                return this.CKEditor;
            }
            set
            {
                this.CKEditor = value;
            }
        }
        public DropDownList comboDatos
        {
            get
            {
                return this.comboDatos1;
            }
            set
            {
                this.comboDatos1 = value;
            }
        }
        public Label campos
        {
            get
            {
                return this.campos1;
            }
            set
            {
                this.campos1 = value;
            }
        }
        public Label camposStatic
        {
            get
            {
                return this.camposStatic1;
            }
            set
            {
                this.camposStatic1 = value;
            }
        }
        public string alertaClase
        {
            set
            {
                this.alerta.InnerText = value;
            }
        }
        public string alertaRol 
        { 
            set
            {
                this.alerta.InnerText = value;
            }
        }
        public string alert 
        { 
            set
            {
                this.alerta.InnerHtml = value;
            }
        }
        #endregion

        public M14_DisenoPlanilla()
        {
            presentador = new PresentadorM14DisenoPlanilla(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = RecursoInterfazModulo14.NumeroModulo;
            presentador.PageLoad(Request, IsPostBack,Server);
/*
            try
            {
                if (Request.Cookies[RecursoInterfazModulo14.CookiePlanilla][RecursoInterfazModulo14.CookieId].ToString() != "")
                {
                    idPlanilla = Convert.ToInt32(Request.Cookies[RecursoInterfazModulo14.CookiePlanilla][RecursoInterfazModulo14.CookieId]);
                    this.tipoPlanilla.Text = Request.Cookies[RecursoInterfazModulo14.CookiePlanilla][RecursoInterfazModulo14.CookieTipo].ToString();
                    this.Planilla.Text = Request.Cookies[RecursoInterfazModulo14.CookiePlanilla][RecursoInterfazModulo14.CookieNombre].ToString();
                    dis = logica.ConsultarDiseñoPuro(idPlanilla);
                    planilla1 = new DominioSKD.Planilla(this.idPlanilla, this.Planilla.Text, true, this.tipoPlanilla.Text);

                    if (!IsPostBack)
                    {
                        List<String> datos = logica1.ObtenerDatosPlanilla(idPlanilla);
                        foreach (string dat in datos)
                        {
                            comboDatos.Items.Add(dat);
                        }
                        camposStatic.Text = RecursoInterfazModulo14.ParteSuperior;
                        camposStatic.Text += RecursoInterfazModulo14.DatosPlanilla;
                        camposStatic.Text += RecursoInterfazModulo14.ParteSuperior;
                        camposStatic.Text += RecursoInterfazModulo14.FechaCreacionPlanilla;
                        camposStatic.Text += RecursoInterfazModulo14.FechaRetiro;
                        camposStatic.Text += RecursoInterfazModulo14.FechaRein;
                        camposStatic.Text += RecursoInterfazModulo14.Motivo;
                        camposStatic.Text += RecursoInterfazModulo14.ParteSuperior;
                        llenarCombo();
                        CKEditor1.Text = Server.HtmlDecode(dis.Contenido);
                    }
                    Request.Cookies[RecursoInterfazModulo14.CookiePlanilla].Expires = DateTime.Now;

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
               // Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
            }*/

        }

    /*    public void Alerta(string msj)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }*/

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            presentador.btnguardar();
            /*
            htmlEncode = Server.HtmlEncode(CKEditor1.Text);
            DominioSKD.Diseño diseño = new DominioSKD.Diseño(CKEditor1.Text);
            try
            {
                if (dis.Contenido != "")
                {

                    if (CKEditor1.Text != "")
                    {
                        dis.Contenido = this.CKEditor1.Text;
                        exito = logica.ModificarDiseño(dis);

                        if (exito)
                        {
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursoInterfazModulo14.MsjDiseñoPlanillaModificado + "</div>";
                        }
                        else
                        {
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursoInterfazModulo14.MsjErrorPLanillaModificado + "</div>";
                        }
                    }

                }

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
                if (CKEditor1.Text != "")
                {
                    exito = logica.AgregarDiseño(diseño, planilla1);
                    if (exito)
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursoInterfazModulo14.MsjPlanillaGuardada + "</div>";
                    }
                    else
                    {
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursoInterfazModulo14.MsjErrorNoGuardada + "</div>";
                    }
                }
                //throw ex;
            }
             */
        }

 
        protected void comboDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.llenarCombo();
        }
    }
}