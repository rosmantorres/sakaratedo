using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo8;
using ExcepcionesSKD.Modulo8;
using System.Data.SqlClient;
using ExcepcionesSKD;
using System.Web;
//using System.Windows;


namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorAgregarRestriccionCompetencia
    {
        private IContratoAgregarRestriccionCompetencia vista;
        
        public Boolean agregarRestriccionCompetencia()
        {
            Boolean resultado = false;
            try
            {
                DominioSKD.Entidad elObjeto = meterParametrosVistaEnObjeto();
                LogicaNegociosSKD.Fabrica.FabricaComandos fabrica = new LogicaNegociosSKD.Fabrica.FabricaComandos();
                DominioSKD.Fabrica.FabricaEntidades fabricaEntidad = new DominioSKD.Fabrica.FabricaEntidades();
                LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCompetencia comando =
                (LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarRestriccionCompetencia)LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoAgregarRestriccionCompetencia();
                DominioSKD.Entidades.Modulo8.RestriccionCompetencia restriccionCompetencia = (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionCompetencia();
                restriccionCompetencia = meterParametrosVistaEnObjeto();
                comando.Parametro = restriccionCompetencia;
                resultado = comando.Ejecutar();
                if (resultado == true)
                    HttpContext.Current.Response.Redirect(RecursoPresentadorM8.AgregarExitoRestriccionCompetencia);


            }
            catch (RestriccionExistenteException ex)
            {

                Alerta(ex.Message);
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
            catch (ExceptionSKDConexionBD ex)
            {

                Alerta(ex.Message);
                return false;


            }
            catch (Exception ex)
            {
                Alerta(ex.Message);
                return false;

            }
            return resultado;
        }

        public Boolean validarCampos()
        {
            Boolean resultado = false;

            if (int.Parse(vista.edadMinima.SelectedValue.ToString()) <= int.Parse(vista.edadMaxima.SelectedValue.ToString()) &&
                int.Parse(vista.rangoMinimo.SelectedValue.ToString()) <= int.Parse(vista.rangoMaximo.SelectedValue.ToString()) &&
                ("M".Equals(vista.sexo.SelectedValue.ToString()) || "F".Equals(vista.sexo.SelectedValue.ToString()) || "B".Equals(vista.sexo.SelectedValue.ToString())) &&
                ("kata".Equals(vista.sexo.SelectedValue.ToString()) || "kumite".Equals(vista.sexo.SelectedValue.ToString()) || "todas".Equals(vista.sexo.SelectedValue.ToString())))
                resultado = true;

            return resultado;
        }
        
        public PresentadorAgregarRestriccionCompetencia(IContratoAgregarRestriccionCompetencia laVista)
        {

            this.vista = laVista;

        }
        
        public DominioSKD.Entidades.Modulo8.RestriccionCompetencia meterParametrosVistaEnObjeto()
        {
            try
            {
                DominioSKD.Fabrica.FabricaEntidades fabrica = new DominioSKD.Fabrica.FabricaEntidades();
                DominioSKD.Entidades.Modulo8.RestriccionCompetencia restriccionCompetencia = (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)DominioSKD.Fabrica.FabricaEntidades.ObtenerRestriccionCompetencia();
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
        
        public void LlenarComboRangos()
        {
            int index;
            vista.rangoMinimo.Enabled = true;
            vista.rangoMaximo.Enabled = true;
            Dictionary<string, int> optionsRangos = new Dictionary<string, int>();

            for (index = 0; index <= 20; index++)
            {
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

        public void generarDescripcion()
        {
            this.vista.descripcion = ("Edad Min: " + vista.edadMinima.SelectedValue.ToString()
                                     + " Edad Max: " + vista.edadMaxima.SelectedValue.ToString()
                                     + " Rango Min: " + vista.rangoMinimo.SelectedValue.ToString()
                                     + " Rango Max: " + vista.rangoMaximo.SelectedValue.ToString()
                                     + " Sexo: " + vista.sexo.SelectedValue.ToString()
                                     + " Modalidad: " + vista.modalidad.SelectedValue.ToString());

        }

        public void Alerta(string msj)
        {
            vista.alertaClase = "alert alert-danger alert-dismissible";
            vista.alertaRol = "alert";
            vista.alert = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + msj + "</div>";
        }


    }
}

