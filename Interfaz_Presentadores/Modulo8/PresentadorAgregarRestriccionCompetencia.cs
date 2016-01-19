using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Interfaz_Contratos.Modulo8;
//using System.Windows;


namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorAgregarRestriccionCompetencia
    {
        private IContratoAgregarRestriccionCompetencia vista;
        
        public PresentadorAgregarRestriccionCompetencia(IContratoAgregarRestriccionCompetencia laVista)
        {
          
            this.vista = laVista;
            
        }

        public void LlenarListaCompetenciasNoAsociadas()
        {
            LogicaNegociosSKD.Comando<List<DominioSKD.Entidad>> consultarCompetencias =
            LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarCompetencias();
            List<DominioSKD.Entidad> listaEntidades = consultarCompetencias.Ejecutar();
            List<DominioSKD.Entidades.Modulo12.Competencia> listaCompetencias = listaEntidades.Cast<DominioSKD.Entidades.Modulo12.Competencia>().ToList();
            
            //foreach (DominioSKD.Entidad entidad in listaEntidades)
            //{
            //    listaCompetencias.Add = ((DominioSKD.Entidades.Modulo12.Competencia)entidad);
            //}
            
            vista.competeciasNoRelacionadas.Enabled = true;
            vista.competeciasNoRelacionadas.DataTextField = "nombre";
            
            vista.competeciasNoRelacionadas.DataSource = listaCompetencias;
            vista.competeciasNoRelacionadas.DataBind();
            //foreach (DominioSKD.Entidad competencia in listaCompetencias)
            //{
               
            //    vista.competeciasNoRelacionadas.Items.Add = (DominioSKD.Entidades.Modulo12.Competencia)competencia;
            
            //}
        }


        public void agregarListaCompetenciasAsociadas ()
        {

            //LogicaNegociosSKD.Comando<Boolean> objetoComando = 
            //LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoAgregarListaCompetenciaRestriccionCompetencia();


            
            LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarListaCompetenciaRestriccionCompetencia comando =
            (LogicaNegociosSKD.Comandos.Modulo8.ComandoAgregarListaCompetenciaRestriccionCompetencia)objetoComando;
            
            DominioSKD.Fabrica.FabricaEntidades fabrica = new  DominioSKD.Fabrica.FabricaEntidades();
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia restComp = (DominioSKD.Entidades.Modulo8.RestriccionCompetencia)fabrica.ObtenerRestriccionCompetencia();

            comando.LaRestriccionCompetencia

        }

        public DominioSKD.Entidades.Modulo8.RestriccionCompetencia meterParametrosVistaEnObjeto(DominioSKD.Entidades.Modulo8.RestriccionCompetencia laRestriccion)
        {
            DominioSKD.Entidades.Modulo8.RestriccionCompetencia retriccionCompetencia = laRestriccion;
            retriccionCompetencia.EdadMinima = int.Parse(vista.edadMinima.SelectedValue);
            retriccionCompetencia.EdadMaxima = int.Parse(vista.edadMaxima.SelectedValue);
            retriccionCompetencia.RangoMinimo = int.Parse(vista.rangoMinimo.SelectedValue);
            retriccionCompetencia.RangoMaximo = int.Parse(vista.rangoMaximo.SelectedValue);
            retriccionCompetencia.Sexo = vista.sexo.SelectedValue;
            retriccionCompetencia.Modalidad = vista.modalidad.SelectedValue;
            generarDescripcion();
            retriccionCompetencia.Descripcion = vista.descripcion;
            return retriccionCompetencia;
            
        }
        //public void llenarComboRangos()
        //{
        //    int index;
        //    vista.rangoMinimo.Enabled = true;
        //    vista.rangoMaximo.Enabled = true;
            
        //    for (index=0;index<=20;index++)
        //    {
        //        vista.rangoMinimo.Items.Add(index.ToString());
                
        //        vista.rangoMaximo.Items.Add(index.ToString());
            
        //    }

        //}

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

        public void generarDescripcion()
        {
            this.vista.descripcion = ("Edad Min: " + vista.edadMinima.SelectedValue.ToString()
                                     + " Edad Max: " + vista.edadMaxima.SelectedValue.ToString()
                                     + " Rango Min: " + vista.rangoMinimo.SelectedValue.ToString()
                                     + " Rango Max: " + vista.rangoMaximo.SelectedValue.ToString()
                                     + " Sexo: " + vista.sexo.SelectedValue.ToString()
                                     + " Modalidad: " + vista.sexo.SelectedValue.ToString());

        }
    

    }
}

