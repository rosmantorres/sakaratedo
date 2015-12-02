using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosSKD.Modulo14;
using ExcepcionesSKD;

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
            ((SKD)Page.Master).IdModulo = RecursoInterfazModulo14.NumeroModulo;

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
            }

        }

        public void Alerta(string msj)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
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
                throw ex;
            }
        }

        public void llenarCombo()
        {

            if (comboDatos.SelectedValue == RecursoInterfazModulo14.Dojo)
            {
                this.campos.Text = "";
                this.campos.Text += RecursoInterfazModulo14.DojRif;
                this.campos.Text += RecursoInterfazModulo14.DojNombre;
                this.campos.Text += RecursoInterfazModulo14.DojTlf;
                this.campos.Text += RecursoInterfazModulo14.DojEmail;
            }
            else if (comboDatos.SelectedValue == RecursoInterfazModulo14.Persona)
            {
                this.campos.Text = "";
                this.campos.Text += RecursoInterfazModulo14.PerFechaNac;
                this.campos.Text += RecursoInterfazModulo14.PerNumDoc;
                this.campos.Text += RecursoInterfazModulo14.PerNombre;
                this.campos.Text += RecursoInterfazModulo14.PerApellido;
                this.campos.Text += RecursoInterfazModulo14.PerDir;
                this.campos.Text += RecursoInterfazModulo14.PerNacionalidad;
                this.campos.Text += RecursoInterfazModulo14.PerPeso;
                this.campos.Text += RecursoInterfazModulo14.PerEstatura;
                this.campos.Text += RecursoInterfazModulo14.PerImagen;
            }
            else if (comboDatos.SelectedValue == RecursoInterfazModulo14.Evento)
            {
                this.campos.Text = "";
                this.campos.Text += "$eve_descripcion<br/>";
                this.campos.Text += "$eve_nombre<br/>";
                this.campos.Text += "$eve_costo<br/>";
                this.campos.Text += "$CATEGORIA_cat<br/>";
                this.campos.Text += "$HORARIO_hor<br/>";
                this.campos.Text += "$TIPO_EVENTO<br/>";
            }
            else if (comboDatos.SelectedValue == RecursoInterfazModulo14.Competencia)
            {
                this.campos.Text = "";
                this.campos.Text += "$comp_nombre<br/>";
                this.campos.Text += "$comp_tipo<br/>";
                this.campos.Text += "$CATEGORIA_comp<br/>";
                this.campos.Text += "$comp_fecha_ini<br/>";
                this.campos.Text += "$comp_fecha_fin<br/>";
                this.campos.Text += "$comp_costo<br/>";
            }
            else if (comboDatos.SelectedValue == RecursoInterfazModulo14.Organizacion)
            {
                this.campos.Text = "";
                this.campos.Text += "$org_nombre<br/>";
                this.campos.Text += "$org_direccion<br/>";
                this.campos.Text += "$org_telefono<br/>";
                this.campos.Text += "$org_email<br/>";
            }
            else if (comboDatos.SelectedValue == RecursoInterfazModulo14.Matricula)
            {
                this.campos.Text = "";
                this.campos.Text += "$mat_identificador<br/>";
                this.campos.Text += "$mat_fecha_creacion<br/>";
                this.campos.Text += "$mat_activa<br/>";
                this.campos.Text += "$mat_fecha_ultimo_pago<br/>";
                this.campos.Text += "$mat_precio<br/>";
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