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
    /// <summary>
    /// Presentador para detallar eventos pagos
    /// </summary>
    public class PresentadorListarEventosPagos
    {
        private IContratoListarEventosPagos vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la vista</param>
        public PresentadorListarEventosPagos(IContratoListarEventosPagos laVista)
        {
            vista = laVista;
        }
        /// <summary>
        /// Método para consultar los eventos pagos del atleta
        /// </summary>
        public void ConsultarListaEventosPagos(Entidad idPersona)
        {
            try
            {
                Comando<Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>>> comandoListaEventosPagos = 
                    FabricaComandos.ObtenerComandoConsultarListaEventosPagos();

               
                comandoListaEventosPagos.LaEntidad = idPersona;
                Tuple<List<Entidad>, List<Entidad>, List<DateTime>, List<float>, List<DateTime>> tupla = comandoListaEventosPagos.Ejecutar();

                List<Entidad>  listaEvento = tupla.Item1;
                List<Entidad>  listaCompetencia = tupla.Item2;
                List<DateTime> listaFechaPagoEvento = tupla.Item3;
                List<float> listaMontoPagoEvento = tupla.Item4;
                List<DateTime> listaFechaPagoCompetencia = tupla.Item5;

                using (var e1 = listaEvento.GetEnumerator())
                using (var e2 = listaFechaPagoEvento.GetEnumerator())
                using (var e3 = listaMontoPagoEvento.GetEnumerator())           
                {
                    while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    {
                        EventoM7 evento = (EventoM7)e1.Current;
                        DateTime fechaPagoEvento = e2.Current;
                        float montoPago = e3.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + evento.TipoEvento.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaPagoEvento.ToString(M7_RecursosPresentador.FormatoFecha) + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + montoPago.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoPagosAEventos + evento.Id + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;
                    }
                }
                
                using (var e1 = listaCompetencia.GetEnumerator())
                using (var e2 = listaFechaPagoCompetencia.GetEnumerator())
            
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        CompetenciaM7 competencia = (CompetenciaM7)e1.Current;
                        DateTime fechaPago = e2.Current;

                        vista.laTabla += M7_RecursosPresentador.AbrirTR;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.Nombre.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.TipoCompetencia.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + fechaPago.ToString(M7_RecursosPresentador.FormatoFecha) + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD + competencia.Costo.ToString() + M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.AbrirTD;
                        vista.laTabla += M7_RecursosPresentador.BotonInfoPagosACompetencias + competencia.Id + M7_RecursosPresentador.BotonCerrar;
                        vista.laTabla += M7_RecursosPresentador.CerrarTD;
                        vista.laTabla += M7_RecursosPresentador.CerrarTR;
                    }
                }
            }
            catch (NumeroEnteroInvalidoException)
            {
            }
            catch (FormatException)
            {
            }
            catch (Exception)
            {

            }
        }
    }
}
