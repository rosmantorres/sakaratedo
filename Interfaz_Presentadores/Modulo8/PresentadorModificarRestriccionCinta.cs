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

namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorModificarRestriccionCinta
    {
        private IContratoModificarRestriccionCinta vista;

        ValidacionesM8 validarCampos = new ValidacionesM8();

        public PresentadorModificarRestriccionCinta(IContratoModificarRestriccionCinta laVista)
        {
          
            this.vista = laVista;
            
        }     

        public DominioSKD.Entidades.Modulo8.RestriccionCinta meterParametrosVistaEnObjeto(DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccion)
        {
            try 
            { 
                DominioSKD.Entidades.Modulo8.RestriccionCinta retriccionCinta = laRestriccion;
                retriccionCinta.IdRestriccionCinta = int.Parse(vista.id_restriccion);
                retriccionCinta.PuntosMinimos = int.Parse(vista.puntaje_min);
                retriccionCinta.TiempoDocente = int.Parse(vista.horas_docen);
                retriccionCinta.TiempoMinimo = int.Parse(vista.tiempo_Min);
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

        public Boolean ModificarRest()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();

            laRestCinta = meterParametrosVistaEnObjeto(laRestCinta);
  
            try 
            {
                List<String> campos = new List<String>();
                campos.Add(vista.horas_docen);
                campos.Add(vista.puntaje_min);
                campos.Add(vista.tiempo_Min);

                if (validarCampos.ValidarCamposVacios(campos))
                {
                    if (validarCampos.ValidarCaracteres(vista.horas_docen) &&
                        validarCampos.ValidarCaracteres(vista.puntaje_min) &&
                        validarCampos.ValidarCaracteres(vista.tiempo_Min))
                    {
                        laRestCinta = meterParametrosVistaEnObjeto(laRestCinta);
                        LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCinta _comando =
                     (LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCinta)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoModificarRestriccionCinta(laRestCinta);
                        bool resultado = _comando.Ejecutar();
                        return resultado;
                    }
                    else
                        return false;
                }
                else
                    return false;

            }
            catch (SqlException ex)
            {
                Alerta(ex.Message);
                return false;
            }
            catch (FormatException ex)
            {
                Alerta(RecursoPresentadorM8.ErrordeFformato);
                return false;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                Alerta(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Alerta(RecursoPresentadorM8.general);
                return false;
            }
        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alerta = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
           
        }

    }
}
