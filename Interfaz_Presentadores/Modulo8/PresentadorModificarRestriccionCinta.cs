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

        public void ModificarRest()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();

            laRestCinta = meterParametrosVistaEnObjeto(laRestCinta);
  
            try 
            { 
            FabricaComandos _fabrica = new FabricaComandos();
            Comando<bool> _comando = _fabrica.CrearComandoModificarRestriccionCinta(laRestCinta);
            bool resultado = _comando.Ejecutar();
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
