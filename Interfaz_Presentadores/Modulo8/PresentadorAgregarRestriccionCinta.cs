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
using System.Data.SqlClient;
//using System.Windows;


namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorAgregarRestriccionCinta
    {
        private IContratoAgregarRestriccionCinta vista;
        ValidacionesM8 validarCampos = new ValidacionesM8();

        public PresentadorAgregarRestriccionCinta(IContratoAgregarRestriccionCinta laVista)
        {
          
            this.vista = laVista;
            
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }

        public DominioSKD.Entidades.Modulo8.RestriccionCinta meterParametrosVistaEnObjeto(DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccion)
        {
            try
            {
                DominioSKD.Entidades.Modulo8.RestriccionCinta retriccionCinta = laRestriccion;
                retriccionCinta.Id = int.Parse(vista.comboRestCinta.SelectedValue);
                retriccionCinta.Descripcion = generarDescripcion();
                retriccionCinta.PuntosMinimos = int.Parse(vista.puntaje_min);
                retriccionCinta.TiempoDocente = int.Parse(vista.horas_docen);
                retriccionCinta.TiempoMinimo = int.Parse(vista.tiempo_Min);
                retriccionCinta.TiempoMaximo = int.Parse(vista.tiempo_Max);
                retriccionCinta.Status = 1;
                return retriccionCinta;
            }
            catch (SqlException ex)
            {
                Alerta(ex.Message);
                return null;
            }
            catch (FormatException ex)
            {
                Alerta(RecursoPresentadorM8.CampoVacio);
                return null;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Alerta(RecursoPresentadorM8.general);
                return null;
            }
            
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
            Dictionary<string, string> options = new Dictionary<string, string>();
            try
            {
                LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCintaTodas comboCinta =
                   (LogicaNegociosSKD.Comandos.Modulo8.ComandoConsultarCintaTodas)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarCintaTodas();
                List<Entidad> listCinta = new List<Entidad>();
                options.Add("-1", "Selecciona una opcion");
                listCinta = comboCinta.Ejecutar();
                foreach (DominioSKD.Entidades.Modulo5.Cinta item in listCinta)
                {
                    options.Add(item.Id_cinta.ToString(), item.Color_nombre);
                }
                options.Add("-2", "OTRO");
            }
            catch (ExcepcionesSKD.Modulo8.RestriccionRepetidaException ex)
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
            vista.comboRestCinta.DataSource = options;
            vista.comboRestCinta.DataTextField = "value";
            vista.comboRestCinta.DataValueField = "key";
            vista.comboRestCinta.DataBind();

        }

        public Boolean agregarRest()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();
            try
            {
                List<String> campos = new List<String>();
                campos.Add(vista.horas_docen);
                campos.Add(vista.puntaje_min);
                campos.Add(vista.tiempo_Max);
                campos.Add(vista.tiempo_Min);

                if (validarCampos.ValidarCamposVacios(campos))
                {
                    if (validarCampos.ValidarCaracteres(vista.horas_docen) &&
                        validarCampos.ValidarCaracteres(vista.puntaje_min) &&
                        validarCampos.ValidarCaracteres(vista.tiempo_Max) &&
                        validarCampos.ValidarCaracteres(vista.tiempo_Min))
                    {
                        laRestCinta = meterParametrosVistaEnObjeto(laRestCinta);
                        LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCinta _comando =
                        (LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCinta)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoAgregarRestriccionCinta(laRestCinta);
                        bool resultado = _comando.Ejecutar();
                        return resultado;
                    }
                    else
                        Alerta(RecursoPresentadorM8.CaracterInvalido);
                        return false;
                }
                else
                    Alerta(RecursoPresentadorM8.CampoVacio);
                    return false;
            }
            
            catch (SqlException ex)
            {
                Alerta(ex.Message);
                return false;
            }
            catch (FormatException ex)
            {
                Alerta(ex.Message);
                return false;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
                return false;  
            }
            catch (Exception ex)
            {

                Alerta(ex.Message);
                return false;
            }
        }
                        
            }
           
        }


