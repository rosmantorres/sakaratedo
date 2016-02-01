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
            DominioSKD.Entidades.Modulo8.RestriccionCinta retriccionCinta = laRestriccion;
            retriccionCinta.IdRestriccionCinta = int.Parse(vista.id_restriccion);
            retriccionCinta.PuntosMinimos = int.Parse(vista.puntaje_min);
            retriccionCinta.TiempoDocente = int.Parse(vista.horas_docen);
            retriccionCinta.TiempoMinimo = int.Parse(vista.tiempo_Min);
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
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (ExcepcionesSKD.ExceptionSKDConexionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alerta(string msj)
        {
            //vista.alertLocalClase = RecursoPresentadorM8.Alerta_Clase_Error;
            //vista.alertLocalRol = RecursoPresentadorM8.Alerta_Rol;
            vista.alertLocal = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }


    }
}
