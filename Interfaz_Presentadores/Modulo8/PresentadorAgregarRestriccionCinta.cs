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
using System.Text.RegularExpressions;
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
            retriccionCinta.Descripcion = generarDescripcion();
            retriccionCinta.PuntosMinimos = int.Parse(vista.puntaje_min);
            retriccionCinta.TiempoDocente = int.Parse(vista.horas_docen);
            retriccionCinta.TiempoMinimo = int.Parse(vista.tiempo_Min);
            retriccionCinta.TiempoMaximo = int.Parse(vista.tiempo_Max);
            //generarDescripcion();
            return retriccionCinta;
            
        }
        
        public string generarDescripcion()
        {
          string Descripcion = ("Cinta: " + vista.comboRestCinta.SelectedItem.ToString()
                                     + " Puntaje Minimo: " + vista.puntaje_min.ToString()
                                     + " Tiempo Minimo: " + vista.tiempo_Min.ToString()
                                     + " Tiempo Maximo: " + vista.tiempo_Max.ToString()
                                     + " Horas Docentes: " + vista.horas_docen.ToString());
           return Descripcion;

        }

        public void LlenarComboCinta()
        {
            FabricaComandos fabricaCo = new FabricaComandos();
            Comando<List<Entidad>> comboCinta = fabricaCo.CrearComandoConsultarCintaTodas();
            List<Entidad> listCinta = new List<Entidad>();
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una opcion");
            try
            {
                listCinta = comboCinta.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo5.Cinta item in listCinta)
                {
                    options.Add(item.Id_cinta.ToString(), item.Color_nombre);
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
            vista.comboRestCinta.DataSource = options;
            vista.comboRestCinta.DataTextField = "value";
            vista.comboRestCinta.DataValueField = "key";
            vista.comboRestCinta.DataBind();

        }

        public Boolean agregarRest()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();

            laRestCinta = meterParametrosVistaEnObjeto(laRestCinta);
            /*laRestCinta.Descripcion = this.vista.descripcion_rest_cinta;
            laRestCinta.Id = Int32.Parse(this.vista.comboRestCinta.SelectedValue);
            laRestCinta.PuntosMinimos = Int32.Parse(this.vista.puntaje_min);
            laRestCinta.TiempoDocente = Int32.Parse(this.vista.horas_docen);
            laRestCinta.TiempoMaximo = Int32.Parse(this.vista.tiempo_Max);
            laRestCinta.TiempoMinimo = Int32.Parse(this.vista.tiempo_Min);*/


            FabricaComandos _fabrica = new FabricaComandos();
            Comando<bool> _comando = _fabrica.CrearComandoAgregarRestriccionCinta(laRestCinta);
            bool resultado = _comando.Ejecutar();
            return resultado;
        }

        public void Alerta(string msj)
        {
            //vista.alertLocalClase = RecursoPresentadorM8.Alerta_Clase_Error;
            //vista.alertLocalRol = RecursoPresentadorM8.Alerta_Rol;
            vista.alertLocal = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

    }
}

