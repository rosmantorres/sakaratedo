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
using System.Web.UI.WebControls;

namespace Interfaz_Presentadores.Modulo14
{
   public class PresentadorM14ModificadorPlanillaCreada 
    {
          //Variable que contiene la vista respectiva de este presentador a ser manipulada
        private IContratoM14ModificarPlanillaCreada vista;

        public PresentadorM14ModificadorPlanillaCreada(IContratoM14ModificarPlanillaCreada vista)
        {
            this.vista = vista;
        }
       public void Alerta(string msj)
       {
           vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
           vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
           vista.alertLocal = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
       }

       public void LlenarTipoPlanillaCombo(String tipoPlanilla)
       {
           //LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
           FabricaComandos fabricaCo = new FabricaComandos();
           Comando<List<Entidad>> comboTipoPlanilla = fabricaCo.ObtenerComandoObtenerTipoPlanilla();
           List<Entidad> listPlanilla = new List<Entidad>();
           Dictionary<string, string> options = new Dictionary<string, string>();
           try
           {
              // listPlanilla = lP.ObtenerTipoPlanilla();
               listPlanilla = comboTipoPlanilla.Ejecutar();

               //mostrar el primer lugar el tipo de planilla actual
               foreach (Planilla item2 in listPlanilla)
               {
                   if (tipoPlanilla == item2.TipoPlanilla)
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

           vista.tipoPlanillaCombo.DataSource = options;
           vista.tipoPlanillaCombo.DataTextField = "value";
           vista.tipoPlanillaCombo.DataValueField = "key";
           vista.tipoPlanillaCombo.DataBind();
       }

       public void NombreTipoPVisible()
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

       public bool EditarPlanilla()
       {
           List<String> listDatos = new List<String>();
          // Planilla laPlanilla = null;
           ListItemCollection listItem = vista.datosPlanilla2.Items;
           String TipoPlanilla = "";
           FabricaEntidades fabricaEntidades = new FabricaEntidades();
           FabricaComandos fabricaComandos = new FabricaComandos();
           Comando<Boolean> comandoTipoPlanilla = fabricaComandos.ObtenerComandoNuevoTipoPlanilla();
           Comando<Entidad> comandoModificarPlanillaID = fabricaComandos.ObtenerComandoModificarPlanillaID();
           Comando<Entidad> comandoModificarPlanillaIDTipo = fabricaComandos.ObtenerComandoModificarPlanillaIDTipo();
           bool respuesta = false;

         //  LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();

           try
           {
               foreach (var item in listItem)
               {
                   listDatos.Add(item.ToString());

               }

           /*    laPlanilla = new Planilla(Int32.Parse(this.id_planilla.Value), this.id_nombrePlanilla.Value, true,
                                                  Int32.Parse(this.comboTipoPlanilla.SelectedValue),
                                                  listDatos);*/
               Entidad laPlanilla = new Planilla(Int32.Parse(vista.planillaId), vista.nombrePlanilla, true,
                                                  Int32.Parse(vista.tipoPlanillaCombo.SelectedValue),
                                                  listDatos);

               if (vista.tipoPlanillaCombo.SelectedValue != "-1")
               {
                   if (vista.nombrePlanilla != "")
                   {
                       if (vista.datosPlanilla2.Items.Count> 0)
                       {
                           if (vista.tipoPlanillaCombo.SelectedValue == "-2")
                           {
                               if (vista.nombreTipo != "")
                               {
                                   TipoPlanilla = vista.nombreTipo;
                                 //  lP.NuevoTipoPlanilla(TipoPlanilla);
                                   ((ComandoNuevoTipoPlanilla)comandoTipoPlanilla).NombreTipo = TipoPlanilla;
                                   comandoTipoPlanilla.Ejecutar();
                                   //lP.ModificarPlanillaID(laPlanilla, TipoPlanilla);
                                   ((ComandoModificarPlanillaIDTipo)comandoModificarPlanillaIDTipo).LaEntidad = laPlanilla;
                                   ((ComandoModificarPlanillaIDTipo)comandoModificarPlanillaIDTipo).TipoPlanilla = TipoPlanilla;
                                    //comandoModificarPlanillaID.Ejecutar();
                                   comandoModificarPlanillaIDTipo.Ejecutar();
                                   respuesta = true;
                                   //Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
                                                                 
                               }
                               else
                               {
                                   vista.alertLocalClase = RecursosPresentadorModulo14.Alerta_Clase_Error;
                                   vista.alertLocalRol = RecursosPresentadorModulo14.Alerta_Rol;
                                   vista.alertLocal = RecursosPresentadorModulo14.Alerta_Html + RecursosPresentadorModulo14.Alerta_NombreTipoVacio + RecursosPresentadorModulo14.Alerta_HtmlFinal;
                                   vista.alerta = true;
                                   respuesta = false;
                               }
                           }
                           else
                           {
                               ((ComandoModificarPlanillaID)comandoModificarPlanillaID).LaEntidad = laPlanilla;
                               comandoModificarPlanillaID.Ejecutar();
                               respuesta = true;
                               //lP.ModificarPlanillaID(laPlanilla);
                               //Response.Redirect("../Modulo14/M14_ConsultarPlanillas.aspx?success=true");
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
           catch (Exception ex)
           {
               Alerta(ex.Message);
           }
           return respuesta;
       }

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
           catch (Exception ex)
           {
               Alerta(ex.Message);
           }
       }

       public void QuitarDatos()
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
           catch (Exception ex)
           {
               Alerta(ex.Message);
           }
       }

       public void PageLoadModificarPlanilla()
       {
           try
           {
              Entidad laPlanilla;
              // int idPlanilla = Int32.Parse(Request.QueryString[RecursoInterfazModulo14.idPlan]);
               int idPlanilla = vista.IDPlanillaModificar;
               vista.IDPlanillaModificarVisible = false;
               vista.id_otroTipo = false;
               vista.planillaId = idPlanilla.ToString();

            //   LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
              // laPlanilla = lP.ObtenerPlanillaID(idPlanilla);
               FabricaComandos fabricaCo = new FabricaComandos();
               Comando<Entidad> comandoObtenerPlanillaID = fabricaCo.ObtenerComandoObtenerPlanillaID();
               ((ComandoObtenerPlanillaID)comandoObtenerPlanillaID).IdPlanilla = idPlanilla;
               laPlanilla = comandoObtenerPlanillaID.Ejecutar();
               vista.nombrePlanilla = ((Planilla)laPlanilla).Nombre;

               LlenarTipoPlanillaCombo(((Planilla)laPlanilla).TipoPlanilla);

               foreach (String item in ((Planilla)laPlanilla).Dato)
               {
                  vista.datosPlanilla2.Items.Add(new ListItem(item, item));
                  vista.datosPlanilla1.Items.Remove(item);
                   if (item == "EVENTO")
                   {
                       vista.datosPlanilla1.Items.Remove("COMPETENCIA");
                   }
                   if (item == "COMPETENCIA")
                   {
                       vista.datosPlanilla1.Items.Remove("EVENTO");
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
    }
}
