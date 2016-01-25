using DominioSKD;
using DominioSKD.Fabrica;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo7;
using Interfaz_Contratos.Modulo7;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo7;

namespace Interfaz_Presentadores.Modulo7
{
    public class PresentadorListarMatriculasPagas
    {
        private IContratoListarMatriculasPagas vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarMatriculasPagas(IContratoListarMatriculasPagas laVista)
        {
            vista = laVista;
        }

        public void ConsultarListaMatriculasPagas(Entidad idPersona)
        {
            FabricaComandos fabricaComandos = new FabricaComandos();
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            try
            {
                Comando<Tuple<List<Entidad>, List<Boolean>, List<float>>> comandoListaMatriculasPagas = 
                fabricaComandos.ObtenerComandoConsultarListaMatriculasPagas();
                comandoListaMatriculasPagas.LaEntidad = idPersona;
                Tuple<List<Entidad>, List<Boolean>, List<float>> tupla = comandoListaMatriculasPagas.Ejecutar();

                List<Entidad>  listaMatricula = tupla.Item1;
                List<Boolean>  listaEstadoMatricula = tupla.Item2;
                List<float> listaMontoPagoMatricula = tupla.Item3;

                using (var e1 = listaMatricula.GetEnumerator())
                using (var e2 = listaEstadoMatricula.GetEnumerator())
                using (var e3 = listaMontoPagoMatricula.GetEnumerator())           
                {
                    while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    {
                        MatriculaM7 matricula = (MatriculaM7)e1.Current;
                        Boolean estadoMatricula = e2.Current;
                        float montoPago = e3.Current;
                        String estadoFinal;
                        
                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + matricula.Identificador.ToString() + M7_RecursosPresentador.CerrarTD;

                        if (estadoMatricula.Equals(true))
                        {
                              estadoFinal = "Activa";
                        }
                          else
                        {
                             estadoFinal = "No Activa";
                        }
                
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + estadoFinal.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + matricula.FechaCreacion.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + matricula.UltimaFechaPago.ToString("MM/dd/yyyy") + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + montoPago.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoPagosDeMatricula + matricula.Id + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
