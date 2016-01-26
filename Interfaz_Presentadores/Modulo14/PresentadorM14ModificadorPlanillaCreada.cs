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
       /// <summary>
       /// Llenar el combobox con los tipos de planillas existentes.
       /// </summary>
       public void LlenarTipoPlanillaCombo(String tipoPlanilla)
       {
          
           Comando<List<Entidad>> comboTipoPlanilla = FabricaComandos.ObtenerComandoObtenerTipoPlanilla();
           List<Entidad> listPlanilla = new List<Entidad>();
           Dictionary<string, string> options = new Dictionary<string, string>();
           try
           {
               listPlanilla = comboTipoPlanilla.Ejecutar();

               //mostrar el primer lugar el tipo de planilla actual
               foreach (DominioSKD.Entidades.Modulo14.Planilla item2 in listPlanilla)
               {
                   if (tipoPlanilla == item2.TipoPlanilla)
                       options.Add(item2.IDtipoPlanilla.ToString(), item2.TipoPlanilla);
               }
               //mostrar los tipos de planilla menos el actual
               foreach (DominioSKD.Entidades.Modulo14.Planilla item in listPlanilla)
               {
                   if (tipoPlanilla != item.TipoPlanilla)
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
       /// Permite que el sea visible el nombre de tipo planilla.
       /// </summary>
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
       /// <summary>
       /// Modifica el registro de una planilla con los datos que se cambiaron.
       /// </summary>
       /// <returns>verdadero si se logro modificar con exito la planilla</returns>>
       public bool EditarPlanilla()
       {
           List<String> listDatos = new List<String>();
          
           ListItemCollection listItem = vista.datosPlanilla2.Items;
           String TipoPlanilla = "";
           FabricaEntidades fabricaEntidades = new FabricaEntidades();
           Comando<Boolean> comandoTipoPlanilla = FabricaComandos.ObtenerComandoNuevoTipoPlanilla();
           Comando<Entidad> comandoModificarPlanillaID = FabricaComandos.ObtenerComandoModificarPlanillaID();
           Comando<Entidad> comandoModificarPlanillaIDTipo = FabricaComandos.ObtenerComandoModificarPlanillaIDTipo();
           bool respuesta = false;

       
           try
           {
               foreach (var item in listItem)
               {
                   listDatos.Add(item.ToString());

               }

               Entidad laPlanilla = new DominioSKD.Entidades.Modulo14.Planilla(Int32.Parse(vista.planillaId), vista.nombrePlanilla, true,
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
                            
                                   ((ComandoNuevoTipoPlanilla)comandoTipoPlanilla).NombreTipo = TipoPlanilla;
                                   comandoTipoPlanilla.Ejecutar();
                               
                                   ((ComandoModificarPlanillaIDTipo)comandoModificarPlanillaIDTipo).LaEntidad = laPlanilla;
                                   ((ComandoModificarPlanillaIDTipo)comandoModificarPlanillaIDTipo).TipoPlanilla = TipoPlanilla;
                                 
                                   comandoModificarPlanillaIDTipo.Ejecutar();
                                   respuesta = true;
                                                           
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
       /// <summary>
       /// Agrega los datos requeridos de la lista.
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
           catch (Exception ex)
           {
               Alerta(ex.Message);
           }
       }
       /// <summary>
       /// Quitar los datos requeridos de la lista.
       /// </summary>
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
       /// <summary>
       /// Cargar la pantalla de modificar la planilla
       /// </summary>
       public void PageLoadModificarPlanilla()
       {
           try
           {
              Entidad laPlanilla;
         
               int idPlanilla = vista.IDPlanillaModificar;
               vista.IDPlanillaModificarVisible = false;
               vista.id_otroTipo = false;
               vista.planillaId = idPlanilla.ToString();

       
               Comando<Entidad> comandoObtenerPlanillaID = FabricaComandos.ObtenerComandoObtenerPlanillaID();
               ((ComandoObtenerPlanillaID)comandoObtenerPlanillaID).IdPlanilla = idPlanilla;
               laPlanilla = comandoObtenerPlanillaID.Ejecutar();
               vista.nombrePlanilla = ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).Nombre;

               LlenarTipoPlanillaCombo(((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).TipoPlanilla);

               foreach (String item in ((DominioSKD.Entidades.Modulo14.Planilla)laPlanilla).Dato)
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
