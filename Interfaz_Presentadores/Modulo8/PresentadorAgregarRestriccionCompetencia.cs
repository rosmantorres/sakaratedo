using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Interfaz_Contratos.Modulo8;
using System.Windows.Forms;


namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorAgregarRestriccionCompetencia
    {
        private IContratoAgregarRestriccionCompetencia vista;
        
        public PresentadorAgregarRestriccionCompetencia(IContratoAgregarRestriccionCompetencia laVista)
        {
          
            this.vista = laVista;
            
        }

        public void llenarListaCompetenciasNoAsociadas()
        {
            LogicaNegociosSKD.Comando<List<DominioSKD.Entidad>> consultarCompetencias = LogicaNegociosSKD.Fabrica.FabricaComandos.CrearComandoConsultarCompetencias();
            List<DominioSKD.Entidad> listaCompetencias = consultarCompetencias.Ejecutar();
            vista.competeciasNoRelacionadas.Enabled = true;
            vista.competeciasNoRelacionadas.DisplayMember = "nombre";
            //vista.competeciasNoRelacionadas.DataSource = listaCompetencias;
            foreach (DominioSKD.Entidad competencia in listaCompetencias)
            {
               
                vista.competeciasNoRelacionadas.Items.Add = (DominioSKD.Entidades.Modulo12.Competencia)competencia;
            
            }
        }

        public void llenarComboRangos()
        {
            int index;
            vista.rangoMinimo.Enabled = true;
            vista.rangoMaximo.Enabled = true;
            
            for (index=0;index<=20;index++)
            {
                vista.rangoMinimo.Items.Add(index.ToString());
                
                vista.rangoMaximo.Items.Add(index.ToString());
            
            }

        }

        public void llenarComboEdades()
        {
            int index;
            vista.edadMinima.Enabled = true;
            vista.edadMaxima.Enabled = true;

            for (index = 4; index <= 65; index++)
            {
                
                vista.edadMinima.Items.Add(index.ToString(),index);

                vista.edadMaxima.Items.Add(index.ToString(),index);

            }

        }

        public void llenarComboSexo()
        {
            vista.sexo.Enabled = true;
            vista.sexo.Items.Add("");
        }
    
    }
}

