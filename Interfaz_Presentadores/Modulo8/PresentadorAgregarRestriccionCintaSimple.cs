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
    public class PresentadorAgregarRestriccionCintaSimple
    {
        private IContratoAgregarRestriccionCinta vista;

        public PresentadorAgregarRestriccionCintaSimple(IContratoAgregarRestriccionCinta laVista)
        {
          
            this.vista = laVista;
            
        }          

        public DominioSKD.Entidades.Modulo8.RestriccionCinta meterParametrosVistaEnObjeto(DominioSKD.Entidades.Modulo8.RestriccionCinta laRestriccion)
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta retriccionCinta = laRestriccion;
            retriccionCinta.Descripcion = generarDescripcion();
            retriccionCinta.PuntosMinimos = int.Parse(vista.puntaje_min);
            retriccionCinta.TiempoDocente = int.Parse(vista.horas_docen);
            retriccionCinta.TiempoMinimo = int.Parse(vista.tiempo_Min);
            retriccionCinta.TiempoMaximo = int.Parse(vista.tiempo_Max);
            retriccionCinta.Status = 0;
            return retriccionCinta;
            
        }
        
        public string generarDescripcion()
        {
          string Descripcion = (" Puntaje Minimo: " + vista.puntaje_min.ToString() + ","
                                + " Tiempo Minimo: " + vista.tiempo_Min.ToString() + ","
                                + " Tiempo Maximo: " + vista.tiempo_Max.ToString() + ","
                                + " Horas Docentes: " + vista.horas_docen.ToString());
           return Descripcion;

        }

        public Boolean agregarRest()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCinta laRestCinta = new DominioSKD.Entidades.Modulo8.RestriccionCinta();
            try
            {
                laRestCinta = meterParametrosVistaEnObjeto(laRestCinta);
                LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCintaSimple _comando =
                    (LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCintaSimple)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoAgregarRestriccionCintaSimple(laRestCinta);
                bool resultado = _comando.Ejecutar();
                return resultado;
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

