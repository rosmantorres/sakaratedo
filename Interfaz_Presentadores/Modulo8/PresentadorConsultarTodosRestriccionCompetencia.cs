using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using Interfaz_Contratos.Modulo8;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Comandos.Modulo8;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
namespace Interfaz_Presentadores.Modulo8
{
    public class PresentadorConsultarTodosRestriccionCompetencia
    {
        private IContratoConsultarRestriccionCompetencia vista;
        List<Entidad> lista;
        public PresentadorConsultarTodosRestriccionCompetencia(IContratoConsultarRestriccionCompetencia laVista)
        {
            this.vista = laVista;

        }

        public void cargarInformacion(List<Entidad> lista)
        {
            try
            {
                this.lista = lista;
                foreach (DominioSKD.Entidades.Modulo8.RestriccionCompetencia restriccion in lista)
                {
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTR;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.IdRestriccionComp.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.Descripcion.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.EdadMinima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.EdadMaxima.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.RangoMinimo.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.RangoMaximo.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.Sexo.ToString() + RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD + restriccion.Modalidad.ToString() + RecursoPresentadorM8.CerrarTD;
                    //vista.restriccionCompetencia += RecursosPresentadorModulo14.AbrirTD;
                    //foreach (string dat in restriccion.Dato)
                    //{
                    //    vista.planillaCreadas += dat + RecursosPresentadorModulo14.linea;
                    //}
                    //vista.restriccionCompetencia += RecursosPresentadorModulo14.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.AbrirTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.BotonModificarRegistroCompetencia + restriccion.IdRestriccionComp + RecursoPresentadorM8.Descripcion
                        + restriccion.Descripcion + RecursoPresentadorM8.EdadMin + restriccion.EdadMinima + RecursoPresentadorM8.EdadMax + restriccion.EdadMaxima
                        + RecursoPresentadorM8.RangoMin + restriccion.RangoMinimo + RecursoPresentadorM8.RangoMax + restriccion.RangoMaximo
                        + RecursoPresentadorM8.Sexo + restriccion.Sexo + RecursoPresentadorM8.Modalidad + restriccion.Modalidad + RecursoPresentadorM8.BotonCerrar;

                    //vista.restriccionCompetencia += RecursosPresentadorModulo14.BotonModificarRegistro + restriccion.ID + RecursosPresentadorModulo14.Nombre + plani.Nombre + RecursosPresentadorModulo14.Tipo + plani.TipoPlanilla + RecursosPresentadorModulo14.BotonCerrar;
                    //if (plani.Status)
                    //    vista.planillaCreadas += RecursosPresentadorModulo14.BotonActivarPlanilla + restriccion.ID + RecursosPresentadorModulo14.BotonCerrar;
                    //else
                    //    vista.planillaCreadas += RecursosPresentadorModulo14.BotonDesactivarPlanilla + restriccion.ID + RecursosPresentadorModulo14.BotonCerrar;
                    vista.restriccionCompetencia += RecursoPresentadorM8.CerrarTD;
                    vista.restriccionCompetencia += RecursoPresentadorM8.CerrarTR;

                }



            }
            catch (Exception ex)
            {


            }

        }

        public List<Entidad> LlenarTabla()
        {
            try
            {
                Comando<List<Entidad>> command = FabricaComandos.CrearComandoConsultarTodosRestriccionCompetencia();
                return command.Ejecutar();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
