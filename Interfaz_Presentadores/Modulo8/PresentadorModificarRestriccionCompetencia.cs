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
    public class PresentadorModificarRestriccionCompetencia
    {
        private IContratoModificarRestriccionCompetencia vista;

        public PresentadorModificarRestriccionCompetencia(IContratoModificarRestriccionCompetencia laVista)
        {

            this.vista = laVista;

        }

        public void generarDescripcion()
        {
            this.vista.descripcion = ("Edad Min: " + vista.edadMinima.SelectedValue.ToString()
                                      + " Edad Max: " + vista.edadMaxima.SelectedValue.ToString()
                                      + " Rango Min: " + vista.rangoMinimo.SelectedValue.ToString()
                                      + " Rango Max: " + vista.rangoMaximo.SelectedValue.ToString()
                                      + " Sexo: " + vista.sexo.SelectedValue.ToString()
                                      + " Modalidad: " + vista.sexo.SelectedValue.ToString());

        }

        public DominioSKD.Entidades.Modulo8.RestriccionCompetencia meterParametrosVistaEnObjeto()
        {
            DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia restriccionCompetencia = (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)fabrica.ObtenerRestriccionCompetencia();
            restriccionCompetencia.Id = int.Parse(vista.id);
            restriccionCompetencia.IdRestriccionComp = int.Parse(vista.id);
            restriccionCompetencia.EdadMinima = int.Parse(vista.edadMinima.SelectedValue);
            restriccionCompetencia.EdadMaxima = int.Parse(vista.edadMaxima.SelectedValue);
            restriccionCompetencia.RangoMinimo = int.Parse(vista.rangoMinimo.SelectedValue);
            restriccionCompetencia.RangoMaximo = int.Parse(vista.rangoMaximo.SelectedValue);
            restriccionCompetencia.Sexo = vista.sexo.SelectedValue;
            restriccionCompetencia.Modalidad = vista.modalidad.SelectedValue;
            generarDescripcion();
            restriccionCompetencia.Descripcion = vista.descripcion;
            return restriccionCompetencia;

        }
        public void ModificarRest()
        {
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestCompetencia = new DominioSKD.Entidades.Modulo8.RestriccionCompetencia();

            laRestCompetencia = meterParametrosVistaEnObjeto();
            /*laRestCinta.Descripcion = this.vista.descripcion_rest_cinta;
            laRestCinta.Id = Int32.Parse(this.vista.comboRestCinta.SelectedValue);
            laRestCinta.PuntosMinimos = Int32.Parse(this.vista.puntaje_min);
            laRestCinta.TiempoDocente = Int32.Parse(this.vista.horas_docen);
            laRestCinta.TiempoMaximo = Int32.Parse(this.vista.tiempo_Max);
            laRestCinta.TiempoMinimo = Int32.Parse(this.vista.tiempo_Min);*/

            FabricaEntidades fabricaEnt = new FabricaEntidades();
            FabricaComandos _fabrica = new FabricaComandos();
            LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCompetencia _comando =
                    (LogicaNegociosSKD.Comandos.Modulo8.ComandoModificarRestriccionCompetencia)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoModificarRestriccionCompetencia();

            _comando.Parametro = laRestCompetencia;
            bool resultado = _comando.Ejecutar();
        }

        public void LlenarComboRangos()
        {
            int index;
            vista.rangoMinimo.Enabled = true;
            vista.rangoMaximo.Enabled = true;
            Dictionary<string, int> optionsRangos = new Dictionary<string, int>();

            for (index = 0; index <= 20; index++)
            {
                //vista.rangoMinimo.Items.Add(index.ToString());

                //vista.rangoMaximo.Items.Add(index.ToString());

                optionsRangos.Add(index.ToString(), index);


            }

            vista.rangoMinimo.DataSource = optionsRangos;
            vista.rangoMaximo.DataSource = optionsRangos;
            vista.rangoMinimo.DataTextField = "key";
            vista.rangoMinimo.DataValueField = "value";
            vista.rangoMaximo.DataTextField = "key";
            vista.rangoMaximo.DataValueField = "value";
            vista.rangoMinimo.DataBind();
            vista.rangoMaximo.DataBind();

        }

        public void LlenarComboEdades()
        {
            int index;
            vista.edadMinima.Enabled = true;
            vista.edadMaxima.Enabled = true;
            Dictionary<string, int> optionsEdad = new Dictionary<string, int>();

            for (index = 4; index <= 65; index++)
            {
                optionsEdad.Add(index.ToString(), index);
            }

            vista.edadMinima.DataSource = optionsEdad;
            vista.edadMaxima.DataSource = optionsEdad;
            vista.edadMinima.DataTextField = "key";
            vista.edadMinima.DataValueField = "value";
            vista.edadMaxima.DataTextField = "key";
            vista.edadMaxima.DataValueField = "value";
            vista.edadMinima.DataBind();
            vista.edadMaxima.DataBind();
        }

        public void LlenarComboSexo()
        {
            vista.sexo.Enabled = true;
            Dictionary<string, string> optionsSexo = new Dictionary<string, string>();
            optionsSexo.Add("Masculino", "M");
            optionsSexo.Add("Femenino", "F");
            optionsSexo.Add("Ambos Sexos", "B");
            vista.sexo.DataSource = optionsSexo;
            vista.sexo.DataTextField = "key";
            vista.sexo.DataValueField = "value";
            vista.sexo.DataBind();
        }


        public void LlenarComboModalidad()
        {
            vista.modalidad.Enabled = true;
            Dictionary<string, string> optionsModalidad = new Dictionary<string, string>();
            optionsModalidad.Add("Kata", "kata");
            optionsModalidad.Add("Kumite", "kumite");
            optionsModalidad.Add("Ambas", "todas");
            vista.modalidad.DataSource = optionsModalidad;
            vista.modalidad.DataTextField = "key";
            vista.modalidad.DataValueField = "value";
            vista.modalidad.DataBind();
        }

    }
}
