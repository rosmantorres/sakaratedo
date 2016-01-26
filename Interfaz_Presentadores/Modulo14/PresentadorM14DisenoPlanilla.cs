using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo14;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14DisenoPlanilla
    {
        private IContratoM14DisenoPlanilla vista;
        private Entidad dis;
        private Boolean exito;
        private Planilla planilla1;
        private int idPlanilla;

        public PresentadorM14DisenoPlanilla(IContratoM14DisenoPlanilla vista)
        {
            this.vista = vista;
        }

        public void PageLoad(HttpRequest request, bool hit, HttpServerUtility server)
        {
            FabricaComandos fabrica = new FabricaComandos();
            FabricaEntidades entidad = new FabricaEntidades();
            Planilla pla = (Planilla)entidad.ObtenerPlanilla();
            try
            {
                if (request.Cookies[RecursosPresentadorModulo14.CookiePlanilla][RecursosPresentadorModulo14.CookieId].ToString() != "")
                {
                    idPlanilla = Convert.ToInt32(request.Cookies[RecursosPresentadorModulo14.CookiePlanilla][RecursosPresentadorModulo14.CookieId]);
                    pla.Id = idPlanilla;
                    vista.tipoPlanilla.Text = request.Cookies[RecursosPresentadorModulo14.CookiePlanilla][RecursosPresentadorModulo14.CookieTipo].ToString();
                    vista.planilla.Text = request.Cookies[RecursosPresentadorModulo14.CookiePlanilla][RecursosPresentadorModulo14.CookieNombre].ToString();
                    ComandoConsultarDiseñoPuro commando =
                        (ComandoConsultarDiseñoPuro)fabrica.ObtenerComandoConsultarDiseñoPuro();
                    commando.Planilla = pla;
                    dis = commando.Ejecutar();
                    planilla1 = new DominioSKD.Planilla(idPlanilla, vista.planilla.Text, true, vista.tipoPlanilla.Text);

                    if (!hit)
                    {
                        ComandoObtenerDatosPlanilla command =
                         (ComandoObtenerDatosPlanilla)fabrica.ObtenerComandoObtenerDatosPlanilla();
                        command.IdPlanilla = idPlanilla;
                        List<String> datos = command.Ejecutar();

                        foreach (string dat in datos)
                        {
                            vista.comboDatos.Items.Add(dat);
                        }
                        vista.camposStatic.Text = RecursosPresentadorModulo14.ParteSuperior;
                        vista.camposStatic.Text += RecursosPresentadorModulo14.DatosPlanilla;
                        vista.camposStatic.Text += RecursosPresentadorModulo14.ParteSuperior;
                        vista.camposStatic.Text += RecursosPresentadorModulo14.FechaCreacionPlanilla;
                        vista.camposStatic.Text += RecursosPresentadorModulo14.FechaRetiro;
                        vista.camposStatic.Text += RecursosPresentadorModulo14.FechaRein;
                        vista.camposStatic.Text += RecursosPresentadorModulo14.Motivo;
                        vista.camposStatic.Text += RecursosPresentadorModulo14.ParteSuperior;
                        llenarCombo();
                        vista.CKEditor1.Text = server.HtmlDecode(((Diseño)dis).Contenido);
                    }
                    request.Cookies[RecursosPresentadorModulo14.CookiePlanilla].Expires = DateTime.Now;
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
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public void btnguardar()
        {
            FabricaEntidades entidad = new FabricaEntidades();
            Diseño diseño = (Diseño)entidad.obtenerDiseño(vista.CKEditor1.Text);
            FabricaComandos fabrica = new FabricaComandos();
            try
            {
                if (((Diseño)dis).Contenido != "")
                {

                    if (vista.CKEditor1.Text != "")
                    {
                        ((Diseño)dis).Contenido = vista.CKEditor1.Text;
                        ComandoModificarDiseno comando = 
                            (ComandoModificarDiseno)fabrica.ObtenerComandoModificarDiseno();
                        comando.Diseño = dis;
                        exito = comando.Ejecutar();

                        if (exito)
                        {
                            vista.alertaClase = "alert alert-success alert-dismissible";
                            vista.alertaRol = "alert";
                            vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursosPresentadorModulo14.MsjDiseñoPlanillaModificado + "</div>";
                        }
                        else
                        {
                            vista.alertaClase = "alert alert-danger alert-dismissible";
                            vista.alertaRol = "alert";
                            vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursosPresentadorModulo14.MsjErrorPLanillaModificado + "</div>";
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
                if (vista.CKEditor1.Text != "")
                {
                    ComandoAgregarDiseno command = 
                        (ComandoAgregarDiseno)fabrica.ObtenerComandoAgregarDiseno();
                    command.Diseño = diseño;
                    command.Planilla = planilla1;
                    exito = command.Ejecutar();
                    if (exito)
                    {
                        vista.alertaClase = "alert alert-success alert-dismissible";
                        vista.alertaRol = "alert";
                        vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursosPresentadorModulo14.MsjPlanillaGuardada + "</div>";
                    }
                    else
                    {
                        vista.alertaClase = "alert alert-danger alert-dismissible";
                        vista.alertaRol = "alert";
                        vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + RecursosPresentadorModulo14.MsjErrorNoGuardada + "</div>";
                    }
                }
                //throw ex;
            }
        }

        public void llenarCombo()
        {

            if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Dojo)
            {
                vista.campos.Text= "";
                vista.campos.Text += RecursosPresentadorModulo14.DojRif;
                vista.campos.Text += RecursosPresentadorModulo14.DojNombre;
                vista.campos.Text += RecursosPresentadorModulo14.DojTlf;
                vista.campos.Text += RecursosPresentadorModulo14.DojEmail;
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Persona)
            {
                vista.campos.Text = "";
                vista.campos.Text += RecursosPresentadorModulo14.PerFechaNac;
                vista.campos.Text += RecursosPresentadorModulo14.PerNumDoc;
                vista.campos.Text += RecursosPresentadorModulo14.PerNombre;
                vista.campos.Text += RecursosPresentadorModulo14.PerApellido;
                vista.campos.Text += RecursosPresentadorModulo14.PerDir;
                vista.campos.Text += RecursosPresentadorModulo14.PerNacionalidad;
                vista.campos.Text += RecursosPresentadorModulo14.PerPeso;
                vista.campos.Text += RecursosPresentadorModulo14.PerEstatura;
                vista.campos.Text += RecursosPresentadorModulo14.PerImagen;
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Evento)
            {
                vista.campos.Text = "";
                vista.campos.Text += RecursosPresentadorModulo14.EveDescrip;
                vista.campos.Text += RecursosPresentadorModulo14.EveNombre;
                vista.campos.Text += RecursosPresentadorModulo14.EveCosto;
                vista.campos.Text += RecursosPresentadorModulo14.CategoriaCat;
                vista.campos.Text += RecursosPresentadorModulo14.HorarioHor;
                vista.campos.Text += RecursosPresentadorModulo14.TipoEvento;
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Competencia)
            {
                vista.campos.Text = "";
                vista.campos.Text += RecursosPresentadorModulo14.CompNombre;
                vista.campos.Text += RecursosPresentadorModulo14.CompTipo;
                vista.campos.Text += RecursosPresentadorModulo14.CategoriaComp;
                vista.campos.Text += RecursosPresentadorModulo14.CompFechaIni;
                vista.campos.Text += RecursosPresentadorModulo14.CompFechaFin;
                vista.campos.Text += RecursosPresentadorModulo14.CompCosto;
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Organizacion)
            {
                vista.campos.Text = "";
                vista.campos.Text += RecursosPresentadorModulo14.OrgNombre;
                vista.campos.Text += RecursosPresentadorModulo14.OrgDireccion;
                vista.campos.Text += RecursosPresentadorModulo14.OrgTelefono;
                vista.campos.Text += RecursosPresentadorModulo14.OrgEmail;
            }
            else if (vista.comboDatos.SelectedValue == RecursosPresentadorModulo14.Matricula)
            {
                vista.campos.Text = "";
                vista.campos.Text += RecursosPresentadorModulo14.MatIdenti;
                vista.campos.Text += RecursosPresentadorModulo14.MatFechaCrea;
                vista.campos.Text += RecursosPresentadorModulo14.MatActiva;
                vista.campos.Text += RecursosPresentadorModulo14.MatFechaUltPago;
                vista.campos.Text += RecursosPresentadorModulo14.MatPrecio;
            }
            else
                vista.campos.Text = "";
        }
    }
}
