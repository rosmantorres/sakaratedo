using ExcepcionesSKD;
using Interfaz_Contratos.Modulo14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Comandos.Modulo14;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD;
using System.Web.UI.WebControls;
using DominioSKD.Fabrica;

namespace Interfaz_Presentadores.Modulo14
{
    public class PresentadorM14RegistrarPlanilla
    {
        //Variable que contiene la vista respectiva de este presentador a ser manipulada
        private IContratoM14RegistrarPlanilla vista;

        public PresentadorM14RegistrarPlanilla(IContratoM14RegistrarPlanilla vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Llenar el combobox con los tipos de planillas existentes.
        /// </summary>
        public void LlenarComboTipoPlanilla()
        {
            Comando<List<Entidad>> comboTipoPlanilla = FabricaComandos.ObtenerComandoObtenerTipoPlanilla();
            
            List<Entidad> listPlanilla = new List<Entidad>();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            try
            {
                listPlanilla = comboTipoPlanilla.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo14.Planilla item in listPlanilla)
                {
                    options.Add(item.IDtipoPlanilla.ToString(), item.TipoPlanilla);
                }
                options.Add("-2", "OTRO");
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDiseñoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDDatosException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDPLanillaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (ExcepcionesSKD.Modulo14.BDSolicitudException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Alerta(ex.Message);
            }

            vista.tipoPlanillaCombo.DataSource = options;
            vista.tipoPlanillaCombo.DataTextField = "value";
            vista.tipoPlanillaCombo.DataValueField = "key";
            vista.tipoPlanillaCombo.DataBind();

        }
        /// <summary>
        /// Registra una planilla con los datos.
        /// </summary>
        /// <returns>verdadero si se agrega la planilla exitosamente</returns>>
        public bool AgregarPlanilla()
        {
            List<String> listDatos = new List<String>();
            ListItemCollection listItem = vista.datosPlanilla2.Items;
            String TipoPlanilla = "";
            Comando<Boolean> comandoTipoPlanilla = FabricaComandos.ObtenerComandoNuevoTipoPlanilla();
            Comando<bool> comandoRegistrarPlanillaTipo = FabricaComandos.ObtenerComandoRegistrarPlanillaTipo();
            Comando<bool> comandoRegistrarPlanilla = FabricaComandos.ObtenerComandoRegistrarPlanilla();
            bool respuesta = false;
            
            try
            {
                foreach (var item in listItem)
                {
                    listDatos.Add(item.ToString());

                }

                Entidad laPlanilla = FabricaEntidades.ObtenerPlanilla(vista.planillaNombre, true,
                                                                      vista.tipoPlanillaCombo.SelectedIndex,
                                                                      listDatos);
                if (vista.tipoPlanillaCombo.SelectedValue != "-1")
                {
                    if (vista.planillaNombre != "")
                    {
                        if (vista.datosPlanilla2.Items.Count > 0)
                        {
                            if (vista.tipoPlanillaCombo.SelectedValue == "-2")
                            {
                                if (vista.tipoNombre != "")
                                {
                                    TipoPlanilla = vista.tipoNombre;
                                 
                                    ((ComandoNuevoTipoPlanilla)comandoTipoPlanilla).NombreTipo = TipoPlanilla;
                                    comandoTipoPlanilla.Ejecutar();

                              
                                    ((ComandoRegistrarPlanillaTipo)comandoRegistrarPlanillaTipo).LaEntidad = laPlanilla;
                                    ((ComandoRegistrarPlanillaTipo)comandoRegistrarPlanillaTipo).NombreTipo = TipoPlanilla;
                                    respuesta = comandoRegistrarPlanillaTipo.Ejecutar();
                              
                                }
                                else
                                {
                                    vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                                    vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                                    vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.Alerta_NombreTipoVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal;
                                    vista.alerta= true;
                                    respuesta = false;
                                }
                            }
                            else
                            {
                                ((ComandoRegistrarPlanilla)comandoRegistrarPlanilla).LaEntidad = laPlanilla;
                                 respuesta = comandoRegistrarPlanilla.Ejecutar();
                            }
                        }
                        else
                        {
                            vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                            vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                            vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.Alerta_DatoVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal; ;
                            vista.alerta = true;
                            respuesta = false;
                        }
                    }
                    else
                    {
                        vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                        vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                        vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.Alerta_PlanillaVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal; ;
                        vista.alerta = true;
                        respuesta = false;
                    }
                }
                else
                {
                    vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                    vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                    vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.Alerta_TipoVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal; ;
                    vista.alerta = true;
                    respuesta = false;
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
            return respuesta;
        }

        public void Alerta(string msj)
        {
            vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
            vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
            vista.alertLocal = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }
        /// <summary>
        /// Permite que el nombre de tipo planilla sea visible.
        /// </summary>
        public void NombreTipoPlanillaVisible()
        {
            if (vista.tipoPlanillaCombo.SelectedValue == "-2")
            {
                vista.id_otroTipo = true;
            }
            else
            {
                vista.id_otroTipo = false;
            }
        }
        /// <summary>
        /// Permite agregar un dato a la lista.
        /// </summary>
        public void AgregarDato()
        {
            try
            {

                string opcionDato = vista.datosPlanilla1.SelectedItem.Text;
                vista.datosPlanilla2.Items.Add(new ListItem(opcionDato, vista.datosPlanilla1.SelectedValue));
                vista.datosPlanilla1.Items.Remove(opcionDato);
                if (opcionDato == "EVENTO")
                {
                    vista.datosPlanilla1.Items.Remove("COMPETENCIA");
                }
                if (opcionDato == "COMPETENCIA")
                {
                    vista.datosPlanilla1.Items.Remove("EVENTO");
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
        /// <summary>
        /// Permite quitar los datos de la lista.
        /// </summary>
        public void QuitarDato()
        {
            try
            {
                string opcionDato2 = vista.datosPlanilla2.SelectedItem.Text;
                vista.datosPlanilla1.Items.Add(new ListItem(opcionDato2, vista.datosPlanilla2.SelectedValue));
                vista.datosPlanilla2.Items.Remove(opcionDato2);
                if (opcionDato2 == "EVENTO")
                {
                    vista.datosPlanilla1.Items.Add("COMPETENCIA");
                }
                if (opcionDato2 == "COMPETENCIA")
                {
                    vista.datosPlanilla1.Items.Add("EVENTO");
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
        /// <summary>
        /// Carga la pagina.
        /// </summary>
        public void PageLoadRegistrarPlanilla()
        {
            try
            {
                vista.id_otroTipo = false;
                LlenarComboTipoPlanilla();
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

    }
}
