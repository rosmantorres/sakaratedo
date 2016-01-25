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

        public void agregarRest()
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
        }

        public void Alerta(string msj)
        {
            //vista.alertLocalClase = RecursoPresentadorM8.Alerta_Clase_Error;
            //vista.alertLocalRol = RecursoPresentadorM8.Alerta_Rol;
            vista.alertLocal = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }


    }
}
