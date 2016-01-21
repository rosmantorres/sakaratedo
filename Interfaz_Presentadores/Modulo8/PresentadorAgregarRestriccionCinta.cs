using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using LogicaNegociosSKD.Comandos.Modulo8;
using LogicaNegociosSKD.Fabrica;
using LogicaNegociosSKD;
using DominioSKD;
//using System.Windows;


namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorAgregarRestriccionCinta
    {
        private IContratoAgregarRestriccionCinta vista;

        public PresentadorAgregarRestriccionCinta(IContratoAgregarRestriccionCinta laVista)
        {
          
            this.vista = laVista;
            
        }          

        public DominioSKD.Entidades.Modulo8.RestriccionCinta meterParametrosVistaEnObjeto(DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccion)
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta retriccionCinta = laRestriccion;
            retriccionCinta.Id = int.Parse(vista.comboRestCinta.SelectedValue);
            retriccionCinta.Descripcion = vista.descripcion_rest_cinta.ToString();
            retriccionCinta.PuntosMinimos = int.Parse(vista.puntaje_min);
            retriccionCinta.TiempoDocente = int.Parse(vista.horas_docen);
            retriccionCinta.TiempoMinimo = int.Parse(vista.tiempo_Min);
            retriccionCinta.TiempoMaximo = int.Parse(vista.tiempo_Max);
            //generarDescripcion();
            return retriccionCinta;
            
        }
        
        public void generarDescripcion()
        {
           /* this.vista.descripcion = ("Edad Min: " + vista.edadMinima.SelectedValue.ToString()
                                     + " Edad Max: " + vista.edadMaxima.SelectedValue.ToString()
                                     + " Rango Min: " + vista.rangoMinimo.SelectedValue.ToString()
                                     + " Rango Max: " + vista.rangoMaximo.SelectedValue.ToString()
                                     + " Sexo: " + vista.sexo.SelectedValue.ToString()
                                     + " Modalidad: " + vista.sexo.SelectedValue.ToString());*/

        }

       /* public void LlenarComboTipoPlanilla()
        {
            FabricaComandos fabricaCo = new FabricaComandos();
            //Comando<List<Entidad>> comboCinta = fabricaCo();
            //LogicaNegociosSKD.Modulo14.LogicaPlanilla lP = new LogicaNegociosSKD.Modulo14.LogicaPlanilla();
            List<Entidad> listCinta = new List<Entidad>();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            try
            {
                listCinta = comboCinta.Ejecutar();
                foreach (Planilla item in listCinta)
                {
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

        }*/
    

    }
}

